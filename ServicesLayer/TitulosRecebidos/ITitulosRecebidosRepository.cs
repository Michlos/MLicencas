using DomainLayer.Financeiro.Recebiveis;

using System.Collections.Generic;

namespace ServicesLayer.TitulosRecebidos
{
    public interface ITitulosRecebidosRepository
    {
        ITituloRecebidoModel Add(ITituloRecebidoModel titulo);
        void Edit(ITituloRecebidoModel titulo);
        IEnumerable<ITituloRecebidoModel> GetAll();
        ITituloRecebidoModel GetById(int tituloId);
    }
}
