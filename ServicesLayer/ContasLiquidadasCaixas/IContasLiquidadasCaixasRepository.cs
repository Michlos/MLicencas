using DomainLayer.Financeiro.Pagaveis;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadasCaixas
{
    public interface IContasLiquidadasCaixasRepository
    {
        IContaLiquidadaCaixaModel Add(IContaLiquidadaCaixaModel model);
        void Remove(int id);
        IEnumerable<IContaLiquidadaCaixaModel> GetAll();
        IContaLiquidadaCaixaModel GetById(int id);
        IContaLiquidadaCaixaModel GetByContaLiquidada(int id);
        IContaLiquidadaCaixaModel GetByLancamentoCaixa(int id);
    }
}
