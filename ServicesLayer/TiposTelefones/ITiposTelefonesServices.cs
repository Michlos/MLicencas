using DomainLayer.Telefones;

namespace ServicesLayer.TiposTelefones
{
    public interface ITiposTelefonesServices
    {
        void ValidateModel(ITipoTelefoneModel tipoTelefoneModel);
    }
}
