using DomainLayer.Usuarios;

namespace ServicesLayer.Usuarios
{
    public interface IPermissoesServices
    {
        void ValidateModel(IPermissaoModel permissao);
    }
}
