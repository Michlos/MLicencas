namespace DomainLayer.Modulos
{
    public interface IModuloModel
    {
        int Id { get; set; }
        string Nome { get; set; }
        string Nivel { get; set; }
        bool Ativo { get; set; }
    }
}