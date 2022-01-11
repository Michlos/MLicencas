using DomainLayer.Financeiro.Recebiveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.EstornosTitulosRecebidos
{
    public class EstornosTitulosRecebidosServices : IEstornosTitulosRecebidosRepository, IEstornosTitulosRecebidosServices
    {
        private readonly IEstornosTitulosRecebidosRepository _estornosTitulosRecebidosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstornosTitulosRecebidosServices(IEstornosTitulosRecebidosRepository estornosTitulosRecebidosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estornosTitulosRecebidosRepository = estornosTitulosRecebidosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEstornoTituloRecebidoModel Add(IEstornoTituloRecebidoModel estornoModel)
        {
            return _estornosTitulosRecebidosRepository.Add(estornoModel);
        }

        public IEnumerable<IEstornoTituloRecebidoModel> GetAll()
        {
            return _estornosTitulosRecebidosRepository.GetAll();
        }

        public IEstornoTituloRecebidoModel GetById(int estornoId)
        {
            return _estornosTitulosRecebidosRepository.GetById(estornoId);
        }

        public IEstornoTituloRecebidoModel GetByTituloId(int tituloId)
        {
            return _estornosTitulosRecebidosRepository.GetByTituloId(tituloId);
        }

        public void Remove(int estornoId)
        {
            _estornosTitulosRecebidosRepository.Remove(estornoId);
        }

        public void ValidateModel(IEstornoTituloRecebidoModel estornoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estornoModel);
        }
    }
}
