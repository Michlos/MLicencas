namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class C047_MotivoOcorrencia : IC047_MotivoOcorrencia
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public char LiquidacaoBaixa { get; set; }
    }
}
