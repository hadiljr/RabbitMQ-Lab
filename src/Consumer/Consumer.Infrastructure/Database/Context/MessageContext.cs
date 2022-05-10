using Consumer.Domain.MessageAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infrastructure.Database.Context
{
    public class MessageContext:DbContext
    {
        private readonly string _connectionString;
        public MessageContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MessageContext(DbContextOptions<MessageContext> opt_Db) : base(opt_Db)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(_connectionString))
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        public DbSet<Message> Messages { get; set; }
    }
}
