using DomainLayer.Financeiro;

using System.Collections.Generic;

namespace ServicesLayer.ContasBancarias
{
    public interface IContasBancariasRepository
    {
        IContaBancariaModel Add(IContaBancariaModel contaModel);
        void Edit(IContaBancariaModel contaModel);
        void Remove(int contaId);
        IEnumerable<IContaBancariaModel> GetAll();
        IEnumerable<IContaBancariaModel> GetAllByBancoId(int bancoId);
        IContaBancariaModel GetById(int contaId);
    }
}
