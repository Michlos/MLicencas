namespace DomainLayer.Usuarios
{
    public interface IPermissaoModel
    {
        bool Ativo { get; set; }
        int ModuloId { get; set; }
        int GrupId { get; set; }
        int Id { get; set; }
    }
}