namespace Loja.Core.Message.MensagensComum.EventoDeIntegracao
{
    public class PedidoPagamentoRecusadoEvent : EventoIntegracao
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid PagamentoId { get; private set; }
        public Guid TransacaoId { get; private set; }
        public decimal Total { get; private set; }

        public PedidoPagamentoRecusadoEvent(Guid pedidoId, Guid clienteId, Guid pagamentoId, Guid transacaoId, decimal total)
        {
            IdAgregado = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            PagamentoId = pagamentoId;
            TransacaoId = transacaoId;
            Total = total;
        }
    }
}