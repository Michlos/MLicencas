namespace DomainLayer.Usuarios
{
    public interface IPermissaoModel
    {
        string Descricao { get; set; }
        int GrupId { get; set; }
        int Id { get; set; }
        int ModuloId { get; set; }
        string Nome { get; set; }
    }
}