using DomainLayer.Financeiro;

using System.Collections.Generic;

namespace ServicesLayer.TiposLancamentos
{
    public interface ITiposLancamentosRepository
    {
        IEnumerable<ITipoLancamentoModel> GetAll();
        ITipoLancamentoModel GetById(int id);
    }
}
