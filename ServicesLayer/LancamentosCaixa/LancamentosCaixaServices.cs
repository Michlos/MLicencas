using DomainLayer.Financeiro.Caixa;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.LancamentosCaixa
{
    public class LancamentosCaixaServices : ILancamentosCaixaRepository, ILancamentosCaixaServices
    {
        private readonly ILancamentosCaixaRepository _lancamentosCaixaRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public LancamentosCaixaServices(ILancamentosCaixaRepository lancamentosCaixaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _lancamentosCaixaRepository = lancamentosCaixaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ILancamentoCaixaModel Add(ILancamentoCaixaModel lancamento)
        {
            return _lancamentosCaixaRepository.Add(lancamento);
        }

        public void Edit(ILancamentoCaixaModel lancamento)
        {
            _lancamentosCaixaRepository.Edit(lancamento);
        }

        public IEnumerable<ILancamentoCaixaModel> GetAll()
        {
            return _lancamentosCaixaRepository.GetAll();
        }

        public IEnumerable<ILancamentoCaixaModel> GetAllByCaixaId(int caixaId)
        {
            return _lancamentosCaixaRepository.GetAllByCaixaId(caixaId);
        }

        public ILancamentoCaixaModel GetById(int lancamentoId)
        {
            return _lancamentosCaixaRepository.GetById(lancamentoId);
        }

        public void ValidateModel(ILancamentoCaixaModel lancamento)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(lancamento);
        }
    }
}
