using DomainLayer.Financeiro.Pagaveis;

namespace ServicesLayer.ContasLiquidadasBancos
{
    public interface IContasLiquidadasBancosServices
    {
        void ValidateModel(IContaLiquidadaBancoModel contaLiquidadaBancoModel);
    }
}
