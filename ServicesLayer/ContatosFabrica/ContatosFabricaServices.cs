using DomainLayer.Fabrica;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContatosFabricaServices
{
    public class ContatosFabricaServices : IContatosFabricaRepository, IContatosFabricaServices
    {
        private IContatosFabricaRepository _contatosFabricaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContatosFabricaServices(IContatosFabricaRepository contatosFabricaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contatosFabricaRepository = contatosFabricaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContatoFabricaModel Add(IContatoFabricaModel contatoFabrica)
        {
            return _contatosFabricaRepository.Add(contatoFabrica);
        }

        public void Delete(int contatoId)
        {
            _contatosFabricaRepository.Delete(contatoId);
        }

        public void Edit(IContatoFabricaModel contatoFabrica)
        {
            _contatosFabricaRepository.Edit(contatoFabrica);
        }

        public IEnumerable<IContatoFabricaModel> GetAll()
        {
            return _contatosFabricaRepository.GetAll();
        }

        public IContatoFabricaModel GetById(int contatoId)
        {
            return _contatosFabricaRepository.GetById(contatoId);
        }

        public void ValidateModel(IContatoFabricaModel contatoFabrica)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contatoFabrica);
        }
    }
}
