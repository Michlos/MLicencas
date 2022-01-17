using DomainLayer.Financeiro.Pagaveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadasBancos
{
    public class ContasLiquidadasBancosServices : IContasLiquidadasBancosRepository, IContasLiquidadasBancosServices
    {
        private readonly IContasLiquidadasBancosRepository _contasLiquidadasBancosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasLiquidadasBancosServices(IContasLiquidadasBancosRepository contasLiquidadasBancosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasLiquidadasBancosRepository = contasLiquidadasBancosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContaLiquidadaBancoModel Add(IContaLiquidadaBancoModel contaLiquidadaBancoModel)
        {
            return _contasLiquidadasBancosRepository.Add(contaLiquidadaBancoModel);
        }

        public IEnumerable<IContaLiquidadaBancoModel> GetAll()
        {
            return _contasLiquidadasBancosRepository.GetAll();
        }

        public IContaLiquidadaBancoModel GetByContaLiquidadaId(int id)
        {
            return _contasLiquidadasBancosRepository.GetByContaLiquidadaId(id);
        }

        public IContaLiquidadaBancoModel GetById(int id)
        {
            return _contasLiquidadasBancosRepository.GetById(id);
        }

        public IContaLiquidadaBancoModel GetByLancamentoBancarioId(int id)
        {
            return _contasLiquidadasBancosRepository.GetByLancamentoBancarioId(id);
        }

        public void Remove(int id)
        {
            _contasLiquidadasBancosRepository.Remove(id);
        }

        public void ValidateModel(IContaLiquidadaBancoModel contaLiquidadaBancoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contaLiquidadaBancoModel);
        }
    }
}
