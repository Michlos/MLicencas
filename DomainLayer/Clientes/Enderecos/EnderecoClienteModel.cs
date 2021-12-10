﻿namespace DomainLayer.Clientes.Enderecos
{
    public class EnderecoClienteModel : IEnderecoClienteModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int UfId { get; set; }
        public int CidadeId { get; set; }
        public int BairroId { get; set; }
        public int TipoEnderecoId { get; set; }
        public int ClienteId { get; set; }
    }
}
