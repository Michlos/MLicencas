namespace DomainLayer.Financeiro
{
    public class TipoLancamentoModel : ITipoLancamentoModel
    {
        public int Id { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
