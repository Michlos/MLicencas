using DomainLayer.Clientes.Contratos;

using System;
using System.Collections.Generic;

namespace ServicesLayer.Contratos
{
    public interface IContratosRepository
    {
        IContratoModel Add(IContratoModel contrato);
        void Edit(IContratoModel contrato);
        IContratoModel Prorroga(IContratoModel contrato, DateTime dataProrroga);
        IContratoModel GetById(int contratoId);
        IEnumerable<IContratoModel> GetAll();
        IEnumerable<IContratoModel> GetAllByClienteId(int clienteId);
        IEnumerable<IContratoModel> GetAllBySoftwareId(int softwareId);
        void AlteraSituacao(int situacaoId, int contratoId);
    }
}
