using Loja.Core.Message.Notificacoes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Loja.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly NotificacaoDominioHandler _notifications;

        public SummaryViewComponent(INotificationHandler<NotificacaoDominio> notifications)
        {
            _notifications = (NotificacaoDominioHandler)notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notifications.ObterNotificacoes());

            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Valor));

            return View();
        }
    }
}