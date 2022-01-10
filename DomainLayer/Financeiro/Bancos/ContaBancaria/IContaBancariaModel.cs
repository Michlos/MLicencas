namespace DomainLayer.Financeiro
{
    public interface IContaBancariaModel
    {
        string Agencia { get; set; }
        string AgenciaDV { get; set; }
        int BancoId { get; set; }
        string Conta { get; set; }
        string ContaDV { get; set; }
        bool EmiteBoleto { get; set; }
        int Id { get; set; }
        int TipoContaId { get; set; }
        string Convenio { get; set; }
        double SaldoAnterior { get; set; }
        double SaldoAtual { get; set; }
    }
}