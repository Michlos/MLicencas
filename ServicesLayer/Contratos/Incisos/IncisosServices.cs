using DomainLayer.Clientes.Contratos.Incisos;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Contratos.Incisos
{
    public class IncisosServices : IIncisosRepository, IIncisosServices
    {
        IIncisosRepository _incisosRepository;
        IModelDataAnnotationCheck _modelDataAnnotation;

        public IncisosServices(IIncisosRepository incisosRepository, IModelDataAnnotationCheck modelDataAnnotation)
        {
            _incisosRepository = incisosRepository;
            _modelDataAnnotation = modelDataAnnotation;
        }

        public IIncisoModel Add(IIncisoModel incisoModel)
        {
            return _incisosRepository.Add(incisoModel);
        }

        public void Delete(int incisoId)
        {
            _incisosRepository.Delete(incisoId);
        }

        public void Edit(IIncisoModel incisoModel)
        {
            _incisosRepository.Edit(incisoModel);
        }

        public IEnumerable<IIncisoModel> GetAll()
        {
            return _incisosRepository.GetAll();
        }

        public IEnumerable<IIncisoModel> GetAllByClausula(int clausulaId)
        {
            return _incisosRepository.GetAllByClausula(clausulaId);
        }

        public IIncisoModel GetById(int incisoId)
        {
            return _incisosRepository.GetById(incisoId);
        }

        public void ValidateModel(IIncisoModel incisoModel)
        {
            _modelDataAnnotation.ValidateModelDataAnnotations(incisoModel);
        }
    }
}
