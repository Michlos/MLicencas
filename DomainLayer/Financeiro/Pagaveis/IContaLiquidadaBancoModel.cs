namespace DomainLayer.Financeiro.Pagaveis
{
    public interface IContaLiquidadaBancoModel
    {
        int ContaLiquidadaId { get; set; }
        int Id { get; set; }
        int LancamentoContaBancariaId { get; set; }
    }
}