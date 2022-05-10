using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using RabbitMQ.Client;

namespace Consumer.Infrastructure.RabbitMq
{
    

    public class MessageRMQ : IMessageRMQ
    {
        
        private readonly string RABBIT_HOSTNAME;
        

        public MessageRMQ()
        {
            RABBIT_HOSTNAME = Environment.GetEnvironmentVariable("RABBIT_HOSTNAME");
        }

        public IModel GetQueue(string queueName)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = RABBIT_HOSTNAME,
                DispatchConsumersAsync = true
            };
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queueName, true, false, false);
            channel.BasicQos(0, 1, false);
            return channel;
        }
    }
}
