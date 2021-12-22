namespace DomainLayer.Clientes.Contratos.Clausulas
{
    public interface IClausulaModel
    {
        int ContratoId { get; set; }
        int Id { get; set; }
        string Titulo { get; set; }
    }
}