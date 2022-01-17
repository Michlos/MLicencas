using DomainLayer.Financeiro.Caixa;

namespace DomainLayer.Financeiro.Pagaveis
{
    public class ContaLiquidadaCaixaModel : IContaLiquidadaCaixaModel
    {
        public int Id { get; set; }
        public int ContaLiquidadaId { get; set; }
        public virtual ContaLiquidadaModel ContaLiquidadaModel { get; set; }
        public int LancamentoCaixaId { get; set; }
        public virtual LancamentoCaixaModel LancamentoCaixaModel { get; set; }
    }
}
