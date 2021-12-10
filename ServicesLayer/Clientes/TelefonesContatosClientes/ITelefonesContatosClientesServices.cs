using DomainLayer.Clientes.Telefones;

namespace ServicesLayer.TelefonesContatosClientes
{
    public interface ITelefonesContatosClientesServices
    {
        void ValidateModel(ITelefoneContatoClienteModel telefoneModel);
    }
}
