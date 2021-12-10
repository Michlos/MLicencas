using DomainLayer.Clientes.Contatos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContatosClientes
{
    public class ContatosClientesServices : IContatosClientesRepository, IContatosClientesServices
    {
        private IContatosClientesRepository _contatosClientesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContatosClientesServices(IContatosClientesRepository contatosClientesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contatosClientesRepository = contatosClientesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContatoClienteModel Add(IContatoClienteModel contatoClienteModel)
        {
            return _contatosClientesRepository.Add(contatoClienteModel);
        }

        public void Delete(int contatoId)
        {
            _contatosClientesRepository.Delete(contatoId);
        }

        public void Edit(IContatoClienteModel contatoClienteModel)
        {
            _contatosClientesRepository.Edit(contatoClienteModel);
        }

        public IEnumerable<IContatoClienteModel> GetAll()
        {
            return _contatosClientesRepository.GetAll();
        }

        public IEnumerable<IContatoClienteModel> GetAllByClienteId(int clienteId)
        {
            return _contatosClientesRepository.GetAllByClienteId(clienteId);
        }

        public IContatoClienteModel GetById(int contatoId)
        {
            return _contatosClientesRepository.GetById(contatoId);
        }

        public void ValidateModel(IContatoClienteModel contatoClienteModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contatoClienteModel);
        }
    }
}
