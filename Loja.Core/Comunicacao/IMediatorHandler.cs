using Loja.Core.Message;
using Loja.Core.Message.Notificacoes;

namespace Loja.Core.Comunicacao
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Evento;
        Task<bool> EnviarComando<T>(T comando) where T : Comando;
        Task PublicarNotificacao<T>(T notificacao) where T : NotificacaoDominio;
    }
}