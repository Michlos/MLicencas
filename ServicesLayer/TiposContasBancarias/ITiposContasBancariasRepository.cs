using DomainLayer.Financeiro;

using System.Collections.Generic;

namespace ServicesLayer.TiposContasBancarias
{
    public interface ITiposContasBancariasRepository
    {
        IEnumerable<ITipoContaBancariaModel> GetAll();
        ITipoContaBancariaModel GetById(int tipoId);
        ITipoContaBancariaModel GetByTipo(string tipoNome);
    }
}
