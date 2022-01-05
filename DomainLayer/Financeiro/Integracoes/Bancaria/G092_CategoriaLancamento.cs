namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G092_CategoriaLancamento : IG092_CategoriaLancamento
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
