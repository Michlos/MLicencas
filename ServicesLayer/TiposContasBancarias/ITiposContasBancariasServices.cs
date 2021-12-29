using DomainLayer.Financeiro;

namespace ServicesLayer.TiposContasBancarias
{
    public interface ITiposContasBancariasServices
    {
        void ValidateModel(ITipoContaBancariaModel tipoContaBancariaModel);
    }
}
