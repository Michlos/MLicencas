namespace DomainLayer.Usuarios
{
    public interface IGrupo
    {
        int Id { get; set; }
        string Nome { get; set; }
        bool Ativo { get; set; }
    }
}