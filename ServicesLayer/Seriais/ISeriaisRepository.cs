using DomainLayer.Clientes.Contratos.Seriais;

using System.Collections.Generic;

namespace ServicesLayer.Seriais
{
    public interface ISeriaisRepository
    {
        ISerialModel Add(ISerialModel serial);
        ISerialModel Renew(ISerialModel serial);
        void UnloadHash(int serialId);
        ISerialModel GetById(int serialId);
        ISerialModel GetByContratoId(int contratoId);
        IEnumerable<ISerialModel> GetAllByClienteId(int clienteId);
        IEnumerable<ISerialModel> GetAll();
    }
}
