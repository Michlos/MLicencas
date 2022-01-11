using DomainLayer.Financeiro.Bancos.ContaBancaria;

namespace ServicesLayer.EstornosContasBancarias
{
    public interface IEstornosLancamentosContasBancariasServices
    {
        void ValidateModel(IEstornoLancamentoContaBancariaModel estornoModel);
    }
}
