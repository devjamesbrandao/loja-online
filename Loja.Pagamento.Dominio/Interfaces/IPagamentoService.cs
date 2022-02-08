using Loja.Core.ObjetosDominio.DTO;
using Loja.Pagamento.Dominio.Entidades;

namespace Loja.Pagamento.Dominio.Interfaces
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}