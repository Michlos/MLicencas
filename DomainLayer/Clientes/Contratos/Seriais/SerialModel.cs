namespace DomainLayer.Clientes.Contratos.Seriais
{
    public class SerialModel : ISerialModel
    {
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public int ClienteId { get; set; }
        public int SoftwareId { get; set; }
        public string Chave { get; set; }
        public string HashChave { get; set; }
        public string HashCliente { get; set; }
    }
}
