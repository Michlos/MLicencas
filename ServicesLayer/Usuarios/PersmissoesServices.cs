using DomainLayer.Usuarios;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public class PersmissoesServices : IPermissoesRepository, IPermissoesServices
    {
        private IPermissoesRepository _permissoesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public PersmissoesServices(IPermissoesRepository permissoesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _permissoesRepository = permissoesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IPermissaoModel Add(IPermissaoModel permissao)
        {
            return _permissoesRepository.Add(permissao);
        }

        public void Desable(int permissaoId)
        {
            _permissoesRepository.Desable(permissaoId);
        }

        public void Enable(int permissaoId)
        {
            _permissoesRepository.Enable(permissaoId);
        }

        public IEnumerable<IPermissaoModel> GetAll()
        {
            return _permissoesRepository.GetAll();
        }

        public IEnumerable<IPermissaoModel> GetAllByGrupo(int grupoId)
        {
            return _permissoesRepository.GetAllByGrupo(grupoId);
        }

        public bool GetPermissao(IPermissaoModel permissao)
        {
            return _permissoesRepository.GetPermissao(permissao);
        }

        public void ValidateModel(IPermissaoModel permissao)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(permissao);
        }
    }
}
