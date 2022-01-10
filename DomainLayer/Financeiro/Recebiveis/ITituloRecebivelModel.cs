using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public interface ITituloRecebivelModel
    {
        int ClienteId { get; set; }
        int CodigoBaixaId { get; set; }
        int CodigoJurosMoraId { get; set; }
        int CodigoProtestoId { get; set; }
        int ContratoId { get; set; }
        DateTime DataJurosMora { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime DataVencimento { get; set; }
        int DiasParaBaixa { get; set; }
        int DiasParaProtesto { get; set; }
        int Id { get; set; }
        int Parcela { get; set; }
        int TotalParcelas { get; set; }
        double ValorParcela { get; set; }
    }
}