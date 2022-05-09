using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Producer.Domain.Entities;
using Producer.Infrastructure.RabbitMq.Contracts;
using RabbitMQ.Client;

namespace Producer.Infrastructure.RabbitMq
{
    public class MessageRMQ : IMessageRMQ
    {
        private readonly string RABBIT_HOSTNAME;
        private readonly string EXCHANGE_NAME;
        

        public MessageRMQ()
        {
            EXCHANGE_NAME = Environment.GetEnvironmentVariable("EXCHANGE_NAME");
            RABBIT_HOSTNAME = Environment.GetEnvironmentVariable("RABBIT_HOSTNAME");
        }

        public void SendMessageToExchange(Message message)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = RABBIT_HOSTNAME
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: EXCHANGE_NAME, type: ExchangeType.Direct, durable: true, autoDelete: false);

                    var jsonMessage = JsonSerializer.Serialize(message);
                    byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(jsonMessage);

                    channel.BasicPublish(exchange: EXCHANGE_NAME,
                                         routingKey: "",
                                         basicProperties: null,
                                         body: messageBodyBytes);

                    Console.WriteLine("Publish!");
                }
            }
        }
    }
}
