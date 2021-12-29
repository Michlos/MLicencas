using DomainLayer.Financeiro;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Bancos
{
    public class BancosServices : IBancosRepository, IBancosServices
    {
        private readonly IBancosRepository _bancosRepository;
        private readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public BancosServices(IBancosRepository bancosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _bancosRepository = bancosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IBancoModel Add(IBancoModel bancoModel)
        {
            return _bancosRepository.Add(bancoModel);
        }

        public void Edit(IBancoModel bancoModel)
        {
            _bancosRepository.Edit(bancoModel);
        }

        public IEnumerable<IBancoModel> GetAll()
        {
            return _bancosRepository.GetAll();
        }

        public IBancoModel GetById(int bancoId)
        {
            return _bancosRepository.GetById(bancoId);
        }

        public void Remove(int bancoId)
        {
            _bancosRepository.Remove(bancoId);
        }

        public void ValidateModel(IBancoModel bancoModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(bancoModel);
        }
    }
}
