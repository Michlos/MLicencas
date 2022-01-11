using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public class EstornoTituloRecebidoModel : IEstornoTituloRecebidoModel
    {
        public int Id { get; set; }
        public int TituloRecebidoId { get; set; }
        public virtual TituloRecebidoModel TituloRecebido { get; set; }
        public DateTime DataRegistro { get; set; }
        public double Valor { get; set; }

    }
}
