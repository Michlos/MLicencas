using DomainLayer.Situacao;

using System.Collections.Generic;

namespace ServicesLayer.SituacoesServices
{
    public interface ISituacoesRepository
    {
        IEnumerable<ISituacaoModel> GetAll();
        ISituacaoModel GetById(int situacaoId);
    }
}
