using Loja.Catalogo.Dominio.Interfaces;
using MediatR;

namespace Loja.Catalogo.Dominio.Events
{
    public class ProdutoEventoHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            // Comprar mais produto
            var produto = await _produtoRepository.ObterPorId(mensagem.IdAgregado);
        }
    }
}