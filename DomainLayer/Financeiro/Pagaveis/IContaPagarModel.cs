using System;

namespace DomainLayer.Financeiro.Pagaveis
{
    public interface IContaPagarModel
    {
        long CodigoBarrasDigitavel { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime DataVencimento { get; set; }
        string Historico { get; set; }
        int Id { get; set; }
        bool Liquidado { get; set; }
        double Valor { get; set; }
    }
}