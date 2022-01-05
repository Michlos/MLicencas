namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class N005_CodigoIdentificacaoTributo : IN005_CodigoIdentificacaoTributo
    {
        public int Id { get; set; }
        public int TipoId { get; set; }
        public string Codigo { get; set; }
        public string Desricao { get; set; }
    }
}
