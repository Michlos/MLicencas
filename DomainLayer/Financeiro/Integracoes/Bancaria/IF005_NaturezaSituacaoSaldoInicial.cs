namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IF005_NaturezaSituacaoSaldoInicial
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}