namespace DomainLayer.Financeiro.Pagaveis
{
    public interface IContaLiquidadaCaixaModel
    {
        int ContaLiquidadaId { get; set; }
        int Id { get; set; }
        int LancamentoCaixaId { get; set; }
    }
}