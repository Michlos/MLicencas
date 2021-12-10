using DomainLayer.Clientes.Enderecos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.EnderecosClientes
{
    public class EnderecosClientesServices : IEnderecosClientesRepository, IEnderecosClientesServices
    {
        private IEnderecosClientesRepository _enderecosClientesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EnderecosClientesServices(IEnderecosClientesRepository enderecosClientesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _enderecosClientesRepository = enderecosClientesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnderecoClienteModel Add(IEnderecoClienteModel enderecoModel)
        {
            return _enderecosClientesRepository.Add(enderecoModel);
        }

        public void Delete(int enderecoId)
        {
            _enderecosClientesRepository.Delete(enderecoId);
        }

        public void Edit(IEnderecoClienteModel enderecoModel)
        {
            _enderecosClientesRepository.Edit(enderecoModel);
        }

        public IEnumerable<IEnderecoClienteModel> GetAll()
        {
            return _enderecosClientesRepository.GetAll();
        }

        public IEnumerable<IEnderecoClienteModel> GetAllByClienteId(int clienteId)
        {
            return _enderecosClientesRepository.GetAllByClienteId(clienteId);
        }

        public IEnderecoClienteModel GetById(int enderecoId)
        {
            return _enderecosClientesRepository.GetById(enderecoId);
        }

        public void ValidateModel(IEnderecoClienteModel enderecoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(enderecoModel);
        }
    }
}
