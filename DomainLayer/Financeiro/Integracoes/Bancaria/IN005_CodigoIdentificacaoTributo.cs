namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IN005_CodigoIdentificacaoTributo
    {
        string Codigo { get; set; }
        string Desricao { get; set; }
        int Id { get; set; }
        int TipoId { get; set; }
    }
}