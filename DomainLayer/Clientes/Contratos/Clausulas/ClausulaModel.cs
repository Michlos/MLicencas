namespace DomainLayer.Clientes.Contratos.Clausulas
{
    public class ClausulaModel : IClausulaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Termos { get; set; }
        public int Ordem { get; set; }
        public int ContratoId { get; set; }
    }
}
