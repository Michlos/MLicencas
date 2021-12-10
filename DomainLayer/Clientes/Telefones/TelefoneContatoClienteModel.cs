namespace DomainLayer.Clientes.Telefones
{
    public class TelefoneContatoClienteModel : ITelefoneContatoClienteModel
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Operadora { get; set; }
        public string Ramal { get; set; }
        public int TipoTelefoneId { get; set; }
        public int ContatoId { get; set; }
    }
}
