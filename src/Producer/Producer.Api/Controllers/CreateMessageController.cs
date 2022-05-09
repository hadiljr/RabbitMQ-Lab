using Domain.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Producer.Domain.Entities;
using Producer.Infrastructure.RabbitMq.Contracts;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateMessageController : ControllerBase
    {

        private const string EXCHANGE_NAME = "TestExchange";
        private readonly ILogger<CreateMessageController> _logger;
        private readonly IProducerMessageService _messageService;
        private readonly IMessageRMQ _messageRQM;

        public CreateMessageController(ILogger<CreateMessageController> logger, IProducerMessageService messageService, IMessageRMQ messageRQM)
        {
            _logger = logger;
            _messageService = messageService;
            _messageRQM = messageRQM;
        }

        [HttpGet]
        public IActionResult Health()
        {
            return Ok("online");
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
