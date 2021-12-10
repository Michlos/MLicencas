using DomainLayer.Softwares.Plataformas;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Plataformas
{
    public class PlataformasServices : IPlataformasRepository, IPlataformasServices
    {
        private IPlataformasRepository _plataformasRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public PlataformasServices(IPlataformasRepository plataformasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _plataformasRepository = plataformasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IPlataformaModel Add(IPlataformaModel plataforma)
        {
            return _plataformasRepository.Add(plataforma);
        }

        public void Edit(IPlataformaModel plataforma)
        {
            _plataformasRepository.Edit(plataforma);
        }

        public IEnumerable<IPlataformaModel> GetAll()
        {
            return _plataformasRepository.GetAll();
        }

        public IPlataformaModel GetById(int plataformaId)
        {
            return _plataformasRepository.GetById(plataformaId);
        }

        public void ValidateModel(IPlataformaModel plataforma)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(plataforma);
        }
    }
}
