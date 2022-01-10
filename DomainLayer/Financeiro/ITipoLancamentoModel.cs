namespace DomainLayer.Financeiro
{
    public interface ITipoLancamentoModel
    {
        string Descricao { get; set; }
        int Id { get; set; }
        char Tipo { get; set; }
    }
}