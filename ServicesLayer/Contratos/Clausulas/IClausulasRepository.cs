using DomainLayer.Clientes.Contratos.Clausulas;

using System.Collections.Generic;

namespace ServicesLayer.Clausulas
{
    public interface IClausulasRepository
    {
        IClausulaModel Add(IClausulaModel clausula);
        void Edit(IClausulaModel clausula);
        void Delete(int clausulaId);
        IEnumerable<IClausulaModel> GetAll();
        IEnumerable<IClausulaModel> GetAllByContratoId(int contratoId);
        IClausulaModel GetById(int clausulaId);
    }
}
