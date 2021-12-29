namespace DomainLayer.Financeiro
{
    public class ContaBancariaModel : IContaBancariaModel
    {
        public int Id { get; set; }
        public int BancoId { get; set; }
        public virtual BancoModel BancoModel { get; set; }
        public int TipoContaId { get; set; }
        public virtual TipoContaBancariaModel TipoContaBancaira { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDV { get; set; }
        public string Conta { get; set; }
        public string ContaDV { get; set; }
        public bool EmiteBoleto { get; set; }
    }
}
