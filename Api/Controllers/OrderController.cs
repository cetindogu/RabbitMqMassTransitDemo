using Api.Models;
using MassTransit;
using MessageContracts.Commands;
using MessageContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISendEndpoint _bus;

        public OrderController()
        {
            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMQConstants.Uri}/{RabbitMQConstants.OrderServiceQueueName}");
            _bus = bus.GetSendEndpoint(sendToUri).Result;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubmitOrder submitOrder)
        {
            await _bus.Send<ISubmitOrderCommand>(submitOrder);

            return Ok();
        }
    }
}
