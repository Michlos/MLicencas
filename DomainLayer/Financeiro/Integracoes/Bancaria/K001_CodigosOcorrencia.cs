namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K001_CodigosOcorrencia : IK001_CodigosOcorrencia
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
