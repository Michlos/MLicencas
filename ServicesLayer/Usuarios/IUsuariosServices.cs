using DomainLayer.Usuarios;

namespace ServicesLayer.Usuarios
{
    public interface IUsuariosServices
    {
        void ValidateModel(IUsuarioModel usuario);
    }
}
