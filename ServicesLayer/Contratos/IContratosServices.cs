using DomainLayer.Clientes.Contratos;

namespace ServicesLayer.Contratos
{
    public interface IContratosServices
    {
        void ValidateModel(IContratoModel contrato);
    }
}
