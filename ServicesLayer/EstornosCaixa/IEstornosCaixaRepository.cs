using DomainLayer.Financeiro.Caixa;

using System.Collections.Generic;

namespace ServicesLayer.EstornosCaixa
{
    public interface IEstornosCaixaRepository
    {
        IEstornoCaixaModel Add(IEstornoCaixaModel estornoModel);
        void Remove(int estornoId);
        IEnumerable<IEstornoCaixaModel> GetAll();
        IEstornoCaixaModel GetById(int estornoId);
        IEstornoCaixaModel GetByLancamentoId(int lancamentoId);
    }
}
