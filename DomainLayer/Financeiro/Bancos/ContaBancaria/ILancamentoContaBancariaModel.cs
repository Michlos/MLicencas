using System;

namespace DomainLayer.Financeiro.Bancos.ContaBancaria
{
    public interface ILancamentoContaBancariaModel
    {
        ContaBancariaModel ContaBancaria { get; set; }
        int ContaId { get; set; }
        DateTime DataLancamento { get; set; }
        string Historico { get; set; }
        int Id { get; set; }
        TipoLancamentoModel TipoLancamento { get; set; }
        int TipoLancamentoId { get; set; }
        double Valor { get; set; }
    }
}