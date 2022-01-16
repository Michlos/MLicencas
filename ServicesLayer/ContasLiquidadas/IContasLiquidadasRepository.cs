using DomainLayer.Financeiro.Pagaveis;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadas
{
    public interface IContasLiquidadasRepository
    {
        IContaLiquidadaModel Add(IContaLiquidadaModel contaModel);
        void Estornar(IContaLiquidadaModel contaModel);
        IContaLiquidadaModel GetById(int contaId);
        IEnumerable<IContaLiquidadaModel> GetByContaPagarId(int contaPagarId);
        IEnumerable<IContaLiquidadaModel> GetAll();
        void Remove(int contaId);
    }
}
