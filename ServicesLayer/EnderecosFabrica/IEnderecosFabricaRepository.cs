using DomainLayer.Fabrica;

using System.Collections.Generic;

namespace ServicesLayer.EnderecosFabricaServices
{
    public interface IEnderecosFabricaRepository
    {
        IEnderecoFabricaModel Add(IEnderecoFabricaModel endereco);
        void Edit(IEnderecoFabricaModel endereco);
        IEnderecoFabricaModel GetById(int enderecoId);
        IEnumerable<IEnderecoFabricaModel> GetAll();

    }
}
