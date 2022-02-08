using Loja.Core.Comunicacao;
using Loja.Core.Data;
using Loja.Core.Message;
using Loja.Pagamento.Data.Extension;
using Loja.Pagamento.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Loja.Pagamento.Data.Context
{
    public class PagamentoContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public PagamentoContext(DbContextOptions<PagamentoContext> options, IMediatorHandler rebusHandler)
            : base(options)
        {
            _mediatorHandler = rebusHandler ?? throw new ArgumentNullException(nameof(rebusHandler));
        }

        public DbSet<Loja.Pagamento.Dominio.Entidades.Pagamento> Pagamentos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


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

            var sucesso = await base.SaveChangesAsync() > 0;

            if (sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Evento>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagamentoContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
