using DomainLayer.Financeiro.Recebiveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.DestinosRecebimentos
{
    public class DestinosRecebiveisServices : IDestinosRecebiveisRepository, IDestinosRecebiveisServices
    {
        private readonly IDestinosRecebiveisRepository _destinosRecebiveisRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public DestinosRecebiveisServices(IDestinosRecebiveisRepository destinosRecebiveisRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _destinosRecebiveisRepository = destinosRecebiveisRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IDestinoRecebivelModel> GetAll()
        {
            return _destinosRecebiveisRepository.GetAll();
        }

        public IDestinoRecebivelModel GetByCodigo(char codigo)
        {
            return _destinosRecebiveisRepository.GetByCodigo(codigo);
        }

        public IDestinoRecebivelModel GetById(int id)
        {
            return _destinosRecebiveisRepository.GetById(id);
        }

        public void ValidateModel(IDestinoRecebivelModel destinoRecebivelModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(destinoRecebivelModel);
        }
    }
}
