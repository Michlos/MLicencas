using DomainLayer.Financeiro.Recebiveis;

namespace ServicesLayer.TiposRecebimentosTitulos
{
    public interface ITiposRecebimentosTitulosServices
    {
        void ValidateModel(ITipoRecebimentoTituloModel tipoRecebimentoTituloModel);
    }
}
