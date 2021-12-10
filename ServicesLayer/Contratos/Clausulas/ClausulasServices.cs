using DomainLayer.Clientes.Contratos.Clausulas;

using ServiceLayer.CommonServices;

using System.Collections.Generic;

namespace ServicesLayer.Clausulas
{
    public class ClausulasServices : IClausulasRepository, IClausulasServices
    {
        private IClausulasRepository _clausulasRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ClausulasServices(IClausulasRepository clausulasRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _clausulasRepository = clausulasRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IClausulaModel Add(IClausulaModel clausula)
        {
            return _clausulasRepository.Add(clausula);
        }

        public void Delete(int clausulaId)
        {
            _clausulasRepository.Delete(clausulaId);
        }

        public void Edit(IClausulaModel clausula)
        {
            _clausulasRepository.Edit(clausula);
        }

        public IEnumerable<IClausulaModel> GetAll()
        {
            return _clausulasRepository.GetAll();
        }

        public IEnumerable<IClausulaModel> GetAllByContratoId(int contratoId)
        {
            return _clausulasRepository.GetAllByContratoId(contratoId);
        }

        public IClausulaModel GetById(int clausulaId)
        {
            return _clausulasRepository.GetById(clausulaId);
        }

        public void ValidateModel(IClausulaModel clausula)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(clausula);
        }
    }
}
