using DomainLayer.Financeiro.Caixa;

namespace ServicesLayer.Caixa
{
    public interface ICaixaServices
    {
        void ValidateModel(ICaixaModel caixaModel);
    }
}
