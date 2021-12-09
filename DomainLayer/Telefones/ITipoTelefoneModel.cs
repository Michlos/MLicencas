namespace DomainLayer.Telefones
{
    public interface ITipoTelefoneModel
    {
        int Id { get; set; }
        string Mascara { get; set; }
        string Tipo { get; set; }
    }
}