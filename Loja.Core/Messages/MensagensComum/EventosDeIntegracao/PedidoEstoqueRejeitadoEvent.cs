
namespace Loja.Core.Message.MensagensComum.EventoDeIntegracao
{
    public class PedidoEstoqueRejeitadoEvent : EventoIntegracao
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public PedidoEstoqueRejeitadoEvent(Guid pedidoId, Guid clienteId)
        {
            IdAgregado = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}