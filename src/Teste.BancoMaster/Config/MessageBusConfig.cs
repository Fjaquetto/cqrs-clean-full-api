using Teste.BancoMaster.CC.Bus.MessageBus;
using Teste.BancoMaster.CC.Bus.MessageBus.MessageBusConfig;
using Teste.BancoMaster.Domain.Integration;

namespace Teste.BancoMaster.Application.API.Config
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus("host=localhost:5672")
                .AddHostedService<RegistroRotaIntegrationHandler>();
        }
    }
}
