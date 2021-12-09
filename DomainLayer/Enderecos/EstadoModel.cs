namespace DomainLayer.Enderecos
{
    public class EstadoModel : IEstadoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string CodIbge { get; set; }
    }
}
