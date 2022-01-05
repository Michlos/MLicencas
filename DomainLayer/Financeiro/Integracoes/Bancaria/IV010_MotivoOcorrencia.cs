namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IV010_MotivoOcorrencia
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
        char LiquidacaoBaixa { get; set; }
        int TipoId { get; set; }
    }
}