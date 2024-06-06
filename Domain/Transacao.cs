namespace TransacaoFinanceira.Domain
{
    public class Transacao
    {
        public int correlationId { get; set; }
        public string dateTime { get; set; }
        public long contaOrigem { get; set; }
        public long contaDestino { get; set; }
        public decimal valor { get; set; }
    }
}