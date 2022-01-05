namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G081_SituacaoSaldoInicial : IG081_SituacaoSaldoInicial
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
