using DomainLayer.Financeiro;

using System.Collections.Generic;

namespace ServicesLayer.Bancos
{
    public interface IBancosRepository
    {
        IBancoModel Add(IBancoModel bancoModel);
        void Edit(IBancoModel bancoModel);
        void Remove(int bancoId);
        IBancoModel GetById(int bancoId);
        IEnumerable<IBancoModel> GetAll();
    }
}
