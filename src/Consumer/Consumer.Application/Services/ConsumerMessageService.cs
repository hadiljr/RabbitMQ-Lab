
using Consumer.Domain.Contracts.Repositories;
using Consumer.Domain.Contracts.Services;
using Consumer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Application.Services
{
    public class ConsumerMessageService : IConsumerMessageService
    {

        private readonly IMessageRepo _messageRepo;

        public ConsumerMessageService(IMessageRepo messageRepo)
        {
            this._messageRepo = messageRepo;

        }
        public async Task SaveMessageAsync(Message message)
        {
            await _messageRepo.SaveMessageAsync(message);
        }
    }
}
