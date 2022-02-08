using Loja.Core.Interfaces;
using Loja.Core.ObjetosDominio;

namespace Loja.Pagamento.Dominio.Entidades
{
    public class Pagamento : Entidade, IAggregateRoot
    {
        public Guid PedidoId { get; set; }
        public string Status { get; set; }
        public decimal Valor { get; set; }

        public string NomeCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        // EF. Rel.
        public Transacao Transacao { get; set; }
    }
}
