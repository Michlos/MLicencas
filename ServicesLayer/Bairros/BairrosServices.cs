using DomainLayer.Enderecos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Bairros
{
    public class BairrosServices : IBairrosRepository, IBairrosServices
    {
        private IBairrosRepository _bairrosRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public BairrosServices(IBairrosRepository bairrosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _bairrosRepository = bairrosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IBairroModel Add(IBairroModel bairroModel)
        {
            return _bairrosRepository.Add(bairroModel);
        }

        public void Edit(IBairroModel bairroModel)
        {
            _bairrosRepository.Edit(bairroModel);
        }

        public IEnumerable<IBairroModel> GetAll()
        {
            return _bairrosRepository.GetAll();
        }

        public IEnumerable<IBairroModel> GetAllByCidadeId(int cidadeId)
        {
            return _bairrosRepository.GetAllByCidadeId(cidadeId);
        }

        public IBairroModel GetById(int bairroId)
        {
            return _bairrosRepository.GetById(bairroId);
        }

        public void ValidateModel(IBairroModel bairroModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(bairroModel);
        }
    }
}
