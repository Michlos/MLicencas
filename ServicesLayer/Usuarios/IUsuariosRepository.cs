using DomainLayer.Usuarios;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public interface IUsuariosRepository
    {
        IUsuarioModel Add(IUsuarioModel usuario);
        void Edit(IUsuarioModel usuario);
        IUsuarioModel GetByLogin(string login);
        IEnumerable<IUsuarioModel> GetAll();
        bool CheckLogin(string usuario, string senha);
        


    }
}
