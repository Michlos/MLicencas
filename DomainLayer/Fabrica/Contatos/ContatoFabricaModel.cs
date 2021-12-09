namespace DomainLayer.Fabrica
{
    public class ContatoFabricaModel : IContatoFabricaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public int FabricaId { get; set; }
    }
}
