using DomainLayer.Financeiro.Recebiveis;

using System.Collections.Generic;

namespace ServicesLayer.TitulosRecebiveis
{
    public interface ITitulosRecebiveisRepository
    {
        ITituloRecebivelModel Add(ITituloRecebivelModel tituloModel);
        void Edit(ITituloRecebivelModel tituloModel);
        ITituloRecebivelModel GetById(int tituloId);
        IEnumerable<ITituloRecebivelModel> GetAll();
        IEnumerable<ITituloRecebivelModel> GetAllByClienteId(int clienteId);
        IEnumerable<ITituloRecebivelModel> GetAllByContratoId(int contratoId);
        
    }
}
