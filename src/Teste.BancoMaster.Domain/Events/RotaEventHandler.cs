using MediatR;

namespace Teste.BancoMaster.Domain.Events
{
    public class RotaEventHandler :
        INotificationHandler<RotaRegisteredEvent>,
        INotificationHandler<RotaUpdatedEvent>,
        INotificationHandler<RotaRemovedEvent>
    {
        public Task Handle(RotaUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(RotaRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(RotaRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}
