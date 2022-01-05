namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class V010A_TipoMotivoOcorrencia : IV010A_TipoMotivoOcorrencia
    {
        public int Id { get; set; }
        public char Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
