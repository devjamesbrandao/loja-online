
using Loja.Core.Message;

namespace Loja.Venda.Aplicacao.Events
{
    public class PedidoFinalizadoEvent : Evento
    {
        public Guid PedidoId { get; private set; }

        public PedidoFinalizadoEvent(Guid pedidoId)
        {
            PedidoId = pedidoId;
            IdAgregado = pedidoId;
        }
    }
}