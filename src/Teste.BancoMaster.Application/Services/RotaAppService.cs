using AutoMapper;
using Teste.BancoMaster.Application.Interfaces;
using Teste.BancoMaster.Application.ViewModels.Request;
using Teste.BancoMaster.Application.ViewModels.Response;
using Teste.BancoMaster.Domain.Commands;
using Teste.BancoMaster.Domain.Core.Bus;
using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Domain.Models;

namespace Teste.BancoMaster.Application.Services
{
    public class RotaAppService : IRotaAppService
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        public RotaAppService(IRotaRepository rotaRepository, IMapper mapper, IMediatorHandler mediator)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<RotaViewModelRequest>> ListarRota()
        {
            var rotas = _mapper.Map<List<RotaViewModelRequest>>(await _rotaRepository.ObterTodos());

            if (rotas.Any())
                return rotas;

            return await AdicionarRotas();
        }

        public async Task InserirRota(RotaViewModelRequest rota)
        {
            var rotaCommand = _mapper.Map<RegisterNewRotaCommand>(rota);
            await _mediator.SendCommand(rotaCommand);
        }

        public async Task AtualizarRota(RotaViewModelRequest rota)
        {
            var rotaCommand = _mapper.Map<UpdateRotaCommand>(rota);
            await _mediator.SendCommand(rotaCommand);
        }



        #region "Private area"
        private async Task<List<RotaViewModelRequest>> AdicionarRotas() =>
            _mapper.Map<List<RotaViewModelRequest>>(await _rotaRepository.AdicionarRotas(CriarRotas().Result));
        
        private Task<List<Rota>> CriarRotas()
        {
            var listaRotas = new List<Rota>();

            listaRotas.Add(new Rota("GRU", "BRC", 10));
            listaRotas.Add(new Rota("BRC", "SCL", 5));
            listaRotas.Add(new Rota("GRU", "CDG", 75));
            listaRotas.Add(new Rota("GRU", "SCL", 20));
            listaRotas.Add(new Rota("GRU", "ORL", 56));
            listaRotas.Add(new Rota("ORL", "CDG", 5));
            listaRotas.Add(new Rota("SCL", "ORL", 20));

            return Task.FromResult(listaRotas);
        }
        #endregion
    }
}
