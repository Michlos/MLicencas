using DomainLayer.Usuarios;

using System.Collections;
using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public interface IPermissoesRepository
    {
        IPermissaoModel Add(IPermissaoModel permissao);
        void Enable(int permissaoId);
        void Desable(int permissaoId);
        bool GetPermissao(IPermissaoModel permissao);
        IEnumerable<IPermissaoModel> GetAll();
        IEnumerable<IPermissaoModel> GetAllByGrupo(int grupoId);

    }
}
