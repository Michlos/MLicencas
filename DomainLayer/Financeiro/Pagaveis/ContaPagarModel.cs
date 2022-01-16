using System;

namespace DomainLayer.Financeiro.Pagaveis
{
    public class ContaPagarModel : IContaPagarModel
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataVencimento { get; set; }
        public double Valor { get; set; }
        public string Historico { get; set; }
        public long CodigoBarrasDigitavel { get; set; }
        public bool Liquidado { get; set; }

    }
}
