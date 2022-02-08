using Loja.Core.Message;

namespace Loja.Venda.Aplicacao.Commands
{
    public class FinalizarPedidoCommand : Comando
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }

        public FinalizarPedidoCommand(Guid pedidoId, Guid clienteId)
        {
            IdAgregado = pedidoId;
            PedidoId = pedidoId;
            ClienteId = clienteId;
        }
    }
}