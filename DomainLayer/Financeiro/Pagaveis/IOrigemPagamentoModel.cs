namespace DomainLayer.Financeiro.Pagaveis
{
    public interface IOrigemPagamentoModel
    {
        int Id { get; set; }
        string Origem { get; set; }
    }
}