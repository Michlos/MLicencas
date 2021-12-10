using DomainLayer.Clientes;

using System.Collections.Generic;

namespace ServicesLayer.ClientesServices
{
    public interface IClientesRepository
    {
        IClienteModel Add(IClienteModel clienteModel);
        IClienteModel GetById(int clienteId);
        void Edid(IClienteModel clienteModel);
        IEnumerable<IClienteModel> GetAll();
        IEnumerable<IClienteModel> GetAllBySituacaoId(int situacaoId);
    }
}
