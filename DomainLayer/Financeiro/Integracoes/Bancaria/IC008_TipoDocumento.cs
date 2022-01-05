namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IC008_TipoDocumento
    {
        int Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}