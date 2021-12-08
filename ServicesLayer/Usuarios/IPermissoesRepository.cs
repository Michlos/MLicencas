using DomainLayer.Usuarios;

namespace ServicesLayer.Usuarios
{
    public interface IPermissoesRepository
    {
        IPermissaoModel Add(IPermissaoModel permissao);
        void Enable(int permissaoId);
        void Desable(int permissaoId);
        bool GetPermissao(IPermissaoModel permissao);


    }
}
