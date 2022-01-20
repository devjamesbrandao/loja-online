using Loja.Core.Message;

namespace Loja.Core.Comunicacao
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Evento;
    }
}