namespace DomainLayer.Clientes.Contratos.Incisos
{
    public interface IIncisoModel
    {
        int ClausulaId { get; set; }
        int Id { get; set; }
        string Termo { get; set; }
        int Numero { get; set; }
    }
}