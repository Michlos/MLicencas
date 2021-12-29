using DomainLayer.Financeiro;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.TiposContasBancarias
{
    class TiposContasBancariasServices : ITiposContasBancariasRepository, ITiposContasBancariasServices
    {
        readonly ITiposContasBancariasRepository _tiposContasBancariasRepository;
        readonly ITiposContasBancariasServices _tiposContasBancariasServices;

        public TiposContasBancariasServices(ITiposContasBancariasRepository tiposContasBancariasRepository, ITiposContasBancariasServices tiposContasBancariasServices)
        {
            _tiposContasBancariasRepository = tiposContasBancariasRepository;
            _tiposContasBancariasServices = tiposContasBancariasServices;
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
            _tiposContasBancariasServices.ValidateModel(tipoContaBancariaModel);
        }
    }
}
