namespace DomainLayer.Usuarios
{
    public interface IGrupoModel
    {
        int Id { get; set; }
        string Nome { get; set; }
        bool Ativo { get; set; }
    }
}