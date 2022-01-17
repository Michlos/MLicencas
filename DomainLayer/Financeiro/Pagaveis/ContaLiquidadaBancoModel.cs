using DomainLayer.Financeiro.Bancos.ContaBancaria;

namespace DomainLayer.Financeiro.Pagaveis
{
    public class ContaLiquidadaBancoModel : IContaLiquidadaBancoModel
    {
        public int Id { get; set; }
        public int ContaLiquidadaId { get; set; }
        public virtual ContaLiquidadaModel ContaLiquidadaModel { get; set; }
        public int LancamentoContaBancariaId { get; set; }
        public virtual LancamentoContaBancariaModel LancamentoContaBancariaModel { get; set; }
    }
}
