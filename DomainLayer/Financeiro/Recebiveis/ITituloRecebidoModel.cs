using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public interface ITituloRecebidoModel
    {
        DateTime DataRecebimento { get; set; }
        int Id { get; set; }
        int TipoRecebimentoId { get; set; }
        int TituloRecebivelId { get; set; }
        double ValorRecebido { get; set; }
        double ValorTitulo { get; set; }
    }
}