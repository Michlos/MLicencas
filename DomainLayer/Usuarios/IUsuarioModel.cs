﻿namespace DomainLayer.Usuarios
{
    public interface IUsuarioModel
    {
        string Cargo { get; set; }
        string Cpf { get; set; }
        int GrupoId { get; set; }
        int Id { get; set; }
        string Login { get; set; }
        string Nome { get; set; }
        bool Ativo { get; set; }
        string Senha { get; set; }
        bool AlteraSenha { get; set; }
    }
}