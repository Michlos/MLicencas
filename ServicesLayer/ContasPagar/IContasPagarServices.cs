using DomainLayer.Financeiro.Pagaveis;

namespace ServicesLayer.ContasPagar
{
    public interface IContasPagarServices
    {
        void ValidateModel(IContaPagarModel contaPagarModel);
    }
}
