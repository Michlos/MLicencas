namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG092_CategoriaLancamento
    {
        int Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
        int TipoId { get; set; }
    }
}