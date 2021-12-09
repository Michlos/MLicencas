namespace DomainLayer.Fabrica
{
    public interface IContatoFabricaModel
    {
        string Cargo { get; set; }
        string Email { get; set; }
        int FabricaId { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
    }
}