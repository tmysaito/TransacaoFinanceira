using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {

        static void Main(string[] args)
        {
            var transacoes = new[] { new transacao {correlationId= 1,dateTime="09/09/2023 14:15:00", contaOrigem= 938485762, contaDestino= 2147483649, valor= 150},
                                     new transacao {correlationId= 2,dateTime="09/09/2023 14:15:05", contaOrigem= 2147483649, contaDestino= 210385733, valor= 149},
                                     new transacao {correlationId= 3,dateTime="09/09/2023 14:15:29", contaOrigem= 347586970, contaDestino= 238596054, valor= 1100},
                                     new transacao {correlationId= 4,dateTime="09/09/2023 14:17:00", contaOrigem= 675869708, contaDestino= 210385733, valor= 5300},
                                     new transacao {correlationId= 5,dateTime="09/09/2023 14:18:00", contaOrigem= 238596054, contaDestino= 674038564, valor= 1489},
                                     new transacao {correlationId= 6,dateTime="09/09/2023 14:18:20", contaOrigem= 573659065, contaDestino= 563856300, valor= 49},
                                     new transacao {correlationId= 7,dateTime="09/09/2023 14:19:00", contaOrigem= 938485762, contaDestino= 2147483649, valor= 44},
                                     new transacao {correlationId= 8,dateTime="09/09/2023 14:19:01", contaOrigem= 573659065, contaDestino= 675869708, valor= 150},

            };
            executarTransacaoFinanceira executor = new executarTransacaoFinanceira();
            Parallel.ForEach(transacoes, item =>
            {
                executor.transferir(item.correlationId, item.contaOrigem, item.contaDestino, item.valor);
            });

        }
    }

    class executarTransacaoFinanceira : acessoDados
    {
        public void transferir(int correlation_id, long conta_origem, long conta_destino, decimal valor)
        {
            contas_saldo conta_saldo_origem = getSaldo<contas_saldo>(conta_origem);
            if (conta_saldo_origem.saldo < valor)
            {
                Console.WriteLine("Transacao numero {0 } foi cancelada por falta de saldo", correlation_id);

            }
            else
            {
                contas_saldo conta_saldo_destino = getSaldo<contas_saldo>(conta_destino);
                conta_saldo_origem.saldo -= valor;
                conta_saldo_destino.saldo += valor;
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlation_id, conta_saldo_origem.saldo, conta_saldo_destino.saldo);
            }
        }
    }
    class contas_saldo
    {
        public contas_saldo(long conta, decimal valor)
        {
            this.conta = conta;
            this.saldo = valor;
        }
        public long conta { get; set; }
        public decimal saldo { get; set; }
    }
    class acessoDados
    {
        Dictionary<int, decimal> SALDOS { get; set; }
        private List<contas_saldo> TABELA_SALDOS;
        public acessoDados()
        {
            TABELA_SALDOS = new List<contas_saldo>();
            TABELA_SALDOS.Add(new contas_saldo(938485762, 180));
            TABELA_SALDOS.Add(new contas_saldo(347586970, 1200));
            TABELA_SALDOS.Add(new contas_saldo(2147483649, 0));
            TABELA_SALDOS.Add(new contas_saldo(675869708, 4900));
            TABELA_SALDOS.Add(new contas_saldo(238596054, 478));
            TABELA_SALDOS.Add(new contas_saldo(573659065, 787));
            TABELA_SALDOS.Add(new contas_saldo(210385733, 10));
            TABELA_SALDOS.Add(new contas_saldo(674038564, 400));
            TABELA_SALDOS.Add(new contas_saldo(563856300, 1200));


            SALDOS = new Dictionary<int, decimal>();
            this.SALDOS.Add(938485762, 180);

        }
        public T getSaldo<T>(long id)
        {
            return (T)Convert.ChangeType(TABELA_SALDOS.Find(x => x.conta == id), typeof(T));
        }
        public bool atualizar<T>(T dado)
        {
            try
            {
                contas_saldo item = (dado as contas_saldo);
                TABELA_SALDOS.RemoveAll(x => x.conta == item.conta);
                TABELA_SALDOS.Add(dado as contas_saldo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

    }
    public class transacao
    {
        public int correlationId { get; set; }
        public string dateTime { get; set; }
        public long contaOrigem { get; set; }
        public long contaDestino { get; set; }
        public decimal valor { get; set; }
    }
}
