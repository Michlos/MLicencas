namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IK002_TipoMovimento
    {
        int CategoriaId { get; set; }
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}