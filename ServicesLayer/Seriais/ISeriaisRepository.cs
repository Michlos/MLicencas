using DomainLayer.Clientes.Contratos.Seriais;

namespace ServicesLayer.Seriais
{
    public interface ISeriaisRepository
    {
        ISerialModel Add(ISerialModel serial);
        ISerialModel Renew(ISerialModel serial);
        void UnloadHash(int serialId);
        string GenSerial(ISerialModel serial);
        string GenHashCliente(ISerialModel serial);
        string GenHashChave(ISerialModel serial);
    }
}
