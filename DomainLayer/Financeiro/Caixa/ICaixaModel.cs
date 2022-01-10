using System;

namespace DomainLayer.Financeiro.Caixa
{
    public interface ICaixaModel
    {
        DateTime DataAbertura { get; set; }
        DateTime? DataFechamento { get; set; }
        int Id { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoFinal { get; set; }
    }
}