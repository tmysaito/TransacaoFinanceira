using System;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.Services;

//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {

        static void Main(string[] args)
        {
            var transacoes = new[] { new Transacao {correlationId= 1,dateTime="09/09/2023 14:15:00", contaOrigem= 938485762, contaDestino= 2147483649, valor= 150},
                                     new Transacao {correlationId= 2,dateTime="09/09/2023 14:15:05", contaOrigem= 2147483649, contaDestino= 210385733, valor= 149},
                                     new Transacao {correlationId= 3,dateTime="09/09/2023 14:15:29", contaOrigem= 347586970, contaDestino= 238596054, valor= 1100},
                                     new Transacao {correlationId= 4,dateTime="09/09/2023 14:17:00", contaOrigem= 675869708, contaDestino= 210385733, valor= 5300},
                                     new Transacao {correlationId= 5,dateTime="09/09/2023 14:18:00", contaOrigem= 238596054, contaDestino= 674038564, valor= 1489},
                                     new Transacao {correlationId= 6,dateTime="09/09/2023 14:18:20", contaOrigem= 573659065, contaDestino= 563856300, valor= 49},
                                     new Transacao {correlationId= 7,dateTime="09/09/2023 14:19:00", contaOrigem= 938485762, contaDestino= 2147483649, valor= 44},
                                     new Transacao {correlationId= 8,dateTime="09/09/2023 14:19:01", contaOrigem= 573659065, contaDestino= 675869708, valor= 150},

            }; 
            IExecutarTransacaoFinanceira executor = new ExecutarTransacaoFinanceira();
            foreach (var item in transacoes)
            {
                executor.Transferir(item.correlationId, item.contaOrigem, item.contaDestino, item.valor);
            };

        }
    }
}
