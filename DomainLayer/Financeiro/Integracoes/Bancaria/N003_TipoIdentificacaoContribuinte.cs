namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class N003_TipoIdentificacaoContribuinte : IN003_TipoIdentificacaoContribuinte
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
