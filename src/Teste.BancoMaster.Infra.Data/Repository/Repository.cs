using Microsoft.EntityFrameworkCore;
using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Infra.Data.Context;

namespace Teste.BancoMaster.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TesteContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TesteContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Remover(int id)
        {
            var entidade = await DbSet.FindAsync(id);

            if (entidade is null)
                return;

            DbSet.Remove(entidade);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}