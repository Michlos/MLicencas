using DomainLayer.Enderecos;

using System.Collections.Generic;

namespace ServicesLayer.Bairros
{
    public interface IBairrosRepository
    {
        IEnumerable<IBairroModel> GetAll();
        IEnumerable<IBairroModel> GetAllByCidadeId(int cidadeId);
        IBairroModel GetById(int bairroId);
        IBairroModel Add(IBairroModel bairroModel);
        void Edit(IBairroModel bairroModel);
    }
}
