namespace DomainLayer.Financeiro
{
    public interface IBancoModel
    {
        string CodigoBc { get; set; }
        int Id { get; set; }
        string Nome { get; set; }
    }
}