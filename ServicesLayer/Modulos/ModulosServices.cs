using DomainLayer.Modulos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Modulos
{
    public class ModulosServices : IModulosRepository, IModulosServices
    {
        private IModulosRepository _moduloRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ModulosServices(IModulosRepository moduloRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _moduloRepository = moduloRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IModuloModel Add(IModuloModel modulo)
        {
            return _moduloRepository.Add(modulo);
        }

        public IModuloModel Edit(IModuloModel modulo)
        {
            return _moduloRepository.Edit(modulo);
        }

        public IEnumerable<IModuloModel> GetAll()
        {
            return _moduloRepository.GetAll();
        }

        public IModuloModel GetByHieraquia(string nivel)
        {
            return _moduloRepository.GetByHieraquia(nivel);
        }

        public IModuloModel GetById(int moduloId)
        {
            return _moduloRepository.GetById(moduloId);
        }

        public void ValidateModel(IModuloModel modulo)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(modulo);
        }
    }
}
