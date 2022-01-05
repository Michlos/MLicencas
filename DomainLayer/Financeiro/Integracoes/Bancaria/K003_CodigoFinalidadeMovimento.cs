namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K003_CodigoFinalidadeMovimento : IK003_CodigoFinalidadeMovimento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
