namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H009_RegimeContratoMutuario : IH009_RegimeContratoMutuario
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
