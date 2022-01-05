namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G100_FormaIniciacaoPix : IG100_FormaIniciacaoPix
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
