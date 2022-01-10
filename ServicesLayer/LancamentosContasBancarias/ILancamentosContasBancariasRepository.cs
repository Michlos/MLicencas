using DomainLayer.Financeiro.Bancos.ContaBancaria;

using System;
using System.Collections.Generic;

namespace ServicesLayer.LancamentosContasBancarias
{
    public interface ILancamentosContasBancariasRepository
    {
        ILancamentoContaBancariaModel Add(ILancamentoContaBancariaModel lancamento);
        void Edit(ILancamentoContaBancariaModel lancamento);
        IEnumerable<ILancamentoContaBancariaModel> GetAll();
        IEnumerable<ILancamentoContaBancariaModel> GetAllByContaId(int contaId);
        IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndMonth(int contaId, int month);
        IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndDatas(int contaId, DateTime dataIni, DateTime dataFim);
        ILancamentoContaBancariaModel GetById(int lancamentoId);
    }
}
