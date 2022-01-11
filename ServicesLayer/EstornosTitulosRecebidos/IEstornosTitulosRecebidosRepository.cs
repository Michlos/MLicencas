using DomainLayer.Financeiro.Recebiveis;

using System.Collections.Generic;

namespace ServicesLayer.EstornosTitulosRecebidos
{
    public interface IEstornosTitulosRecebidosRepository
    {
        IEstornoTituloRecebidoModel Add(IEstornoTituloRecebidoModel estornoModel);
        void Remove(int estornoId);
        IEnumerable<IEstornoTituloRecebidoModel> GetAll();
        IEstornoTituloRecebidoModel GetById(int estornoId);
        IEstornoTituloRecebidoModel GetByTituloId(int tituloId);
    }
}
