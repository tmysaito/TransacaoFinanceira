namespace TransacaoFinanceira.Services
{
    public interface IExecutarTransacaoFinanceira
    {
        void Transferir(int correlation_id, long conta_origem, long conta_destino, decimal valor);
    }
}