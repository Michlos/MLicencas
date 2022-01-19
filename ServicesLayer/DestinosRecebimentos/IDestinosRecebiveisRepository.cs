using DomainLayer.Financeiro.Recebiveis;

using System.Collections.Generic;

namespace ServicesLayer.DestinosRecebimentos
{
    public interface IDestinosRecebiveisRepository
    {
        IDestinoRecebivelModel GetById(int id);
        IDestinoRecebivelModel GetByCodigo(char codigo);
        IEnumerable<IDestinoRecebivelModel> GetAll();
    }
}
