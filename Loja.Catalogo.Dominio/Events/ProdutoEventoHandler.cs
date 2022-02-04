using Loja.Catalogo.Dominio.Interfaces;
using Loja.Core.Comunicacao;
using Loja.Core.Message.MensagensComum.EventoDeIntegracao;
using MediatR;

namespace Loja.Catalogo.Dominio.Events
{
    public class ProdutoEventoHandler : INotificationHandler<ProdutoAbaixoEstoqueEvent>,
    INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        private readonly IEstoqueService _estoqueService;

        private readonly IMediatorHandler _mediatorHandler;

        public ProdutoEventoHandler(
            IProdutoRepository produtoRepository, 
            IEstoqueService estoqueService,
            IMediatorHandler mediatorHandler
        )
        {
            _produtoRepository = produtoRepository;

            _estoqueService = estoqueService;

            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            // Comprar mais produto
            var produto = await _produtoRepository.ObterPorId(mensagem.IdAgregado);
        }

        public async Task Handle(PedidoIniciadoEvent message, CancellationToken cancellationToken)
        {
            var result = await _estoqueService.DebitarListaProdutosPedido(message.ProdutosPedido);

            if (result)
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueConfirmadoEvent(message.PedidoId, message.ClienteId, message.Total, message.ProdutosPedido, message.NomeCartao, message.NumeroCartao, message.ExpiracaoCartao, message.CvvCartao));
            }
            else
            {
                await _mediatorHandler.PublicarEvento(new PedidoEstoqueRejeitadoEvent(message.PedidoId, message.ClienteId));
            }
        }
    }
}