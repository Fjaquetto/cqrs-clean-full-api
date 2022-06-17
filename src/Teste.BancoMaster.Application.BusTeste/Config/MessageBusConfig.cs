using Teste.BancoMaster.CC.Bus.MessageBus.MessageBusConfig;

namespace Teste.BancoMaster.Application.BusTeste.Config
{
    public static class MessageBusConfig
    {
        public static void AddMessageBusConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMessageBus("host=localhost:5672");
        }
    }
}
