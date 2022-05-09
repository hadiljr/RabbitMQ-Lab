using Producer.Domain.Entities;

namespace Producer.Infrastructure.RabbitMq.Contracts
{
    public interface IMessageRMQ
    {
        void SendMessageToExchange(Message message);
    }
}
