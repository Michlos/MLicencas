using System;

namespace DomainLayer.Financeiro.Pagaveis
{
    public class ContaLiquidadaModel : IContaLiquidadaModel
    {
        public int Id { get; set; }
        public int ContaPagarId { get; set; }
        public virtual ContaPagarModel ContaPagarModel { get; set; }
        public int OrigemPagamentoId { get; set; }
        public virtual OrigemPagamentoModel OrigemPagamentoModel { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public double ValorPago { get; set; }
        public string Historico { get; set; }
        public bool Estornado { get; set; }
        public bool Integracao { get; set; }

    }
}
