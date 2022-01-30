using MediatR;

namespace Loja.Core.Message.Notificacoes
{
    public class NotificacaoDominioHandler : INotificationHandler<NotificacaoDominio>
    {
        private List<NotificacaoDominio> _notifications;

        public NotificacaoDominioHandler()
        {
            _notifications = new List<NotificacaoDominio>();
        }

        public Task Handle(NotificacaoDominio mensagem, CancellationToken cancellationToken)
        {
            _notifications.Add(mensagem);
            
            return Task.CompletedTask;
        }

        public virtual List<NotificacaoDominio> ObterNotificacoes()
        {
            return _notifications;
        }

        public virtual bool TemNotificacao()
        {
            return ObterNotificacoes().Any();
        }

        public void Dispose()
        {
            _notifications = new List<NotificacaoDominio>();
        }
    }
}