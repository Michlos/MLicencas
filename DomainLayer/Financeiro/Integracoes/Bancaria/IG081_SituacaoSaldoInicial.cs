namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG081_SituacaoSaldoInicial
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}