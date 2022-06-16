using MediatR;
using Teste.BancoMaster.Domain.Core.Bus;
using Teste.BancoMaster.Domain.Core.Notification;
using Teste.BancoMaster.Domain.Events;
using Teste.BancoMaster.Domain.Interfaces;
using Teste.BancoMaster.Domain.Models;

namespace Teste.BancoMaster.Domain.Commands
{
    public class RotaCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewRotaCommand, bool>,
        IRequestHandler<UpdateRotaCommand, bool>,
        IRequestHandler<RemoveRotaCommand, bool>
    {
        private readonly IRotaRepository _rotaRepository;
        private readonly IMediatorHandler Bus;

        public RotaCommandHandler(IRotaRepository rotaRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _rotaRepository = rotaRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewRotaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var rota = new Rota(message.Origem, message.Destino, message.Valor);

            _rotaRepository.Adicionar(rota);

            if (Commit())
            {
                Bus.RaiseEvent(new RotaRegisteredEvent(rota.Id, rota.Origem, rota.Destino, rota.Valor));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateRotaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var rota = new Rota(message.Origem, message.Destino, message.Valor);

            _rotaRepository.Atualizar(rota);

            if (Commit())
            {
                Bus.RaiseEvent(new RotaUpdatedEvent(rota.Id, rota.Origem, rota.Destino, rota.Valor));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveRotaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _rotaRepository.Remover(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new RotaRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _rotaRepository.Dispose();
        }

    }
}
