using AutoMapper;
using Loja.Catalogo.Aplicacao.DTO;
using Loja.Catalogo.Dominio.Entidades;

namespace Loja.Catalogo.Aplicacao.Automapper
{
    public class DTOParaEntidadeProfile : Profile
    {
        public DTOParaEntidadeProfile()
        {
            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome, p.Descricao, p.Ativo,
                        p.Valor, p.CategoriaId, p.DataCadastro,
                        p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}