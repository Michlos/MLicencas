namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class I015_FormaPagamento : II015_FormaPagamento
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
