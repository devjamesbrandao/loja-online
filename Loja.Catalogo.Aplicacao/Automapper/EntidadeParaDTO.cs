using AutoMapper;
using Loja.Catalogo.Aplicacao.DTO;
using Loja.Catalogo.Dominio.Entidades;

namespace Loja.Catalogo.Aplicacao.Automapper
{
    public class EntidadeParaDTOProfile : Profile
    {
        public EntidadeParaDTOProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}