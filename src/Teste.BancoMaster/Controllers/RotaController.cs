using Microsoft.AspNetCore.Mvc;
using Teste.BancoMaster.Application.Interfaces;
using Teste.BancoMaster.Application.ViewModels.Request;

namespace Teste.BancoMaster.Services.API.Controllers
{
    [Route("api/rota")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaAppService _rotaAppService;
        public RotaController(IRotaAppService rotaAppService)
        {
            _rotaAppService = rotaAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rotaAppService.ListarRota());
        }

        [HttpPost]
        public async Task<IActionResult> Post(RotaViewModelRequest rota) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _rotaAppService.InserirRota(rota);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(RotaViewModelRequest rota)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _rotaAppService.AtualizarRota(rota);

            return Ok();
        }
    }
}
