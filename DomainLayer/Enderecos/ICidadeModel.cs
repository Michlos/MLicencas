namespace DomainLayer.Enderecos
{
    public interface ICidadeModel
    {
        string CodIbge { get; set; }
        int EstadoId { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
        string Uf { get; set; }
    }
}