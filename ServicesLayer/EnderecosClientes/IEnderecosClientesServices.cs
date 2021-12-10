using DomainLayer.Clientes.Enderecos;

namespace ServicesLayer.EnderecosClientes
{
    public interface IEnderecosClientesServices
    {
        void ValidateModel(IEnderecoClienteModel enderecoModel);
    }
}
