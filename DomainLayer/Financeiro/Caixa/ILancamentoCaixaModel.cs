using System;

namespace DomainLayer.Financeiro.Caixa
{
    public interface ILancamentoCaixaModel
    {
        int CaixaId { get; set; }
        DateTime DataLancamento { get; set; }
        string Historico { get; set; }
        int Id { get; set; }
        int TipoLancamentoId { get; set; }
        double Valor { get; set; }
        bool Estornado { get; set; }
    }
}