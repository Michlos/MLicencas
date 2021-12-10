namespace DomainLayer.Clientes
{
    public class ClienteModel : IClienteModel
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public int SituacaoId { get; set; }
    }
}
