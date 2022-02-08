using Loja.Pagamento.Dominio.Entidades;

namespace Loja.Pagamento.Dominio.Interfaces
{
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Loja.Pagamento.Dominio.Entidades.Pagamento pagamento);
    }
}