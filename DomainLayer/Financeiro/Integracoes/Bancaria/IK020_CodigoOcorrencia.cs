namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IK020_CodigoOcorrencia
    {
        string Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}