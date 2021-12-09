using DomainLayer.Enderecos;

using System.Collections.Generic;

namespace ServicesLayer.Estados
{
    public interface IEstadosRepository
    {
        IEnumerable<IEstadoModel> GetAll();
        IEstadoModel GetById(int estadoId);
        IEstadoModel GetByUf(string uf);

    }
}
