using DomainLayer.Clientes;
using DomainLayer.Clientes.Contratos;
using DomainLayer.Financeiro.Integracoes.Bancaria;

using System;

namespace DomainLayer.Financeiro.Recebiveis
{
    public class TituloRecebivelModel : ITituloRecebivelModel
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public virtual ClienteModel Cliente { get; set; }
        public int ContratoId { get; set; }
        public virtual ContratoModel Contrato { get; set; }
        public int CodigoJurosMoraId { get; set; }
        public virtual C018_CodigoJurosMora CodigoJurosMora { get; set; }
        public int CodigoProtestoId { get; set; }
        public virtual C026_CodigoProtesto CodigoProtesto { get; set; }
        public int CodigoBaixaId { get; set; }
        public virtual C028_CodigoBaixaDevolucao CodigoBaixaDevolucao { get; set; }
        public int Parcela { get; set; }
        public int TotalParcelas { get; set; }
        public double ValorParcela { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataJurosMora { get; set; }
        public double TaxaJurosMora { get; set; }
        public int DiasParaProtesto { get; set; }
        public int DiasParaBaixa { get; set; }
        public bool Quitado { get; set; }

    }
}
