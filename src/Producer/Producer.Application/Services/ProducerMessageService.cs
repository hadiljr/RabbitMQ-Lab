
using Domain.Contracts.Services;
using Producer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
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
