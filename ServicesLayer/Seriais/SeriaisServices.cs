using DomainLayer.Clientes.Contratos.Seriais;


using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Seriais
{
    public class SeriaisServices : ISeriaisRepository, ISeriaisServices
    {
        private ISeriaisRepository _seriaisRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public SeriaisServices(ISeriaisRepository seriaisRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _seriaisRepository = seriaisRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public ISerialModel Add(ISerialModel serial)
        {
            return _seriaisRepository.Add(serial);
        }

        public IEnumerable<ISerialModel> GetAllByClienteId(int clienteId)
        {
            return _seriaisRepository.GetAllByClienteId(clienteId);
        }

        public ISerialModel GetByContratoId(int contratoId)
        {
            return _seriaisRepository.GetByContratoId(contratoId);
        }

        public ISerialModel GetById(int serialId)
        {
            return _seriaisRepository.GetById(serialId);
        }

        public ISerialModel Renew(ISerialModel serial)
        {
            return _seriaisRepository.Renew(serial);
        }

        public void UnloadHash(int serialId)
        {
            _seriaisRepository.UnloadHash(serialId);
        }

        public void ValidateModel(ISerialModel serial)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(serial);
        }
    }
}
