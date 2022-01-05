namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class C047A_TipoMotivoOcorrencia : IC047A_TipoMotivoOcorrencia
    {
        public int Id { get; set; }
        public char Tipo { get; set; }
        public string Descricao { get; set; }
    }
}
