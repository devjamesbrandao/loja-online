namespace Loja.Catalogo.Dominio.Interfaces
{
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);

        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}