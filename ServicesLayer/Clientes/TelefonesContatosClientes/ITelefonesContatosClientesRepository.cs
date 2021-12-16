using DomainLayer.Clientes.Telefones;

using System.Collections.Generic;

namespace ServicesLayer.TelefonesContatosClientes
{
    public interface ITelefonesContatosClientesRepository
    {
        ITelefoneContatoClienteModel Add(ITelefoneContatoClienteModel telefoneModel);
        void Edit(ITelefoneContatoClienteModel telefoneModel);
        void Delete(int telefoneId);
        IEnumerable<ITelefoneContatoClienteModel> GetAll();
        IEnumerable<ITelefoneContatoClienteModel> GetAllByContatoId(int contatoId);
        ITelefoneContatoClienteModel GetById(int telefoneId);
    }
}
