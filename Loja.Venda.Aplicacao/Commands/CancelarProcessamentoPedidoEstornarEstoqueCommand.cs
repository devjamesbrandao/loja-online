
using Loja.Core.Message;

namespace Loja.Venda.Aplicacao.Commands
{
    public class CancelarProcessamentoPedidoEstornarEstoqueCommand : Comando
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public CancelarProcessamentoPedidoEstornarEstoqueCommand(Guid pedidoId, Guid clienteId)
        {
            IdAgregado = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}