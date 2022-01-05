namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IC047_MotivoOcorrencia
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
        char LiquidacaoBaixa { get; set; }
        int TipoId { get; set; }
    }
}