namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class V020_FormaPagamentoIOF : IV020_FormaPagamentoIOF
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
