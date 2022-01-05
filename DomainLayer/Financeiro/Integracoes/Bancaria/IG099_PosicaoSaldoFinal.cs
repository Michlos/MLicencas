namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG099_PosicaoSaldoFinal
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}