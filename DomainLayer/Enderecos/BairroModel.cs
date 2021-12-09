namespace DomainLayer.Enderecos
{
    public class BairroModel : IBairroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CidadeId { get; set; }
    }
}
