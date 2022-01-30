using Loja.Core.Comunicacao;
using Loja.Core.Message.Notificacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private readonly NotificacaoDominioHandler _notifications;
        
        private readonly IMediatorHandler _mediatorHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected ControllerBase(
            INotificationHandler<NotificacaoDominio> notifications, 
            IMediatorHandler mediatorHandler
        )
        {
            _notifications = (NotificacaoDominioHandler)notifications;

            _mediatorHandler = mediatorHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Valor).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacao(new NotificacaoDominio(codigo, mensagem));
        }
    }
}