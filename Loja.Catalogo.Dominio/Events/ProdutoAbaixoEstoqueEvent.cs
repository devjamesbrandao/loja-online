using Loja.Core.ObjetosDominio;

namespace Loja.Catalogo.Dominio.Events
{
    public class ProdutoAbaixoEstoqueEvent : EventoDominio
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid idagregado, int quantidadeRestante) : base(idagregado)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}