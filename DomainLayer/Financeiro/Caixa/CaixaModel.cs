using System;

namespace DomainLayer.Financeiro.Caixa
{
    public class CaixaModel : ICaixaModel
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFechamento { get; set; }
        public double SaldoAnterior { get; set; }
        public double SaldoFinal { get; set; }

    }
}
