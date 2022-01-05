namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class N019_OpcaoPagamento : IN019_OpcaoPagamento
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
