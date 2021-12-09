namespace DomainLayer.Fabrica
{
    public interface ITelefoneContatoFabricaModel
    {
        int ContatoId { get; set; }
        int Id { get; set; }
        string Numero { get; set; }
        string Operadora { get; set; }
        string Ramal { get; set; }
        int TipoTelefonId { get; set; }
    }
}