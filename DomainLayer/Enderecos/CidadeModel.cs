namespace DomainLayer.Enderecos
{
    public class CidadeModel : ICidadeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string CodIbge { get; set; }
        public int EstadoId { get; set; }
    }
}
