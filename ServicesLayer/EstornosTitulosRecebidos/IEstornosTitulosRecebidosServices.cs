using DomainLayer.Financeiro.Recebiveis;

namespace ServicesLayer.EstornosTitulosRecebidos
{
    public interface IEstornosTitulosRecebidosServices
    {
        void ValidateModel(IEstornoTituloRecebidoModel estornoModel);
    }
}
