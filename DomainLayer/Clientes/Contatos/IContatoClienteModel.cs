namespace DomainLayer.Clientes.Contatos
{
    public interface IContatoClienteModel
    {
        string Cargo { get; set; }
        int ClienteId { get; set; }
        string Cpf { get; set; }
        string Email { get; set; }
        string EstadoCivil { get; set; }
        int Id { get; set; }
        string Nacionalidade { get; set; }
        string Nome { get; set; }
        bool Responsavel { get; set; }
        string Rg { get; set; }
    }
}