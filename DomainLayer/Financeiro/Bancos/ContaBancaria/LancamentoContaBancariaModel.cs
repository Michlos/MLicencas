using System;

namespace DomainLayer.Financeiro.Bancos.ContaBancaria
{
    public class LancamentoContaBancariaModel : ILancamentoContaBancariaModel
    {
        public int Id { get; set; }
        public int ContaId { get; set; }
        public virtual ContaBancariaModel ContaBancaria { get; set; }
        public int TipoLancamentoId { get; set; }
        public virtual TipoLancamentoModel TipoLancamento { get; set; }
        public DateTime DataLancamento { get; set; }
        public double Valor { get; set; }

        //DEVE CONTER A ORIGEM DO LANÇAMENTO
        //SE VEIO DO CAIXA (LANÇAMENTOID) SE VEIO DE PAGAMENTO DE BOLETO (TITULOID)
        public string Historico { get; set; } 

    }
}
