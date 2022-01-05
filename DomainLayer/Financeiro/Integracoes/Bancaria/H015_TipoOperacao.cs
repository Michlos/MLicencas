namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class H015_TipoOperacao : IH015_TipoOperacao
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
