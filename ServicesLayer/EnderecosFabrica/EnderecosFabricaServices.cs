using DomainLayer.Fabrica;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.EnderecosFabricaServices
{
    public class EnderecosFabricaServices : IEnderecosFabricaRepository, IEnderecosFabricaServices
    {
        private IEnderecosFabricaRepository _enderecosFabricaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EnderecosFabricaServices(IEnderecosFabricaRepository enderecosFabricaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _enderecosFabricaRepository = enderecosFabricaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnderecoFabricaModel Add(IEnderecoFabricaModel endereco)
        {
            return _enderecosFabricaRepository.Add(endereco);
        }

        public void Edit(IEnderecoFabricaModel endereco)
        {
            _enderecosFabricaRepository.Edit(endereco);
        }

        public IEnumerable<IEnderecoFabricaModel> GetAll()
        {
            return _enderecosFabricaRepository.GetAll();
        }

        public IEnderecoFabricaModel GetById(int enderecoId)
        {
            return _enderecosFabricaRepository.GetById(enderecoId);
        }

        public void ValidateModel(IEnderecoFabricaModel enderecoFabrica)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(enderecoFabrica);
        }
    }
}
