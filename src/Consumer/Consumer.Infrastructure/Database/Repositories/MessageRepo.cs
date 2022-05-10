using Consumer.Domain.MessageAggregate;
using Consumer.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infrastructure.Database.Repositories
{
    public class MessageRepo : IMessageRepo
    {
        private readonly MessageContext _context;

        public MessageRepo(MessageContext context)
        {
            this._context = context;
        }

        public async Task SaveMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Message> ListAllMessage()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> ListAllMessageFromDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Message RemoveMessage(long id)
        {
            throw new NotImplementedException();
        }
    }
}
