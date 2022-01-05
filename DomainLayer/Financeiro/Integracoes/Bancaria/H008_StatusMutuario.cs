namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H008_StatusMutuario : IH008_StatusMutuario
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
