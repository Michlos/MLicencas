using DomainLayer.Financeiro.Caixa;

using System.Collections.Generic;

namespace ServicesLayer.LancamentosCaixa
{
    public interface ILancamentosCaixaRepository
    {
        ILancamentoCaixaModel Add(ILancamentoCaixaModel lancamento);
        void Edit(ILancamentoCaixaModel lancamento);
        IEnumerable<ILancamentoCaixaModel> GetAll();
        ILancamentoCaixaModel GetById(int lancamentoId);
        IEnumerable<ILancamentoCaixaModel> GetAllByCaixaId(int caixaId);
    }
}
