namespace DomainLayer.Financeiro.Recebiveis
{
    public class DestinoRecebivelModel : IDestinoRecebivelModel
    {
        public int Id { get; set; }
        public string Destino { get; set; }
        public char Codigo { get; set; }

    }
}
