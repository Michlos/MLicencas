using DomainLayer.Fabrica;

using ServiceLayer.CommonServices;

namespace ServicesLayer.Fabrica
{
    public class FabricaServices : IFabricaRepository, IFabricaServices
    {
        private IFabricaRepository _fabricaRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public FabricaServices(IFabricaRepository fabricaRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _fabricaRepository = fabricaRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IFabricaModel Add(IFabricaModel fabrica)
        {
            return _fabricaRepository.Add(fabrica);
        }

        public void Edit(IFabricaModel fabrica)
        {
            _fabricaRepository.Edit(fabrica);
        }

        public IFabricaModel GetFabrica()
        {
            return _fabricaRepository.GetFabrica();
        }

        public void ValidateModel(IFabricaModel fabrica)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(fabrica);
        }
    }
}
