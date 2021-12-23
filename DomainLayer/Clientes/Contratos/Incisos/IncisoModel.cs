namespace DomainLayer.Clientes.Contratos.Incisos
{
    public class IncisoModel : IIncisoModel
    {
        public int Id { get; set; }
        public int ClausulaId { get; set; }
        public int Numero { get; set; }
        public string Termo { get; set; }
    }
}
