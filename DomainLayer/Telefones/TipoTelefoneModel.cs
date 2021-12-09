namespace DomainLayer.Telefones
{
    public class TipoTelefoneModel : ITipoTelefoneModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Mascara { get; set; }
    }
}
