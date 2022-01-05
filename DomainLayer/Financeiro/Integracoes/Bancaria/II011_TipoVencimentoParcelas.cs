namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface II011_TipoVencimentoParcelas
    {
        int Codigo { get; set; }
        string Descricao { get; set; }
        string Detalhe { get; set; }
        int Id { get; set; }
    }
}