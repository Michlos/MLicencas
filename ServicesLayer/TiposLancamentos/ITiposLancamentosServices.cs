using DomainLayer.Financeiro;

namespace ServicesLayer.TiposLancamentos
{
    public interface ITiposLancamentosServices
    {
        void ValidateModel(ITipoLancamentoModel tipoLancamentoModel);
    }
}
