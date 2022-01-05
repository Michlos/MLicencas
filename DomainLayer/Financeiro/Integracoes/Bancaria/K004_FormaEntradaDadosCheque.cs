namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K004_FormaEntradaDadosCheque : IK004_FormaEntradaDadosCheque
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Complemento { get; set; }
    }
}
