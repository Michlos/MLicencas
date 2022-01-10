using DomainLayer.Financeiro.Caixa;

namespace ServicesLayer.LancamentosCaixa
{
    public interface ILancamentosCaixaServices
    {
        void ValidateModel(ILancamentoCaixaModel lancamento);
    }
}
