using DomainLayer.Financeiro.Recebiveis;

using System.Collections.Generic;

namespace ServicesLayer.TiposRecebimentosTitulos
{
    public interface ITiposRecebimentosTitulosRepository
    {
        IEnumerable<ITipoRecebimentoTituloModel> GetAll();
        ITipoRecebimentoTituloModel GetById(int id);
    }
}
