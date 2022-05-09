using Consumer.Application.Services;
using Consumer.Application.Workers;
using Consumer.Domain.Contracts.Repositories;
using Consumer.Domain.Contracts.Services;
using Consumer.Infrastructure.Database.Context;
using Consumer.Infrastructure.Database.Repositories;
using Consumer.Infrastructure.RabbitMq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((host, services) =>
                {

                    var dbConStr = host.Configuration.GetConnectionString("DefaultConnection");

                    ApplyMigrations(dbConStr);

                    services.AddDbContext<MessageContext>(
                                opt => opt.UseSqlServer(dbConStr)
                            );
                    services.AddScoped<IMessageRepo, MessageRepo>();
                    services.AddScoped<IMessageRMQ, MessageRMQ>();
                    services.AddScoped<IConsumerMessageService, ConsumerMessageService>();

                    services.AddHostedService<MessageReader>();
                });
                

        private static void ApplyMigrations(string connectionstring)
        {
            using (var context = new MessageContext(connectionstring))
            {
                context.Database.Migrate();
            }
        }
    }
}
