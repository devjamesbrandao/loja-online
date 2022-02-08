using Loja.Core.Data;

namespace Loja.Pagamento.Dominio.Interfaces
{
    public interface IPagamentoRepository : IRepository<Loja.Pagamento.Dominio.Entidades.Pagamento>
    {
        void Adicionar(Loja.Pagamento.Dominio.Entidades.Pagamento pagamento);

        void AdicionarTransacao(Loja.Pagamento.Dominio.Entidades.Transacao transacao);
    }
}