using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Producer.Domain.MessageAggregate;
using Producer.Infrastructure.RabbitMq.Contracts;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private const string EXCHANGE_NAME = "TestExchange";
        private readonly ILogger<MessageController> _logger;
        private readonly IProducerMessageService _messageService;
        private readonly IMessageRMQ _messageRQM;

        public MessageController(ILogger<MessageController> logger, IProducerMessageService messageService, IMessageRMQ messageRQM)
        {
            _logger = logger;
            _messageService = messageService;
            _messageRQM = messageRQM;
        }       

        [HttpPost]
        public IActionResult CreateMessage(string message)
        {
            var result = _messageService.CreateMessage(message);
            _messageRQM.SendMessageToExchange(result);
            return Accepted();
        }
    }
}
