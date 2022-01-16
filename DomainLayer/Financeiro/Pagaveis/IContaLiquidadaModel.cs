using System;

namespace DomainLayer.Financeiro.Pagaveis
{
    public interface IContaLiquidadaModel
    {
        int ContaPagarId { get; set; }
        ContaPagarModel ContaPagarModel { get; set; }
        DateTime DataRegistro { get; set; }
        bool Estornado { get; set; }
        string Historico { get; set; }
        int Id { get; set; }
        bool Integracao { get; set; }
        int OrigemPagamentoId { get; set; }
        double Valor { get; set; }
        double ValorPago { get; set; }
        DateTime DataPagamento { get; set; }
    }
}