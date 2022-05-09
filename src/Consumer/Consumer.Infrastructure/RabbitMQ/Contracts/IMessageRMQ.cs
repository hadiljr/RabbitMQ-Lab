
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infrastructure.RabbitMq
{
    public interface IMessageRMQ
    {
        IModel GetQueue(string queueName);
    }
}
