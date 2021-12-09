using DomainLayer.Enderecos;

using System.Collections.Generic;

namespace ServicesLayer.TiposEnderecos
{
    public interface ITiposEnderecosRepository
    {
        ITipoEnderecoModel GetById(int id);
        IEnumerable<ITipoEnderecoModel> GetAll();
    }
}
