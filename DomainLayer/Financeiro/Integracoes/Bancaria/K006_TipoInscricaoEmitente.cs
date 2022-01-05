namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class K006_TipoInscricaoEmitente : IK006_TipoInscricaoEmitente
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
