using DomainLayer.Situacao;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.SituacoesServices
{
    public class SituacoesServices : ISituacoesRepository, ISituacoesServices
    {
        private ISituacoesRepository _situacoesRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public SituacoesServices(ISituacoesRepository situacoesRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _situacoesRepository = situacoesRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ISituacaoModel> GetAll()
        {
            return _situacoesRepository.GetAll();
        }

        public ISituacaoModel GetById(int situacaoId)
        {
            return _situacoesRepository.GetById(situacaoId);
        }

        public void ValidateModel(ISituacaoModel situacaoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(situacaoModel);
        }
    }
}
