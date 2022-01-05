namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IK004_FormaEntradaDadosCheque
    {
        int Codigo { get; set; }
        string Complemento { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}