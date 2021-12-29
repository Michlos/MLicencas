namespace DomainLayer.Financeiro
{
    public class BancoModel : IBancoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CodigoBc { get; set; }
    }
}
