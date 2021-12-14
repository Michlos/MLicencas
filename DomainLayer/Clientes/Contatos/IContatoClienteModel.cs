namespace DomainLayer.Clientes.Contatos
{
    public interface IContatoClienteModel
    {
        string Cargo { get; set; }
        int ClienteId { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        int Id { get; set; }
    }
}