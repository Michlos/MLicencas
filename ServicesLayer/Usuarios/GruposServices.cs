using DomainLayer.Usuarios;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Usuarios
{
    public class GruposServices : IGruposRepository, IGruposServices
    {
        private IGruposRepository _grupoRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public GruposServices(IGruposRepository grupoRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _grupoRepository = grupoRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IGrupoModel Add(IGrupoModel grupo)
        {
            return _grupoRepository.Add(grupo);
        }

        public void Edit(IGrupoModel grupo)
        {
            _grupoRepository.Edit(grupo);
        }

        public IEnumerable<IGrupoModel> GetAll()
        {
            return _grupoRepository.GetAll();
        }

        public IGrupoModel GetById(int grupoId)
        {
            return _grupoRepository.GetById(grupoId);
        }

        public void ValidateModel(IGrupoModel grupo)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(grupo);
        }
    }
}
