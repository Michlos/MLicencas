using DomainLayer.Clientes.Contatos;

using System.Collections.Generic;

namespace ServicesLayer.ContatosClientes
{
    public interface IContatosClientesRepository
    {
        IContatoClienteModel Add(IContatoClienteModel contatoClienteModel);
        void Edit(IContatoClienteModel contatoClienteModel);
        void Delete(int contatoId);
        IEnumerable<IContatoClienteModel> GetAll();
        IEnumerable<IContatoClienteModel> GetAllByClienteId(int clienteId);
        IContatoClienteModel GetById(int contatoId);


    }
}
