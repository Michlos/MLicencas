namespace DomainLayer.Financeiro.Recebiveis
{
    public interface IDestinoRecebivelModel
    {
        char Codigo { get; set; }
        string Destino { get; set; }
        int Id { get; set; }
    }
}