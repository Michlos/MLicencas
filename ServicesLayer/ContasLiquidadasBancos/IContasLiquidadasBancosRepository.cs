using DomainLayer.Financeiro.Pagaveis;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadasBancos
{
    public interface IContasLiquidadasBancosRepository
    {
        IContaLiquidadaBancoModel Add(IContaLiquidadaBancoModel contaLiquidadaBancoModel);
        void Remove(int id);
        IEnumerable<IContaLiquidadaBancoModel> GetAll();
        IContaLiquidadaBancoModel GetById(int id);
        IContaLiquidadaBancoModel GetByContaLiquidadaId(int id);
        IContaLiquidadaBancoModel GetByLancamentoBancarioId(int id);

    }
}
