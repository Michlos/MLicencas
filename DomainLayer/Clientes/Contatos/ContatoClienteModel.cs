namespace DomainLayer.Clientes.Contatos
{
    public class ContatoClienteModel : IContatoClienteModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public int ClienteId { get; set; }
    }
}
