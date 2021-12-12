using DomainLayer.Enderecos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TiposEnderecos
{
    public class TiposEnderecosServices : ITiposEnderecosRepository, ITiposEnderecosServices
    {
        private ITiposEnderecosRepository _tiposEnderecosRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TiposEnderecosServices(ITiposEnderecosRepository tiposEnderecosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tiposEnderecosRepository = tiposEnderecosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoEnderecoModel> GetAll()
        {
            return _tiposEnderecosRepository.GetAll();
        }

        public ITipoEnderecoModel GetById(int id)
        {
            return _tiposEnderecosRepository.GetById(id);
        }

        public void ValidateModel(ITipoEnderecoModel tipoEnderecoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoEnderecoModel);
        }
    }
}
