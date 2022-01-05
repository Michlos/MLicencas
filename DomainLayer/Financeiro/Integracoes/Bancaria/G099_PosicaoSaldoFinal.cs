namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G099_PosicaoSaldoFinal : IG099_PosicaoSaldoFinal
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
