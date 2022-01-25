using Loja.Catalogo.Aplicacao.DTO;
using Loja.Catalogo.Dominio.Entidades;

namespace Loja.Catalogo.Aplicacao.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
        Task<ProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDTO>> ObterTodos();
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();

        Task<int> ObterAsync(Guid id);
        Task<int> ObterQuantidadeEstoque(Guid id);
        Task AdicionarProduto(ProdutoDTO ProdutoDTO);
        Task AtualizarProduto(ProdutoDTO ProdutoDTO);

        Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade);
    }
}