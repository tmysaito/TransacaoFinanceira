using System;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.Repositories;

namespace TransacaoFinanceira.Services
{
    public class ExecutarTransacaoFinanceira : IExecutarTransacaoFinanceira
    {
        IAcessoDados acessoDados = new AcessoDados();
        public void Transferir(int correlation_id, long conta_origem, long conta_destino, decimal valor)
        {
            ContaSaldo conta_saldo_origem = acessoDados.getSaldo(conta_origem);
            ContaSaldo conta_saldo_destino = acessoDados.getSaldo(conta_destino);

            if (conta_saldo_origem == null)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada pois a conta de origem é inválida", correlation_id);
            }
            else if (conta_saldo_destino == null)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada pois a conta de destino é inválida", correlation_id);
            }
            else
            {
                if (conta_saldo_origem.saldo < valor)
                {
                    Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", correlation_id);

                }
                else
                {
                    conta_saldo_origem.saldo -= valor;
                    conta_saldo_destino.saldo += valor;
                    Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlation_id, conta_saldo_origem.saldo, conta_saldo_destino.saldo);
                }
            }
        }
    }
}