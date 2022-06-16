using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Domain.Models;
using Teste.BancoMaster.Infra.Data.Context;

namespace Teste.BancoMaster.Infra.Data.Repository
{
    public class RotaRepository : Repository<Rota>, IRotaRepository
    {
        public RotaRepository(TesteContext context)
            : base(context) { }

        public async Task<List<Rota>> AdicionarRotas(List<Rota> rotas)
        {
            DbSet.AddRange(rotas);
            await SaveChanges();

            return rotas;
        }
    }
}
