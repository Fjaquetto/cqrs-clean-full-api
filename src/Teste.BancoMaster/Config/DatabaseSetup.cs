using Microsoft.EntityFrameworkCore;
using Teste.BancoMaster.Infra.Data.Context;

namespace Teste.BancoMaster.Services.API.Config
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<TesteContext>(options =>
                options.UseInMemoryDatabase("Teste")) ;
        }
    }
}
