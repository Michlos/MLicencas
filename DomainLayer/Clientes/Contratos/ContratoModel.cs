using System;

namespace DomainLayer.Clientes.Contratos
{
    public class ContratoModel : IContratoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Termo { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataVencimento { get; set; }
        public int Prorrogacoes { get; set; }
        public int ClienteId { get; set; }
        public int SoftwareId { get; set; }
        public int SituacaoId { get; set; }
    }
}
