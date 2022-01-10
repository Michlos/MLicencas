using DomainLayer.Financeiro.Caixa;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

namespace ServicesLayer.Caixa
{
    public class CaixaServices : ICaixaRepository, ICaixaServices
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CaixaServices(ICaixaRepository caixaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _caixaRepository = caixaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ICaixaModel Add(ICaixaModel caixa)
        {
            return _caixaRepository.Add(caixa);
        }

        public ICaixaModel CloseCaixa(DateTime dataFechamento, int caixaId)
        {
            return _caixaRepository.CloseCaixa(dataFechamento, caixaId);
        }

        public IEnumerable<ICaixaModel> GetAll()
        {
            return _caixaRepository.GetAll();
        }

        public ICaixaModel GetByDataAbertura(DateTime dataAbertura)
        {
            return _caixaRepository.GetByDataAbertura(dataAbertura);
        }

        public ICaixaModel GetById(int caixaId)
        {
            return _caixaRepository.GetById(caixaId);
        }

        public ICaixaModel UpdateSaldo(double saldoFinal, int caixaId)
        {
            return _caixaRepository.UpdateSaldo(saldoFinal, caixaId);
        }

        public void ValidateModel(ICaixaModel caixaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(caixaModel);
        }
    }
}
