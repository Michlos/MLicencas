using DomainLayer.Financeiro;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.ContasBancarias
{
    public class ContasBancariasServices : IContasBancariasRepository, IContasBancariasServices
    {
        readonly IContasBancariasRepository _contasBancariasRepository;
        readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContasBancariasServices(IContasBancariasRepository contasBancariasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contasBancariasRepository = contasBancariasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContaBancariaModel Add(IContaBancariaModel contaModel)
        {
            return _contasBancariasRepository.Add(contaModel);
        }

        public void Edit(IContaBancariaModel contaModel)
        {
            _contasBancariasRepository.Edit(contaModel);
        }

        public IEnumerable<IContaBancariaModel> GetAll()
        {
            return _contasBancariasRepository.GetAll();
        }

        public IEnumerable<IContaBancariaModel> GetAllByBancoId(int bancoId)
        {
            return _contasBancariasRepository.GetAllByBancoId(bancoId);
        }

        public IContaBancariaModel GetById(int contaId)
        {
            return _contasBancariasRepository.GetById(contaId);
        }

        public void Remove(int contaId)
        {
            _contasBancariasRepository.Remove(contaId);
        }

        public void ValidateModel(IContaBancariaModel contaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contaModel);
        }
    }
}
