using DomainLayer.Financeiro.Recebiveis;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.TiposRecebimentosTitulos
{
    public class TiposRecebimentosTitulosServices : ITiposRecebimentosTitulosRepository, ITiposRecebimentosTitulosServices
    {
        private readonly ITiposRecebimentosTitulosRepository _tiposRecebimentosTitulosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TiposRecebimentosTitulosServices(ITiposRecebimentosTitulosRepository tiposRecebimentosTitulosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tiposRecebimentosTitulosRepository = tiposRecebimentosTitulosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoRecebimentoTituloModel> GetAll()
        {
            return _tiposRecebimentosTitulosRepository.GetAll();
        }

        public ITipoRecebimentoTituloModel GetById(int id)
        {
            return _tiposRecebimentosTitulosRepository.GetById(id);
        }

        public void ValidateModel(ITipoRecebimentoTituloModel tipoRecebimentoTituloModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoRecebimentoTituloModel);
        }
    }
}
