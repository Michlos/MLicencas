using DomainLayer.Financeiro.Pagaveis;

using System.Collections.Generic;

namespace ServicesLayer.ContasPagar
{
    public interface IContasPagarRepository
    {
        IContaPagarModel Add(IContaPagarModel contaPagarModel);
        void Edit(IContaPagarModel contaPagarModel);
        void Remove(int contaId);
        IContaPagarModel GetById(int contaId);
        IEnumerable<IContaPagarModel> GetAll();
    }
}
