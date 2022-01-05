namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class P001_CodigoCamaraCentralizadora : IP001_CodigoCamaraCentralizadora
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
