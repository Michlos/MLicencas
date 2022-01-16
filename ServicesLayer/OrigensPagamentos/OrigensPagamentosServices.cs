using DomainLayer.Financeiro.Pagaveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.OrigensPagamentos
{
    public class OrigensPagamentosServices : IOrigensPagamentosRepository, IOrigensPagamentosServices
    {
        private readonly IOrigensPagamentosRepository _origensPagamentosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public OrigensPagamentosServices(IOrigensPagamentosRepository origensPagamentosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _origensPagamentosRepository = origensPagamentosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<IOrigemPagamentoModel> GetAll()
        {
            return _origensPagamentosRepository.GetAll();
        }

        public IOrigemPagamentoModel GetById(int origemId)
        {
            return _origensPagamentosRepository.GetById(origemId);
        }

        public void ValidateModel(IOrigemPagamentoModel origemPagamentoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(origemPagamentoModel);
        }
    }
}
