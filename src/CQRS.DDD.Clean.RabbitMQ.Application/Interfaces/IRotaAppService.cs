using Teste.BancoMaster.Application.ViewModels.Request;
using Teste.BancoMaster.Application.ViewModels.Response;

namespace Teste.BancoMaster.Application.Interfaces
{
    public interface IRotaAppService
    {
        Task<List<RotaViewModelRequest>> ListarRota();
        Task InserirRota(RotaViewModelRequest rota);
        Task AtualizarRota(RotaViewModelRequest rota);
    }
}
