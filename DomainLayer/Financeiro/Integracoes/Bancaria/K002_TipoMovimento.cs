namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K002_TipoMovimento : IK002_TipoMovimento
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
