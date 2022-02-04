using Loja.Core.Message;
using Loja.Core.Message.MensagensComum.EventoDeDominio;
using Loja.Core.Message.Notificacoes;
using MediatR;

namespace Loja.Core.Comunicacao
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Evento
        {
            await _mediator.Publish(evento);
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Comando
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : NotificacaoDominio
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublicarEventoDominio<T>(T notificacao) where T : EventoDominio
        {
            await _mediator.Publish(notificacao);
        }
    }
}