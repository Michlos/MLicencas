using DomainLayer.Financeiro.Bancos.ContaBancaria;

using System.Collections.Generic;

namespace ServicesLayer.EstornosContasBancarias
{
    public interface IEstornosLancamentosContasBancariasRepository
    {
        IEstornoLancamentoContaBancariaModel Add(IEstornoLancamentoContaBancariaModel estornoModel);
        void Remove(int estornoId);
        IEnumerable<IEstornoLancamentoContaBancariaModel> GetAll();
        IEstornoLancamentoContaBancariaModel GetById(int estornoId);
        IEstornoLancamentoContaBancariaModel GetByLancamentoId(int lancamentoId);
    }
}
