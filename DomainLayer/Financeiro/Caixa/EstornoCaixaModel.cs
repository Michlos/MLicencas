using System;

namespace DomainLayer.Financeiro.Caixa
{
    public class EstornoCaixaModel : IEstornoCaixaModel
    {
        public int Id { get; set; }
        public int LancamentoCaixaId { get; set; }
        public virtual LancamentoCaixaModel LancamentoCaixa { get; set; }
        public int TipoLancamentoId { get; set; }
        public virtual TipoLancamentoModel TipoLancamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public double Valor { get; set; }

    }
}
