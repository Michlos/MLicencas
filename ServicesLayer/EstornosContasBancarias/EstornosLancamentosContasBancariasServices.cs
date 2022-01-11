using DomainLayer.Financeiro.Bancos.ContaBancaria;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.EstornosContasBancarias
{
    public class EstornosLancamentosContasBancariasServices : IEstornosLancamentosContasBancariasRepository, IEstornosLancamentosContasBancariasServices
    {
        private readonly IEstornosLancamentosContasBancariasRepository _estornosLancamentosContasBancariasRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public EstornosLancamentosContasBancariasServices(IEstornosLancamentosContasBancariasRepository estornosLancamentosContasBancariasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _estornosLancamentosContasBancariasRepository = estornosLancamentosContasBancariasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEstornoLancamentoContaBancariaModel Add(IEstornoLancamentoContaBancariaModel estornoModel)
        {
            return _estornosLancamentosContasBancariasRepository.Add(estornoModel);
        }

        public IEnumerable<IEstornoLancamentoContaBancariaModel> GetAll()
        {
            return _estornosLancamentosContasBancariasRepository.GetAll();
        }

        public IEstornoLancamentoContaBancariaModel GetById(int estornoId)
        {
            return _estornosLancamentosContasBancariasRepository.GetById(estornoId);
        }

        public IEstornoLancamentoContaBancariaModel GetByLancamentoId(int lancamentoId)
        {
            return _estornosLancamentosContasBancariasRepository.GetByLancamentoId(lancamentoId);
        }

        public void Remove(int estornoId)
        {
            _estornosLancamentosContasBancariasRepository.Remove(estornoId);
        }

        public void ValidateModel(IEstornoLancamentoContaBancariaModel estornoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(estornoModel);
        }
    }
}
