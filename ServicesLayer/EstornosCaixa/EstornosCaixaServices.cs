using DomainLayer.Financeiro.Caixa;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.EstornosCaixa
{
    public class EstornosCaixaServices : IEstornosCaixaRepository, IEstornosCaixaServices
    {
        private readonly IEstornosCaixaRepository _estornosCaixaRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstornosCaixaServices(IEstornosCaixaRepository estornosCaixaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estornosCaixaRepository = estornosCaixaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEstornoCaixaModel Add(IEstornoCaixaModel estornoModel)
        {
            return _estornosCaixaRepository.Add(estornoModel);
        }

        public IEnumerable<IEstornoCaixaModel> GetAll()
        {
            return _estornosCaixaRepository.GetAll();
        }

        public IEstornoCaixaModel GetById(int estornoId)
        {
            return _estornosCaixaRepository.GetById(estornoId);
        }

        public IEstornoCaixaModel GetByLancamentoId(int lancamentoId)
        {
            return _estornosCaixaRepository.GetByLancamentoId(lancamentoId);
        }

        public void Remove(int estornoId)
        {
            _estornosCaixaRepository.Remove(estornoId);
        }

        public void ValidateModel(IEstornoCaixaModel estornoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estornoModel);
        }
    }
}
