using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Domain.MessageAggregate
{
    public interface IConsumerMessageService
    {
        Task SaveMessageAsync(Message message);
    }
}
