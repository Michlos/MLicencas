using DomainLayer.Clientes;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ClientesServices
{
    public class ClientesServices : IClientesRepository, IClientesServices
    {
        private IClientesRepository _clientesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ClientesServices(IClientesRepository clientesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _clientesRepository = clientesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IClienteModel Add(IClienteModel clienteModel)
        {
            return _clientesRepository.Add(clienteModel);
        }

        public void Edit(IClienteModel clienteModel)
        {
            _clientesRepository.Edit(clienteModel);
        }

        public IEnumerable<IClienteModel> GetAll()
        {
            return _clientesRepository.GetAll();
        }

        public IEnumerable<IClienteModel> GetAllBySituacaoId(int situacaoId)
        {
            return _clientesRepository.GetAllBySituacaoId(situacaoId);
        }

        public IClienteModel GetById(int clienteId)
        {
            return _clientesRepository.GetById(clienteId);
        }

        public void ValidateModel(IClienteModel clienteModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(clienteModel);
        }
    }
}
