using DomainLayer.Enderecos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Cidades
{
    public class CidadesServices : ICidadesRepository, ICidadesServices
    {
        private ICidadesRepository _cidadesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CidadesServices(ICidadesRepository cidadesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _cidadesRepository = cidadesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ICidadeModel> GetAll()
        {
            return _cidadesRepository.GetAll();
        }

        public IEnumerable<ICidadeModel> GetAllByUf(string uf)
        {
            return _cidadesRepository.GetAllByUf(uf);
        }

        public IEnumerable<ICidadeModel> GetAllByUfId(int ufId)
        {
            return _cidadesRepository.GetAllByUfId(ufId);
        }

        public ICidadeModel GetById(int cidadeId)
        {
            return _cidadesRepository.GetById(cidadeId);
        }

        public void ValidateModel(ICidadeModel cidadeModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(cidadeModel);
        }
    }
}
