namespace DomainLayer.Clientes.Contratos.Clausulas
{
    public class ClausulaModel : IClausulaModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Titulo { get; set; }
        public int ContratoId { get; set; }
    }
}
