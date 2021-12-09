using DomainLayer.Fabrica;

namespace ServicesLayer.Fabrica
{
    public interface IFabricaRepository
    {
        IFabricaModel Add(IFabricaModel fabrica);
        void Edit(IFabricaModel fabrica);
        IFabricaModel GetFabrica();
    }
}
