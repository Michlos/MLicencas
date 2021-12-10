namespace DomainLayer.Clientes.Contatos
{
    public interface IContatoClienteModel
    {
        string Cargo { get; set; }
        int ClienteId { get; set; }
        string Contato { get; set; }
        string Email { get; set; }
        int Id { get; set; }
    }
}