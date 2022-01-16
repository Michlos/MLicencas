using DomainLayer.Financeiro.Pagaveis;

namespace ServicesLayer.ContasLiquidadas
{
    public interface IContasLiquidadasServices
    {
        void ValidateModel(IContaLiquidadaModel contaLiquidadaModel);
    }
}
