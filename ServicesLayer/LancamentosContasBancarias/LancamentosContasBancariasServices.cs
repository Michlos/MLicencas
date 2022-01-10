using DomainLayer.Financeiro.Bancos.ContaBancaria;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

namespace ServicesLayer.LancamentosContasBancarias
{
    public class LancamentosContasBancariasServices : ILancamentosContasBancariasRepository, ILancamentosContasBancariasServices
    {
        private readonly ILancamentosContasBancariasRepository _lancamentosContasBancariasRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public LancamentosContasBancariasServices(ILancamentosContasBancariasRepository lancamentosContasBancariasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _lancamentosContasBancariasRepository = lancamentosContasBancariasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ILancamentoContaBancariaModel Add(ILancamentoContaBancariaModel lancamento)
        {
            return _lancamentosContasBancariasRepository.Add(lancamento);
        }

        public void Edit(ILancamentoContaBancariaModel lancamento)
        {
            _lancamentosContasBancariasRepository.Edit(lancamento);
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAll()
        {
            return _lancamentosContasBancariasRepository.GetAll();
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaId(int contaId)
        {
            return _lancamentosContasBancariasRepository.GetAllByContaId(contaId);
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndDatas(int contaId, DateTime dataIni, DateTime dataFim)
        {
            return _lancamentosContasBancariasRepository.GetAllByContaIdAndDatas(contaId, dataIni, dataFim);
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndMonth(int contaId, int month)
        {
            return _lancamentosContasBancariasRepository.GetAllByContaIdAndMonth(contaId, month);
        }

        public ILancamentoContaBancariaModel GetById(int lancamentoId)
        {
            return _lancamentosContasBancariasRepository.GetById(lancamentoId);
        }

        public void ValidateModel(ILancamentoContaBancariaModel lancamento)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(lancamento);
        }
    }
}
