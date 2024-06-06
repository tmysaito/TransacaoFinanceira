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
            Console.WriteLine("Transacao numero {0}", correlation_id);
            if (conta_saldo_origem.saldo < valor)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", correlation_id);

            }
            else
            {
                ContaSaldo conta_saldo_destino = acessoDados.getSaldo(conta_destino);
                conta_saldo_origem.saldo -= valor;
                conta_saldo_destino.saldo += valor;
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlation_id, conta_saldo_origem.saldo, conta_saldo_destino.saldo);
            }
        }
    }
}