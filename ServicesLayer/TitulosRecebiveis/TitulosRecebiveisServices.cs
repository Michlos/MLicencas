using DomainLayer.Financeiro.Recebiveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TitulosRecebiveis
{
    public class TitulosRecebiveisServices : ITitulosRecebiveisRepository, ITitulosRecebiveisServices
    {
        private readonly ITitulosRecebiveisRepository _titulosRecebiveisRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TitulosRecebiveisServices(ITitulosRecebiveisRepository titulosRecebiveisRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _titulosRecebiveisRepository = titulosRecebiveisRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ITituloRecebivelModel Add(ITituloRecebivelModel tituloModel)
        {
            return _titulosRecebiveisRepository.Add(tituloModel);
        }

        public void Edit(ITituloRecebivelModel tituloModel)
        {
            _titulosRecebiveisRepository.Edit(tituloModel);
        }

        public IEnumerable<ITituloRecebivelModel> GetAll()
        {
            return _titulosRecebiveisRepository.GetAll();
        }

        public IEnumerable<ITituloRecebivelModel> GetAllByClienteId(int clienteId)
        {
            return _titulosRecebiveisRepository.GetAllByClienteId(clienteId);
        }

        public IEnumerable<ITituloRecebivelModel> GetAllByContratoId(int contratoId)
        {
            return _titulosRecebiveisRepository.GetAllByContratoId(contratoId);
        }

        public ITituloRecebivelModel GetById(int tituloId)
        {
            return _titulosRecebiveisRepository.GetById(tituloId);
        }

        public void ValidateModel(ITituloRecebivelModel tituloModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tituloModel);
        }
    }
}
