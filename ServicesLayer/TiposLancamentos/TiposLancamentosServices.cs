using DomainLayer.Financeiro;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TiposLancamentos
{
    public class TiposLancamentosServices : ITiposLancamentosRepository, ITiposLancamentosServices
    {
        private readonly ITiposLancamentosRepository _tiposLancamentosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TiposLancamentosServices(ITiposLancamentosRepository tiposLancamentosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tiposLancamentosRepository = tiposLancamentosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoLancamentoModel> GetAll()
        {
            return _tiposLancamentosRepository.GetAll();
        }

        public ITipoLancamentoModel GetById(int id)
        {
            return _tiposLancamentosRepository.GetById(id);
        }

        public void ValidateModel(ITipoLancamentoModel tipoLancamentoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoLancamentoModel);
        }
    }
}
