using Microsoft.AspNetCore.Mvc;
using Teste.BancoMaster.CC.Bus.MessageBus;
using Teste.BancoMaster.Domain.Core.Events;
using Teste.BancoMaster.Domain.Events;

namespace Teste.BancoMaster.Application.BusTeste.Controllers
{
    [Route("api/bus")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IMessageBus _bus;

        public BusController(IMessageBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> TesteBus()
        {
            var rota = new RotaRegisteredEvent(0, "tst", "ast", 110);

            var result = _bus.RequestAsync<RotaRegisteredEvent, ResponseMessage>(rota);

            return Ok();
        }
    }
}
