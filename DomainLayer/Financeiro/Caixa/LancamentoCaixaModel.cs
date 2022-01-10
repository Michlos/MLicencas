using System;

namespace DomainLayer.Financeiro.Caixa
{
    public class LancamentoCaixaModel : ILancamentoCaixaModel
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public virtual CaixaModel Caixa { get; set; }
        public int TipoLancamentoId { get; set; }
        public virtual TipoLancamentoModel TipoLancamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public double Valor { get; set; }

        //SE VEM DO BANCO OU DE RECEBIMENTO DE TÍTULO
        public string Historico { get; set; }

    }
}
