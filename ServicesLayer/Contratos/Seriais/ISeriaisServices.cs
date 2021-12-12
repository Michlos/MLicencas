using DomainLayer.Clientes.Contratos.Seriais;

namespace ServicesLayer.Seriais
{
    public interface ISeriaisServices
    {
        void ValidateModel(ISerialModel serial);
    }
}
