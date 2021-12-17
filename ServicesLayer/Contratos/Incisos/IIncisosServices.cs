using DomainLayer.Clientes.Contratos.Incisos;

namespace ServicesLayer.Contratos.Incisos
{
    public interface IIncisosServices
    {
        void ValidateModel(IIncisoModel incisoModel);
    }
}
