using DomainLayer.Softwares.SistemasOperacionais;

using System.Collections.Generic;

namespace ServicesLayer.SistemasOperacionais
{
    public interface ISistemasOperacionaisRepository
    {
        ISistemaOperacionalModel Add(ISistemaOperacionalModel osModel);
        void Edit(ISistemaOperacionalModel osModel);
        ISistemaOperacionalModel GetById(int osId);
        IEnumerable<ISistemaOperacionalModel> GetAll();
    }
}
