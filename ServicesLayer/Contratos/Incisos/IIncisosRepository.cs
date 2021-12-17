using DomainLayer.Clientes.Contratos.Incisos;

using System.Collections.Generic;

namespace ServicesLayer.Contratos.Incisos
{
    public interface IIncisosRepository
    {
        IIncisoModel Add(IIncisoModel incisoModel);
        void Edit(IIncisoModel incisoModel);
        void Delete(int incisoId);
        IEnumerable<IIncisoModel> GetAll();
        IEnumerable<IIncisoModel> GetAllByClausula(int clausulaId);
        IIncisoModel GetById(int incisoId);
    }
}
