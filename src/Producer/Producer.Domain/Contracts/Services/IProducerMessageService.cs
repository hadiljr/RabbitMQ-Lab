using Producer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Services
{
    public interface IProducerMessageService
    {

        Message CreateMessage(string message);
        
        
    }
}
