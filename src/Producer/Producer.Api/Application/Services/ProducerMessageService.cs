using Producer.Domain.MessageAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer.Api.Application.Services
{
    public class ProducerMessageService : IProducerMessageService
    {
        
        public ProducerMessageService()
        {
            
        }

        public Message CreateMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Message can not be empty or spaces", "message");
            }

            return new Message
            {
                Date = DateTime.Now,
                Value = message
            };
        }
    }
}
