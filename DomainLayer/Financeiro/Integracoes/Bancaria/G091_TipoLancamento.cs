namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G091_TipoLancamento : IG091_TipoLancamento
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
