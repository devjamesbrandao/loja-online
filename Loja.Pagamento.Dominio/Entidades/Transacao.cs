
using Loja.Core.ObjetosDominio;

namespace Loja.Pagamento.Dominio.Entidades
{
    public class Transacao : Entidade
    {
        public Guid PedidoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }

        // EF. Rel.
        public Pagamento Pagamento { get; set; }
    }
}