using System;

namespace DomainLayer.Clientes.Contratos
{
    public interface IContratoModel
    {
        int ClienteId { get; set; }
        DateTime DataRegistro { get; set; }
        DateTime DataVencimento { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
        int Prorrogacoes { get; set; }
        int SituacaoId { get; set; }
        int SoftwareId { get; set; }
        string Termo { get; set; }
    }
}