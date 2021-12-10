namespace DomainLayer.Softwares
{
    public class SoftwareModel : ISoftwareModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string PublicoAlvo { get; set; }
        public string Versao { get; set; }
        public bool ClienteServidor { get; set; }
        public int PlataformaId { get; set; }
        public int OsId { get; set; }
    }
}
