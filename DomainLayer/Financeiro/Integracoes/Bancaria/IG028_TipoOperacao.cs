namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG028_TipoOperacao
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}