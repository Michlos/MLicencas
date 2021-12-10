using DomainLayer.Softwares.SistemasOperacionais;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.SistemasOperacionais
{
    public class SistemasOperacionaisServices : ISistemasOperacionaisRepository, ISistemasOperacionaisServices
    {
        private ISistemasOperacionaisRepository _sistemasOperacionaisRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public SistemasOperacionaisServices(ISistemasOperacionaisRepository sistemasOperacionaisRepository, 
                                            IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _sistemasOperacionaisRepository = sistemasOperacionaisRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ISistemaOperacionalModel Add(ISistemaOperacionalModel osModel)
        {
            return _sistemasOperacionaisRepository.Add(osModel);
        }

        public void Edit(ISistemaOperacionalModel osModel)
        {
            _sistemasOperacionaisRepository.Edit(osModel);
        }

        public IEnumerable<ISistemaOperacionalModel> GetAll()
        {
            return _sistemasOperacionaisRepository.GetAll();
        }

        public ISistemaOperacionalModel GetById(int osId)
        {
            return _sistemasOperacionaisRepository.GetById(osId);
        }

        public void ValidateModel(ISistemaOperacionalModel osModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(osModel);
        }
    }
}
