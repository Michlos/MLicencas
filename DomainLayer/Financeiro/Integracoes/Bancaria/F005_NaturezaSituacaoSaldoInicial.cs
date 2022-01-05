namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class F005_NaturezaSituacaoSaldoInicial : IF005_NaturezaSituacaoSaldoInicial
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
