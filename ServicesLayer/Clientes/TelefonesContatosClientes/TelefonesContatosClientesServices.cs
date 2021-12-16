using DomainLayer.Clientes.Telefones;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TelefonesContatosClientes
{
    public class TelefonesContatosClientesServices : ITelefonesContatosClientesRepository, ITelefonesContatosClientesServices
    {
        private ITelefonesContatosClientesRepository _telefonesContatosClientesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TelefonesContatosClientesServices(ITelefonesContatosClientesRepository telefonesContatosClientesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _telefonesContatosClientesRepository = telefonesContatosClientesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ITelefoneContatoClienteModel Add(ITelefoneContatoClienteModel telefoneModel)
        {
            return _telefonesContatosClientesRepository.Add(telefoneModel);
        }

        public void Delete(int telefoneId)
        {
            _telefonesContatosClientesRepository.Delete(telefoneId);
        }

        public void Edit(ITelefoneContatoClienteModel telefoneModel)
        {
            _telefonesContatosClientesRepository.Edit(telefoneModel);
        }

        public IEnumerable<ITelefoneContatoClienteModel> GetAll()
        {
            return _telefonesContatosClientesRepository.GetAll();
        }

        public IEnumerable<ITelefoneContatoClienteModel> GetAllByContatoId(int contatoId)
        {
            return _telefonesContatosClientesRepository.GetAllByContatoId(contatoId);
        }

        public ITelefoneContatoClienteModel GetById(int telefoneId)
        {
            return _telefonesContatosClientesRepository.GetById(telefoneId);
        }

        public void ValidateModel(ITelefoneContatoClienteModel telefoneModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telefoneModel);
        }
    }
}
