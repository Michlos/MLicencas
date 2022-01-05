namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G084_NaturezaLancamento : IG084_NaturezaLancamento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
