using DomainLayer.Financeiro.Caixa;

using System;
using System.Collections.Generic;

namespace ServicesLayer.Caixa
{
    public interface ICaixaRepository
    {
        ICaixaModel Add(ICaixaModel caixa);
        IEnumerable<ICaixaModel> GetAll();
        ICaixaModel GetById(int caixaId);
        ICaixaModel GetByDataAbertura(DateTime dataAbertura);
        ICaixaModel UpdateSaldo(double saldoFinal, int caixaId);
        ICaixaModel CloseCaixa(DateTime dataFechamento, int caixaId);

    }
}
