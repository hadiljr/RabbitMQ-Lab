using Consumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Domain.Contracts.Services
{
    public interface IConsumerMessageService
    {
        Task SaveMessageAsync(Message message);
    }
}
