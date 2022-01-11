using System;

namespace DomainLayer.Financeiro.Bancos.ContaBancaria
{
    public class EstornoLancamentoContaBancariaModel : IEstornoLancamentoContaBancariaModel
    {
        public int Id { get; set; }
        public int LancamentoId { get; set; }
        public virtual LancamentoContaBancariaModel LancamentoContaBancaria { get; set; }
        public int TipoLancamentoId { get; set; }
        public virtual TipoLancamentoModel TipoLancamento { get; set; }
        public DateTime DataRegistro { get; set; }
        public double Valor { get; set; }

    }
}
