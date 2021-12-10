using DomainLayer.Clientes;

namespace ServicesLayer.ClientesServices
{
    public interface IClientesServices
    {
        void ValidateModel(IClienteModel clienteModel);
    }
}
