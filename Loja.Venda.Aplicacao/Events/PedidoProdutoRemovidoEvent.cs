using Loja.Core.Message;

namespace Loja.Venda.Aplicacao.Events
{
    public class PedidoProdutoRemovidoEvent : Evento
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }

        public PedidoProdutoRemovidoEvent(Guid clienteId, Guid pedidoId, Guid produtoId)
        {
            IdAgregado = pedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
            ProdutoId = produtoId;
        }
    }
}