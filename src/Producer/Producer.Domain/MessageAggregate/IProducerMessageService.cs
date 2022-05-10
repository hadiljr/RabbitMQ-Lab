using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Domain.MessageAggregate
{
    public interface IProducerMessageService
    {

        Message CreateMessage(string message);
        
        
    }
}
