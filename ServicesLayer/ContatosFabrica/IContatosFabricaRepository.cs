using DomainLayer.Fabrica;

using System.Collections.Generic;

namespace ServicesLayer.ContatosFabricaServices
{
    public interface IContatosFabricaRepository
    {
        IContatoFabricaModel Add(IContatoFabricaModel contatoFabrica);
        void Edit(IContatoFabricaModel contatoFabrica);
        void Delete(int contatoId);
        IEnumerable<IContatoFabricaModel> GetAll();
        IContatoFabricaModel GetById(int contatoId);

    }
}
