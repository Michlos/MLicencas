using DomainLayer.Financeiro.Pagaveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadas
{
    public class ContasLiquidadasServices : IContasLiquidadasRepository, IContasLiquidadasServices
    {
        private readonly IContasLiquidadasRepository _contasLiquidadasRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasLiquidadasServices(IContasLiquidadasRepository contasLiquidadasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasLiquidadasRepository = contasLiquidadasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContaLiquidadaModel Add(IContaLiquidadaModel contaModel)
        {
            return _contasLiquidadasRepository.Add(contaModel);
        }

        public void Estornar(IContaLiquidadaModel contaModel)
        {
            _contasLiquidadasRepository.Estornar(contaModel);
        }

        public IEnumerable<IContaLiquidadaModel> GetAll()
        {
            return _contasLiquidadasRepository.GetAll();
        }

        public IEnumerable<IContaLiquidadaModel> GetByContaPagarId(int contaPagarId)
        {
            return _contasLiquidadasRepository.GetByContaPagarId(contaPagarId);
        }

        public IContaLiquidadaModel GetById(int contaId)
        {
            return _contasLiquidadasRepository.GetById(contaId);
        }

        public void Remove(int contaId)
        {
            _contasLiquidadasRepository.Remove(contaId);
        }

        public void ValidateModel(IContaLiquidadaModel contaLiquidadaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contaLiquidadaModel);
        }
    }
}
