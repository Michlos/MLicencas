using DomainLayer.Enderecos;

using System.Collections.Generic;

namespace ServicesLayer.Cidades
{
    public interface ICidadesRepository
    {
        IEnumerable<ICidadeModel> GetAll();
        ICidadeModel GetById(int cidadeId);
        IEnumerable<ICidadeModel> GetAllByUf(string uf);
        IEnumerable<ICidadeModel> GetAllByUfId(int ufId);
    }
}
