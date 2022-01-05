namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IP014_IndicativoFormaPagamento
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}