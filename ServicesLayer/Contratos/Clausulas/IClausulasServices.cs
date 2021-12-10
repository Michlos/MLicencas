using DomainLayer.Clientes.Contratos.Clausulas;

namespace ServicesLayer.Clausulas
{
    public interface IClausulasServices
    {
        void ValidateModel(IClausulaModel clausula);
    }
}
