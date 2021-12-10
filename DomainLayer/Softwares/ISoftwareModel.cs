namespace DomainLayer.Softwares
{
    public interface ISoftwareModel
    {
        bool ClienteServidor { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
        int OsId { get; set; }
        int PlataformaId { get; set; }
        string PublicoAlvo { get; set; }
        string Versao { get; set; }
    }
}