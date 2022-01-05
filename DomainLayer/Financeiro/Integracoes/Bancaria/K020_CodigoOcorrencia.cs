namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K020_CodigoOcorrencia : IK020_CodigoOcorrencia
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
