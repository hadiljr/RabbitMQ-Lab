using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Domain.MessageAggregate
{
    public interface IMessageRepo
    {

        public Task SaveMessageAsync(Message message);
        public Message RemoveMessage(long id);
        public IEnumerable<Message> ListAllMessage();
        public IEnumerable<Message> ListAllMessageFromDate(DateTime date);
    }
}
