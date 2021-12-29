using DomainLayer.Financeiro;

namespace ServicesLayer.ContasBancarias
{
    public interface IContasBancariasServices
    {
        void ValidateModel(IContaBancariaModel contaModel);
    }
}
