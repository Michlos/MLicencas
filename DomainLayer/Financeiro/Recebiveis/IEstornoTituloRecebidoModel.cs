using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public interface IEstornoTituloRecebidoModel
    {
        DateTime DataRegistro { get; set; }
        int Id { get; set; }
        int TituloRecebidoId { get; set; }
        double Valor { get; set; }
    }
}