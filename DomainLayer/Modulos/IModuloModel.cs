namespace DomainLayer.Modulos
{
    public interface IModuloModel
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Ativo { get; set; }
    }
}