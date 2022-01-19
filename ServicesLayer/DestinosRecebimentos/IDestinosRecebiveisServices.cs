using DomainLayer.Financeiro.Recebiveis;

namespace ServicesLayer.DestinosRecebimentos
{
    public interface IDestinosRecebiveisServices
    {
        void ValidateModel(IDestinoRecebivelModel destinoRecebivelModel);
    }
}
