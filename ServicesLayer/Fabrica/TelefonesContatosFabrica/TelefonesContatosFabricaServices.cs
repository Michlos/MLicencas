using DomainLayer.Fabrica;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TelefonesContatosFabricaServices
{
    public class TelefonesContatosFabricaServices : ITelefonesContatosFabricaRepository, ITelefonesContatosFabricaServices
    {
        private ITelefonesContatosFabricaRepository _telefonesContatosFabricaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TelefonesContatosFabricaServices(ITelefonesContatosFabricaRepository telefonesContatosFabricaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _telefonesContatosFabricaRepository = telefonesContatosFabricaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ITelefoneContatoFabricaModel Add(ITelefoneContatoFabricaModel telefone)
        {
            return _telefonesContatosFabricaRepository.Add(telefone);
        }

        public void Delete(int telefoneId)
        {
            _telefonesContatosFabricaRepository.Delete(telefoneId);
        }

        public void Edit(ITelefoneContatoFabricaModel telefone)
        {
            _telefonesContatosFabricaRepository.Edit(telefone);
        }

        public IEnumerable<ITelefoneContatoFabricaModel> GetAll()
        {
            return _telefonesContatosFabricaRepository.GetAll();
        }

        public IEnumerable<ITelefoneContatoFabricaModel> GetAllByContatoId(int contatoId)
        {
            return _telefonesContatosFabricaRepository.GetAllByContatoId(contatoId);
        }

        public ITelefoneContatoFabricaModel GetById(int telefoneId)
        {
            return _telefonesContatosFabricaRepository.GetById(telefoneId);
        }

        public void ValidateModel(ITelefoneContatoFabricaModel telefone)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(telefone);
        }
    }
}
