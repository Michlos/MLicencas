using DomainLayer.Financeiro;

namespace ServicesLayer.Bancos
{
    public interface IBancosServices
    {
        void ValidateModel(IBancoModel bancoModel);
    }
}
