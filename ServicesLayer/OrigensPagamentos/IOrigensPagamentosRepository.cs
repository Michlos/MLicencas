using DomainLayer.Financeiro.Pagaveis;

using System.Collections.Generic;

namespace ServicesLayer.OrigensPagamentos
{
    public interface IOrigensPagamentosRepository
    {
        IEnumerable<IOrigemPagamentoModel> GetAll();
        IOrigemPagamentoModel GetById(int origemId);
    }
}
