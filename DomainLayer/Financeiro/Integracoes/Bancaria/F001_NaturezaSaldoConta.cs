namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class F001_NaturezaSaldoConta : IF001_NaturezaSaldoConta
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
