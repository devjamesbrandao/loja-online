using AutoMapper;
using Loja.Catalogo.Aplicacao.DTO;
using Loja.Catalogo.Dominio.Entidades;
using Loja.Catalogo.Dominio.Interfaces;
using Loja.Core.Exceptions;

namespace Loja.Catalogo.Aplicacao.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public ProdutoAppService(
            IProdutoRepository produtoRepository, 
            IMapper mapper, 
            IEstoqueService estoqueService)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _estoqueService = estoqueService;
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoDTO> ObterPorId(Guid id)
        {
            var produto = await _produtoRepository.ObterPorId(id);

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<int> ObterAsync(Guid id)
        {
            var prod = await _produtoRepository.ObterPorId(id);

            return prod.QuantidadeEstoque;
        }

        public async Task<int> ObterQuantidadeEstoque(Guid id)
        {
            return await _produtoRepository.RetornarQuantidadeEstoque(id);
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos());
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _produtoRepository.ObterCategorias());
        }

        public async Task AdicionarProduto(ProdutoDTO ProdutoDTO)
        {
            var produto = _mapper.Map<Produto>(ProdutoDTO);

            _produtoRepository.Adicionar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDTO ProdutoDTO)
        {
            var produto = _mapper.Map<Produto>(ProdutoDTO);

            _produtoRepository.Atualizar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.DebitarEstoque(id, quantidade).Result)
            {
                throw new ExcecaoDominio("Erro ao debitar estoque.");
            }

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade)
        {
            if (!_estoqueService.ReporEstoque(id, quantidade).Result)
            {
                throw new ExcecaoDominio("Erro ao repor estoque.");
            }

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
    
}