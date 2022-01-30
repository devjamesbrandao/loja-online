using Loja.Core.Comunicacao;
using Loja.Core.Data;
using Loja.Core.Message;
using Loja.Venda.Data.Extension;
using Loja.Venda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Loja.Venda.Data.Context
{
    public class VendasContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public VendasContext(DbContextOptions<VendasContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }


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

            if(sucesso) await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            // Ignorar evento
            modelBuilder.Ignore<Evento>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendasContext).Assembly);
            
            // Comportamento ao excluir entidades chaves
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            // Adicionando sequência
            modelBuilder.HasSequence<int>("MinhaSequencia").StartsAt(1000).IncrementsBy(1);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}