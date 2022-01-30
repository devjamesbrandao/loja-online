using Loja.Catalogo.Dominio.Entidades;
using Loja.Core.Data;
using Loja.Core.Message;
using Microsoft.EntityFrameworkCore;

namespace Loja.Catalogo.Data.Context
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext()
        {
            
        }
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        // Mapeia todos os campos do tipo string para varchar(100)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            // Ignorar evento
            modelBuilder.Ignore<Evento>();

            // Aplica as configurações do banco de dados
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            
            return await base.SaveChangesAsync() > 0;
        }
    }
}