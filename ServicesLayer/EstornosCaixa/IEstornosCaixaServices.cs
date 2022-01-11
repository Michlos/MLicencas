using DomainLayer.Financeiro.Caixa;

namespace ServicesLayer.EstornosCaixa
{
    public interface IEstornosCaixaServices
    {
        void ValidateModel(IEstornoCaixaModel estornoModel);
    }
}
