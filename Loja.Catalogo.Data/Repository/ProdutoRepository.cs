using Dapper.Contrib.Extensions;
using Loja.Catalogo.Data.Context;
using Loja.Catalogo.Dominio.Entidades;
using Loja.Catalogo.Dominio.Interfaces;
using Loja.Core.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Loja.Catalogo.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _context;

        public ProdutoRepository(CatalogoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            await Teste();
            return await _context.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            // return await _context.Produtos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<int> RetornarQuantidadeEstoque(Guid id)
        {
            return await _context.Produtos.AsNoTracking()
            .Where(x => x.Id == id).Select(x => x.QuantidadeEstoque).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            return await _context.Produtos.AsNoTracking().Include(p => p.Categoria).Where(c => c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _context.Categorias.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }

        public async Task Teste()
        {
            using(var connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                connection.Open();

                var t = new Teste
                {
                    Va = 1,
                    data = DateTime.Now
                };

                await connection.InsertAsync(t);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }


    [Table("Teste")]
    public class Teste
    {
        public int? id {get; set;}

        public int Va {get; set;}

        public DateTime? data {get; set;}

        public string Text {get; set;}
    }
}