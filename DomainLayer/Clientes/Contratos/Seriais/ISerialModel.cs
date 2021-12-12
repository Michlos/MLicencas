namespace DomainLayer.Clientes.Contratos.Seriais
{
    public interface ISerialModel
    {
        string Chave { get; set; }
        int ContratoId { get; set; }
        string HashChave { get; set; }
        string HashCliente { get; set; }
        int Id { get; set; }
        int SoftwareId { get; set; }
    }
}