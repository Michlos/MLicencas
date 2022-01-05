namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class V002_CodigoMovimentoRemessa : IV002_CodigoMovimentoRemessa
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
