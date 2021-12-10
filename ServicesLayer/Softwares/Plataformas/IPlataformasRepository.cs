using DomainLayer.Softwares.Plataformas;

using System.Collections.Generic;

namespace ServicesLayer.Plataformas
{
    public interface IPlataformasRepository
    {

        IPlataformaModel Add(IPlataformaModel plataforma);
        void Edit(IPlataformaModel plataforma);
        IPlataformaModel GetById(int palaformaId);
        IEnumerable<IPlataformaModel> GetAll();
    }
}
