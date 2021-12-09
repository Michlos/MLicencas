namespace DomainLayer.Enderecos
{
    public interface IEstadoModel
    {
        string CodIbge { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
        string Uf { get; set; }
    }
}