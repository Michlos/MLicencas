using System;

namespace DomainLayer.Financeiro.Caixa
{
    public interface IEstornoCaixaModel
    {
        DateTime DataRegistro { get; set; }
        int Id { get; set; }
        int LancamentoCaixaId { get; set; }
        int TipoLancamentoId { get; set; }
        double Valor { get; set; }
    }
}