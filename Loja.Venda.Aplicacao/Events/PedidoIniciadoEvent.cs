using System;
using Loja.Core.Message;

namespace Loja.Venda.Aplicacao.Events
{
    public class PedidoRascunhoIniciadoEvent : Evento
    {
        public Guid ClienteId { get; private set; }
        public Guid PedidoId { get; private set; }

        public PedidoRascunhoIniciadoEvent(Guid clienteId, Guid pedidoId)
        {
            IdAgregado = pedidoId;
            ClienteId = clienteId;
            PedidoId = pedidoId;
        }
    }
}