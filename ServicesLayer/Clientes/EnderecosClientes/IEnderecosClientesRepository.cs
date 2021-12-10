using DomainLayer.Clientes.Enderecos;

using System.Collections.Generic;

namespace ServicesLayer.EnderecosClientes
{
    public interface IEnderecosClientesRepository
    {
        IEnderecoClienteModel Add(IEnderecoClienteModel enderecoModel);
        void Edit(IEnderecoClienteModel enderecoModel);
        void Delete(int enderecoId);
        IEnumerable<IEnderecoClienteModel> GetAll();
        IEnumerable<IEnderecoClienteModel> GetAllByClienteId(int clienteId);
        IEnderecoClienteModel GetById(int enderecoId);

    }
}
