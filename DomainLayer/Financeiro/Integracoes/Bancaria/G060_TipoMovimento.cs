namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G060_TipoMovimento : IG060_TipoMovimento
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
