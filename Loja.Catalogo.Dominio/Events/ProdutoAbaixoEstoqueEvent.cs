using Loja.Core.Message;
using Loja.Core.Message.MensagensComum.EventoDeDominio;

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