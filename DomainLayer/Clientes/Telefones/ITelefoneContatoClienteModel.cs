namespace DomainLayer.Clientes.Telefones
{
    public interface ITelefoneContatoClienteModel
    {
        int ContatoId { get; set; }
        int Id { get; set; }
        string Numero { get; set; }
        string Operadora { get; set; }
        string Ramal { get; set; }
        int TipoTelefoneId { get; set; }
    }
}