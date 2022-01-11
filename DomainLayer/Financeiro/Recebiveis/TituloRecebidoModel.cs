using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public class TituloRecebidoModel : ITituloRecebidoModel
    {
        public int Id { get; set; }
        public int TituloRecebivelId { get; set; }
        public virtual TituloRecebivelModel TituloRecebivel { get; set; }
        public int TipoRecebimentoId { get; set; }
        public virtual TipoRecebimentoTituloModel TipoRecebimento { get; set; }
        public double ValorTitulo { get; set; }
        public double ValorRecebido { get; set; }
        public DateTime DataRecebimento { get; set; }
        public bool Estornado { get; set; }

    }
}
