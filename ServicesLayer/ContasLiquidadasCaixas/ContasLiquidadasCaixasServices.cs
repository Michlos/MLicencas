using DomainLayer.Financeiro.Pagaveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContasLiquidadasCaixas
{
    public class ContasLiquidadasCaixasServices : IContasLiquidadasCaixasRepository, IContasLiquidadasCaixasServices
    {
        private readonly IContasLiquidadasCaixasRepository _contasLiquidadasCaixasRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasLiquidadasCaixasServices(IContasLiquidadasCaixasRepository contasLiquidadasCaixasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasLiquidadasCaixasRepository = contasLiquidadasCaixasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContaLiquidadaCaixaModel Add(IContaLiquidadaCaixaModel model)
        {
            return _contasLiquidadasCaixasRepository.Add(model);
        }

        public IEnumerable<IContaLiquidadaCaixaModel> GetAll()
        {
            return _contasLiquidadasCaixasRepository.GetAll();
        }

        public IContaLiquidadaCaixaModel GetByContaLiquidada(int id)
        {
            return _contasLiquidadasCaixasRepository.GetByContaLiquidada(id);
        }

        public IContaLiquidadaCaixaModel GetById(int id)
        {
            return _contasLiquidadasCaixasRepository.GetById(id);
        }

        public IContaLiquidadaCaixaModel GetByLancamentoCaixa(int id)
        {
            return _contasLiquidadasCaixasRepository.GetByLancamentoCaixa(id);
        }

        public void Remove(int id)
        {
            _contasLiquidadasCaixasRepository.Remove(id);
        }

        public void ValidateModel(IContaLiquidadaCaixaModel model)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(model);
        }
    }
}
