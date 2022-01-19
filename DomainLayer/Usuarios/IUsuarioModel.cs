namespace DomainLayer.Usuarios
{
    public interface IUsuarioModel
    {
        bool AlteraSenha { get; set; }
        bool Ativo { get; set; }
        string Cargo { get; set; }
        string Cpf { get; set; }
        int GrupoId { get; set; }
        int Id { get; set; }
        string Login { get; set; }
        string Nome { get; set; }
        string Senha { get; set; }
    }
}