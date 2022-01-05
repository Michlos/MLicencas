namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G028_TipoOperacao : IG028_TipoOperacao
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
