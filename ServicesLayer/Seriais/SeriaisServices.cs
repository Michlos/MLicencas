using DomainLayer.Clientes.Contratos.Seriais;


using ServiceLayer.CommonServices;

namespace ServicesLayer.Seriais
{
    public class SeriaisServices : ISeriaisRepository, ISeriaisServices
    {
        private ISeriaisRepository _seriaisRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ISerialModel Add(ISerialModel serial)
        {
            return _seriaisRepository.Add(serial);
        }

        public string GenHashChave(ISerialModel serial)
        {
            return _seriaisRepository.GenHashChave(serial);
        }

        public string GenHashCliente(ISerialModel serial)
        {
            return _seriaisRepository.GenHashCliente(serial);
        }

        public string GenSerial(ISerialModel serial)
        {
            return _seriaisRepository.GenSerial(serial);
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
