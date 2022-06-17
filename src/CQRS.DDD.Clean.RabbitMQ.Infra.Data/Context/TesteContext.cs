using Microsoft.EntityFrameworkCore;
using Teste.BancoMaster.Domain.Models;
using Teste.BancoMaster.Infra.Data.Mapping;

namespace Teste.BancoMaster.Infra.Data.Context
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        public DbSet<Rota> Rotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RotaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
