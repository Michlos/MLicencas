using DomainLayer.Softwares;

using System.Collections.Generic;

namespace ServicesLayer.Softwares
{
    public interface ISoftwaresRepository
    {
        ISoftwareModel Add(ISoftwareModel software);
        void Edit(ISoftwareModel software);
        IEnumerable<ISoftwareModel> GetAll();
        ISoftwareModel GetById(int softwareId);
    }
}
