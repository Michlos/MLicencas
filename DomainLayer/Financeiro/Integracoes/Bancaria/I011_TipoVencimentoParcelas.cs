namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class I011_TipoVencimentoParcelas : II011_TipoVencimentoParcelas
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Detalhe { get; set; }
    }
}
