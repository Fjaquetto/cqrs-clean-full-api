using Teste.BancoMaster.Domain.Models;

namespace Teste.BancoMaster.Domain.Interfaces
{
    public interface IRotaRepository : IRepository<Rota>
    {
        Task<List<Rota>> AdicionarRotas(List<Rota> rotas);
    }
}

