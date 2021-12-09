using DomainLayer.Enderecos;

namespace ServicesLayer.Estados
{
    public interface IEstadosServices
    {
        void ValidateModel(IEstadoModel estadoModel);
    }
}
