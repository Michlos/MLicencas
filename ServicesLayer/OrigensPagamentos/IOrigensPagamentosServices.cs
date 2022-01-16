using DomainLayer.Financeiro.Pagaveis;

namespace ServicesLayer.OrigensPagamentos
{
    public interface IOrigensPagamentosServices
    {
        void ValidateModel(IOrigemPagamentoModel origemPagamentoModel);
    }
}
