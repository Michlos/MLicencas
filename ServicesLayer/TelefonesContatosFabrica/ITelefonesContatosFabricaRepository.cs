using DomainLayer.Fabrica;

using System.Collections.Generic;

namespace ServicesLayer.TelefonesContatosFabricaServices
{
    public interface ITelefonesContatosFabricaRepository
    {
        ITelefoneContatoFabricaModel Add(ITelefoneContatoFabricaModel telefone);
        void Edit(ITelefoneContatoFabricaModel telefone);
        void Delete(int telefoneId);
        IEnumerable<ITelefoneContatoFabricaModel> GetAll();
        IEnumerable<ITelefoneContatoFabricaModel> GetAllByContatoId(int contatoId);
        ITelefoneContatoFabricaModel GetById(int telefoneId);
    }
}
