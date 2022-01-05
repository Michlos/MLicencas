namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G029_FormaLancamento : IG029_FormaLancamento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
