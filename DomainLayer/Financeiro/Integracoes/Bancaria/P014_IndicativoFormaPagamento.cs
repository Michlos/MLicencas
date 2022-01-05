namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class P014_IndicativoFormaPagamento : IP014_IndicativoFormaPagamento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
