namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class V005_FormaPagamento : IV005_FormaPagamento
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
