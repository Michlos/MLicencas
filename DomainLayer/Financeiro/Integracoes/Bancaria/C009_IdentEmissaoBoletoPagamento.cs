namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class C009_IdentEmissaoBoletoPagamento : IC009_IdentEmissaoBoletoPagamento
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
