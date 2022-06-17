using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BancoMaster.CC.Bus.MessageBus;
using Teste.BancoMaster.Domain.Commands;
using Teste.BancoMaster.Domain.Core.Bus;
using Teste.BancoMaster.Domain.Core.Events;
using Teste.BancoMaster.Domain.Events;

namespace Teste.BancoMaster.Domain.Integration
{
    public class RegistroRotaIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroRotaIntegrationHandler(
                            IServiceProvider serviceProvider,
                            IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        private void SetResponder()
        {
            _bus.RespondAsync<RotaRegisteredEvent, ResponseMessage>(async request =>
                await RegistrarCliente(request));

            _bus.AdvancedBus.Connected += OnConnect;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetResponder();
            return Task.CompletedTask;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetResponder();
        }

        private async Task<ResponseMessage> RegistrarCliente(RotaRegisteredEvent message)
        {
            var clienteCommand = new RegisterNewRotaCommand(message.Id, message.Origem, message.Destino, message.Valor);
            ValidationResult sucesso;

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                await mediator.SendCommand(clienteCommand);
            }

            return new ResponseMessage(new ValidationResult());
        }
    }
}
