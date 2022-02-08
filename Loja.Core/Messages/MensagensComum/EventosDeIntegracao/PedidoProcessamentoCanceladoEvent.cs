
using Loja.Core.Message.MensagensComum.EventoDeIntegracao;
using Loja.Core.ObjetosDominio.DTO;

namespace Loja.Core.Message.MensagensComum
{
    public class PedidoProcessamentoCanceladoEvent : EventoIntegracao
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public ListaProdutosPedido ProdutosPedido { get; private set; }

        public PedidoProcessamentoCanceladoEvent(Guid pedidoId, Guid clienteId, ListaProdutosPedido produtosPedido)
        {
            IdAgregado = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ProdutosPedido = produtosPedido;
        }
    }
}