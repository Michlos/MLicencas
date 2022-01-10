using DomainLayer.Financeiro.Recebiveis;

namespace ServicesLayer.TitulosRecebidos
{
    public interface ITitulosRecebidosServices
    {
        void ValidateModel(ITituloRecebidoModel titulo);
    }
}
