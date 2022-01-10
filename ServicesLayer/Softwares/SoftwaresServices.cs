using DomainLayer.Softwares;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Softwares
{
    public class SoftwaresServices : ISoftwaresRepository, ISoftwaresServices
    {
        private readonly ISoftwaresRepository _softwareRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public SoftwaresServices(ISoftwaresRepository softwareRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _softwareRepository = softwareRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ISoftwareModel Add(ISoftwareModel software)
        {
            return _softwareRepository.Add(software);
        }

        public void Edit(ISoftwareModel software)
        {
            _softwareRepository.Edit(software);
        }

        public IEnumerable<ISoftwareModel> GetAll()
        {
            return _softwareRepository.GetAll();
        }

        public ISoftwareModel GetById(int softwareId)
        {
            return _softwareRepository.GetById(softwareId);
        }

        public void ValidateModel(ISoftwareModel software)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(software);
        }
    }
}
