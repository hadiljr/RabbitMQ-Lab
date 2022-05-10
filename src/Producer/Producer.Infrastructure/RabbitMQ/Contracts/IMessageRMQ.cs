using Producer.Domain.MessageAggregate;

namespace Producer.Infrastructure.RabbitMq.Contracts
{
    public interface IMessageRMQ
    {
        void SendMessageToExchange(Message message);
    }
}
