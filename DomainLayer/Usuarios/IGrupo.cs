namespace DomainLayer.Usuarios
{
    public interface IGrupo
    {
        int Classe { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
    }
}