using DomainLayer.Financeiro.Pagaveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContasPagar
{
    public class ContasPagarServices : IContasPagarRepository, IContasPagarServices
    {
        private readonly IContasPagarRepository _contasPagarRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasPagarServices(IContasPagarRepository contasPagarRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasPagarRepository = contasPagarRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContaPagarModel Add(IContaPagarModel contaPagarModel )
        {
            return _contasPagarRepository.Add(contaPagarModel);
        }

        public void Edit(IContaPagarModel contaPagarModel )
        {
            _contasPagarRepository.Edit(contaPagarModel);
        }

        public IEnumerable<IContaPagarModel> GetAll()
        {
            return _contasPagarRepository.GetAll();
        }

        public IContaPagarModel GetById(int contaId)
        {
            return _contasPagarRepository.GetById(contaId);
        }

        public void Remove(int contaId)
        {
            _contasPagarRepository.Remove(contaId);
        }

        public void ValidateModel(IContaPagarModel contaPagarModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contaPagarModel);
        }
    }
}
