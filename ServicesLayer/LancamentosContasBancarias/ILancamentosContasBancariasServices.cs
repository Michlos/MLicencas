using DomainLayer.Financeiro.Bancos.ContaBancaria;

namespace ServicesLayer.LancamentosContasBancarias
{
    public interface ILancamentosContasBancariasServices
    {
        void ValidateModel(ILancamentoContaBancariaModel lancamento);
    }
}
