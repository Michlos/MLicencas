using DomainLayer.Clientes.Contatos;

namespace ServicesLayer.ContatosClientes
{
    public interface IContatosClientesServices
    {
        void ValidateModel(IContatoClienteModel contatoClienteModel);
    }
}
