using DomainLayer.Enderecos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Estados
{
    public class EstadosServices : IEstadosRepository, IEstadosServices
    {
        private IEstadosRepository _estadosRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstadosServices(IEstadosRepository estadosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estadosRepository = estadosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IEstadoModel> GetAll()
        {
            return _estadosRepository.GetAll();
        }

        public IEstadoModel GetById(int estadoId)
        {
            return _estadosRepository.GetById(estadoId);
        }

        public IEstadoModel GetByUf(string uf)
        {
            return _estadosRepository.GetByUf(uf);
        }

        public void ValidateModel(IEstadoModel estadoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estadoModel);
        }
    }
}
