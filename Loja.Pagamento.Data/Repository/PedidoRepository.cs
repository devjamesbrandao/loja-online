
using Loja.Core.Data;
using Loja.Pagamento.Data.Context;
using Loja.Pagamento.Dominio.Entidades;
using Loja.Pagamento.Dominio.Interfaces;

namespace Loja.Pagamento.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentoContext _context;

        public PagamentoRepository(PagamentoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public void Adicionar(Loja.Pagamento.Dominio.Entidades.Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}