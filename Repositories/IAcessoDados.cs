using TransacaoFinanceira.Domain;

namespace TransacaoFinanceira.Repositories
{
    public interface IAcessoDados
    {
        ContaSaldo getSaldo(long id);
        bool atualizar(ContaSaldo dado);
    }
}