namespace DomainLayer.Fabrica
{
    public class TelefoneContatoFabricaModel : ITelefoneContatoFabricaModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Operadora { get; set; }
        public string Ramal { get; set; }
        public int TipoTelefonId { get; set; }
        public int ContatoId { get; set; }

    }
}
