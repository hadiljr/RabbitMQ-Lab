using Consumer.Domain.MessageAggregate;
using Consumer.Infrastructure.RabbitMq;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Worker.Application.Workers
{
    public class MessageReader : BackgroundService
    {
        private readonly ILogger<MessageReader> _logger;
        private readonly IConsumerMessageService _consumerMessageService;
        private readonly IMessageRMQ _messageRMQ;

        private IModel _channel;

        private readonly string QUEUE_NAME; 

        public MessageReader(ILogger<MessageReader> logger, IConsumerMessageService consumerMessageService, IMessageRMQ messageRMQ)
        {
            _logger = logger;
            _consumerMessageService = consumerMessageService;
            _messageRMQ = messageRMQ;
            QUEUE_NAME = Environment.GetEnvironmentVariable("QUEUE_NAME");
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _messageRMQ.GetQueue(QUEUE_NAME);
            //_connection = _channel.
            _logger.LogInformation($"Queue [{QUEUE_NAME}] is waiting for messages.");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new AsyncEventingBasicConsumer(_channel);
            consumer.Received += async (sender, eventArgs) =>
           {
               var messageRMQ = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
               _logger.LogInformation($"Processing msg: '{messageRMQ}'.");


               try
               {
                   var message = JsonSerializer.Deserialize<Message>(messageRMQ);

                   await _consumerMessageService.SaveMessageAsync(message);

                   await Task.Delay(new Random().Next(1, 3) * 1000, stoppingToken); // simulate an async process

                    _channel.BasicAck(eventArgs.DeliveryTag, false);
               }
               catch (JsonException)
               {
                   _logger.LogError($"JSON Parse Error: '{messageRMQ}'.");
                   _channel.BasicNack(eventArgs.DeliveryTag, false, false);
               }
               catch (AlreadyClosedException)
               {
                   _logger.LogInformation("RabbitMQ is closed!");
               }
               catch (Exception e)
               {
                   _logger.LogError(default, e, e.Message);
               }
           };

            _channel.BasicConsume(queue: QUEUE_NAME, autoAck: false, consumer: consumer);

            await Task.CompletedTask;
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            await base.StopAsync(cancellationToken);
            _channel.Close();
            _logger.LogInformation("RabbitMQ connection is closed.");
        }
    }
}
