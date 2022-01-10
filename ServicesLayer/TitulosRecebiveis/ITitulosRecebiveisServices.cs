using DomainLayer.Financeiro.Recebiveis;

namespace ServicesLayer.TitulosRecebiveis
{
    public interface ITitulosRecebiveisServices
    {
        void ValidateModel(ITituloRecebivelModel tituloModel);
    }
}
