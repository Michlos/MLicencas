using DomainLayer.Telefones;

using System.Collections.Generic;

namespace ServicesLayer.TiposTelefones
{
    public interface ITiposTelefonesRepository
    {
        IEnumerable<ITipoTelefoneModel> GetAll();
        ITipoTelefoneModel GetById(int tipoId);
    }
}
