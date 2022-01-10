using DomainLayer.Financeiro.Recebiveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TitulosRecebidos
{
    public class TitulosRecebidosServices : ITitulosRecebidosRepository, ITitulosRecebidosServices
    {
        private readonly ITitulosRecebidosRepository _titulosRecebidosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TitulosRecebidosServices(ITitulosRecebidosRepository titulosRecebidosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _titulosRecebidosRepository = titulosRecebidosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ITituloRecebidoModel Add(ITituloRecebidoModel titulo)
        {
            return _titulosRecebidosRepository.Add(titulo);
        }

        public void Edit(ITituloRecebidoModel titulo)
        {
            _titulosRecebidosRepository.Edit(titulo);
        }

        public IEnumerable<ITituloRecebidoModel> GetAll()
        {
            return _titulosRecebidosRepository.GetAll();
        }

        public ITituloRecebidoModel GetById(int tituloId)
        {
            return _titulosRecebidosRepository.GetById(tituloId);
        }

        public void ValidateModel(ITituloRecebidoModel titulo)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(titulo);
        }
    }
}
