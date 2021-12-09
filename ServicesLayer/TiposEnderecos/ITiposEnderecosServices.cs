using DomainLayer.Enderecos;

namespace ServicesLayer.TiposEnderecos
{
    public interface ITiposEnderecosServices
    {
        void ValidateModel(ITipoEnderecoModel tipoEnderecoModel);
    }
}
