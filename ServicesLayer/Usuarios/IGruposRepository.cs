using DomainLayer.Usuarios;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public interface IGruposRepository
    {
        IGrupoModel Add(IGrupoModel grupo);
        void Edit(IGrupoModel grupo);
        IGrupoModel GetById(int grupoId);
        IEnumerable<IGrupoModel> GetAll();
    }
}
