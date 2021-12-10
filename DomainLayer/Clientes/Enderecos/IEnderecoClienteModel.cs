namespace DomainLayer.Clientes.Enderecos
{
    public interface IEnderecoClienteModel
    {
        int BairroId { get; set; }
        string Cep { get; set; }
        int CidadeId { get; set; }
        int ClienteId { get; set; }
        string Complemento { get; set; }
        int Id { get; set; }
        string Logradouro { get; set; }
        string Numero { get; set; }
        int TipoEnderecoId { get; set; }
        int UfId { get; set; }
    }
}