using DomainLayer.Clientes.Contratos;

using ServiceLayer.CommonServices;

using System;
using System.Collections.Generic;

namespace ServicesLayer.Contratos
{
    public class ContratosServices : IContratosRepository, IContratosServices
    {
        private IContratosRepository _contratosRepository;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public ContratosServices(IContratosRepository contratosRepository, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _contratosRepository = contratosRepository;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public IContratoModel Add(IContratoModel contrato)
        {
            return _contratosRepository.Add(contrato);
        }

        public void AlteraSituacao(int situacaoId, int contratoId)
        {
            _contratosRepository.AlteraSituacao(situacaoId, contratoId);
        }

        public void Edit(IContratoModel contrato)
        {
            _contratosRepository.Edit(contrato);
        }

        public IEnumerable<IContratoModel> GetAll()
        {
            return _contratosRepository.GetAll();
        }

        public IEnumerable<IContratoModel> GetAllByClienteId(int clienteId)
        {
            return _contratosRepository.GetAllByClienteId(clienteId);
        }

        public IEnumerable<IContratoModel> GetAllBySoftwareId(int softwareId)
        {
            return _contratosRepository.GetAllBySoftwareId(softwareId);
        }

        public IContratoModel GetById(int contratoId)
        {
            return _contratosRepository.GetById(contratoId);
        }

        public IContratoModel Prorroga(IContratoModel contrato, DateTime dataProrroga)
        {
            return _contratosRepository.Prorroga(contrato, dataProrroga);
        }

        public void ValidateModel(IContratoModel contrato)
        {
            _modelDataAnnotationCheck.ValidateModelDataAnnotations(contrato);
        }
    }
}
