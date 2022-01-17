using DomainLayer.Financeiro.Pagaveis;

namespace ServicesLayer.ContasLiquidadasCaixas
{
    public interface IContasLiquidadasCaixasServices
    {
        void ValidateModel(IContaLiquidadaCaixaModel model);
    }
}
