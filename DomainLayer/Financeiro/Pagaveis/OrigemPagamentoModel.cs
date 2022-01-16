namespace DomainLayer.Financeiro.Pagaveis
{
    public class OrigemPagamentoModel : IOrigemPagamentoModel
    {
        public int Id { get; set; }
        public string Origem { get; set; }
    }
}
