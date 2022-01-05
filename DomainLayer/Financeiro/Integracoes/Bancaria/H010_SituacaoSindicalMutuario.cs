namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H010_SituacaoSindicalMutuario : IH010_SituacaoSindicalMutuario
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
