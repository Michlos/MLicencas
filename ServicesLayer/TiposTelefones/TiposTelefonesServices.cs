using DomainLayer.Telefones;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TiposTelefones
{
    public class TiposTelefonesServices : ITiposTelefonesRepository, ITiposTelefonesServices
    {
        private ITiposTelefonesRepository _tiposTelefonesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TiposTelefonesServices(ITiposTelefonesRepository tiposTelefonesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tiposTelefonesRepository = tiposTelefonesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoTelefoneModel> GetAll()
        {
            return _tiposTelefonesRepository.GetAll();
        }

        public ITipoTelefoneModel GetById(int tipoId)
        {
            return _tiposTelefonesRepository.GetById(tipoId);
        }

        public void ValidateModel(ITipoTelefoneModel tipoTelefoneModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoTelefoneModel);
        }
    }
}
