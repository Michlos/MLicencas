namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G082_PosicaoSaldoInicial : IG082_PosicaoSaldoInicial
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
