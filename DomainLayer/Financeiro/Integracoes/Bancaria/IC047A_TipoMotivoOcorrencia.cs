namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IC047A_TipoMotivoOcorrencia
    {
        string Descricao { get; set; }
        int Id { get; set; }
        char Tipo { get; set; }
    }
}