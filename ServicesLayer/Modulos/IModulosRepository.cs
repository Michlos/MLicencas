using DomainLayer.Modulos;

using System.Collections.Generic;

namespace ServicesLayer.Modulos
{
    public interface IModulosRepository
    {
        IModuloModel Add(IModuloModel modulo);
        IModuloModel Edit(IModuloModel modulo);
        IModuloModel GetById(int moduloId);
        IEnumerable<IModuloModel> GetAll();
        IModuloModel GetByHieraquia(string nivel);
    }
}
