﻿namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public interface IG091_TipoLancamento
    {
        char Codigo { get; set; }
        string Descricao { get; set; }
        int Id { get; set; }
    }
}