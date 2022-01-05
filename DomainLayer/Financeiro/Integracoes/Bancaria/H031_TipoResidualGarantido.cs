namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H031_TipoResidualGarantido : IH031_TipoResidualGarantido
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
