using DomainLayer.Financeiro;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.TiposContasBancarias
{
    public class TiposContasBancariasServices : ITiposContasBancariasRepository, ITiposContasBancariasServices
    {
        readonly ITiposContasBancariasRepository _tiposContasBancariasRepository;
        readonly IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TiposContasBancariasServices(ITiposContasBancariasRepository tiposContasBancariasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _tiposContasBancariasRepository = tiposContasBancariasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IEnumerable<ITipoContaBancariaModel> GetAll()
        {
            return _tiposContasBancariasRepository.GetAll();
        }

        public ITipoContaBancariaModel GetById(int tipoId)
        {
            return _tiposContasBancariasRepository.GetById(tipoId);
        }

        public ITipoContaBancariaModel GetByTipo(string tipoNome)
        {
            return _tiposContasBancariasRepository.GetByTipo(tipoNome);
        }

        public void ValidateModel(ITipoContaBancariaModel tipoContaBancariaModel)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(tipoContaBancariaModel);
        }
    }
}
