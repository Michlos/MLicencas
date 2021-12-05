using DomainLayer.Usuarios;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public interface IUsuariosRepository
    {
        IUsuarioModel Add(IUsuarioModel usuario);
        void Edit(IUsuarioModel usuario);
        IEnumerable<IUsuarioModel> GetAll();


    }
}
