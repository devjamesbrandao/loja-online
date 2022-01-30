using Loja.Venda.Aplicacao.Queries.ViewModels;

namespace Loja.Venda.Aplicacao.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}