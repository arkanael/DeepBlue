using DeepBlue.Application.Notifications;
using DeepBlue.Domain.Contracts.Logs;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeepBlue.Application.EventHandler
{
    public class PessoaLogHandler : INotificationHandler<PessoaNotification>
    {
        private readonly IPessoaLog log;

        public PessoaLogHandler(IPessoaLog log)
        {
            this.log = log;
        }

        public Task Handle(PessoaNotification notification, CancellationToken cancellationToken)
        {
            var message = $"{notification.Action.ToString().ToUpper()} com sucesso";

            return Task.Run(() =>
            {
                log.Create(notification.Pessoa, message, DateTime.Now);
            });
        }
    }
}
