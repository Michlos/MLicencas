namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG082_PosicaoSaldoInicial
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}