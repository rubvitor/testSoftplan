using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace TesteSoftplan.Domain.Events
{
    public class JurosEventHandler :
        INotificationHandler<JurosRegisteredEvent>,
        INotificationHandler<JurosUpdatedEvent>,
        INotificationHandler<JurosRemovedEvent>
    {
        public Task Handle(JurosUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(JurosRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(JurosRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}