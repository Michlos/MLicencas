using DomainLayer.Usuarios;

using ServicesLayer.Usuarios;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Usuarios
{
    public class PermissaoRepository : IPermissoesRepository
    {
        private string _connectionString;
        private IPermissaoModel permissaoModel;


        public PermissaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IPermissaoModel Add(IPermissaoModel permissao)
        {
            throw new NotImplementedException();
        }

        public void Desable(int permissaoId)
        {
            throw new NotImplementedException();
        }

        public void Enable(int permissaoId)
        {
            throw new NotImplementedException();
        }

        public bool GetPermissao(IPermissaoModel permissao)
        {
            throw new NotImplementedException();
        }
    }
}
