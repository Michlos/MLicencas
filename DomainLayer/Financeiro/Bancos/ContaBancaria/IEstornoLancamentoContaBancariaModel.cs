using System;

namespace DomainLayer.Financeiro.Bancos.ContaBancaria
{
    public interface IEstornoLancamentoContaBancariaModel
    {
        DateTime DataRegistro { get; set; }
        int Id { get; set; }
        int LancamentoId { get; set; }
        int TipoLancamentoId { get; set; }
        double Valor { get; set; }
    }
}