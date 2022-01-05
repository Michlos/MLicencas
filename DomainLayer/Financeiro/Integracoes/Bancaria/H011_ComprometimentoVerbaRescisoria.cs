namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H011_ComprometimentoVerbaRescisoria : IH011_ComprometimentoVerbaRescisoria
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
