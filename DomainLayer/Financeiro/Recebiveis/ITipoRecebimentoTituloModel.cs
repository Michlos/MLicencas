namespace DomainLayer.Financeiro.Recebiveis
{
    public interface ITipoRecebimentoTituloModel
    {
        int Id { get; set; }
        string Tipo { get; set; }
        char Destino { get; set; }
    }
}