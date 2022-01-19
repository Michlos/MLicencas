namespace DomainLayer.Financeiro.Recebiveis
{
    public class TipoRecebimentoTituloModel : ITipoRecebimentoTituloModel
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public char Destino { get; set; }
    }
}
