namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class P006_AvisoFavorecido : IP006_AvisoFavorecido
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
