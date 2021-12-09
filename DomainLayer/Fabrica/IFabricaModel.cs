namespace DomainLayer.Fabrica
{
    public interface IFabricaModel
    {
        string Cnpj { get; set; }
        string Email { get; set; }
        int Id { get; set; }
        string Ie { get; set; }
        string NomeFantasia { get; set; }
        string RazaoSocial { get; set; }
        string WebSite { get; set; }
    }
}