using System;
using System.Collections.Generic;
using TransacaoFinanceira.Domain;
using TransacaoFinanceira.Repositories;

public class AcessoDados : IAcessoDados
{
    private List<ContaSaldo> TABELA_SALDOS;

    public AcessoDados()
    {
        TABELA_SALDOS = new List<ContaSaldo>();
        {
            TABELA_SALDOS.Add(new ContaSaldo(938485762, 180));
            TABELA_SALDOS.Add(new ContaSaldo(347586970, 1200));
            TABELA_SALDOS.Add(new ContaSaldo(2147483649, 0));
            TABELA_SALDOS.Add(new ContaSaldo(675869708, 4900));
            TABELA_SALDOS.Add(new ContaSaldo(238596054, 478));
            TABELA_SALDOS.Add(new ContaSaldo(573659065, 787));
            TABELA_SALDOS.Add(new ContaSaldo(210385733, 10));
            TABELA_SALDOS.Add(new ContaSaldo(674038564, 400));
            TABELA_SALDOS.Add(new ContaSaldo(563856300, 1200));
        }
    }

    public ContaSaldo getSaldo(long id)
    {
        return TABELA_SALDOS.Find(x => x.conta == id);
    }
    public bool atualizar(ContaSaldo dado)
    {
        try
        {

            TABELA_SALDOS.RemoveAll(x => x.conta == dado.conta);
            TABELA_SALDOS.Add(dado);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }

    }

}