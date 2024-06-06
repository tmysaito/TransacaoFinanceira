using Moq;
using TransacaoFinanceira.Services;
using TransacaoFinanceira.Repositories;
using Xunit;

public class TesteTransacaoFinanceira
{
    [Fact]
    public void ContaInvalidaFalha()
    {
        var acessoDadosMock = new Mock<IAcessoDados>();
        acessoDadosMock.Setup(ad => ad.getSaldo(12345)).Returns((ContaSaldo)null);

        var executor = new ExecutarTransacaoFinanceira();
        executor.Transferir(1, 12345, 938485762, 20);

        acessoDadosMock.Verify(ad => ad.getSaldo(12345), Times.Once);

    }

    [Fact]
    public void SaldoInsuficienteFalha()
    {
        var acessoDadosMock = new Mock<IAcessoDados>();
        var contaTeste = new ContaSaldo(12345, 99);
        acessoDadosMock.Setup(ad => ad.getSaldo(12345)).Returns(contaTeste);
        var executor = new ExecutarTransacaoFinanceira();
        executor.Transferir(10, 12345, 938485762, 999);

        acessoDadosMock.Verify(ad => ad.getSaldo(contaOrigem), Times.Once);

    }
}