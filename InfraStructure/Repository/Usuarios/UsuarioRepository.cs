using CommonComponents;

using DomainLayer.Usuarios;

using ServicesLayer.Usuarios;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Usuarios
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private string _connectionString;
        private string _query;
        private IUsuarioModel usuarioModel;
        private List<IUsuarioModel> usuariosListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public UsuarioRepository(){}

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUsuarioModel Add(IUsuarioModel usuario)
        {
            _query = "INSERT INTO Usuarios (Login, Nome, Cpf, Cargo, Senha, GrupoId, AlteraSenha) " +
                    " OUTPUT INSERTED.Id " +
                    " VALUES (@Login, @Nome, @Cpf, @Cargo, @Senha, @GrupoId, @AlteraSenha)";
            int idREturned;
            usuarioModel = new UsuarioModel();
            using (SqlConnection connection  = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        
                        cmd.Parameters.AddWithValue("@Login", usuario.Login);
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf);
                        cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
                        cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                        cmd.Parameters.AddWithValue("@GrupoId", usuario.GrupoId);
                        cmd.Parameters.AddWithValue("@AlteraSenha", usuario.AlteraSenha);

                        idREturned = (int)cmd.ExecuteScalar();
                        usuarioModel = GetAll().Where(userId => userId.Id == idREturned).FirstOrDefault();



                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar um novo usuário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return usuarioModel;
        }

        public bool CheckLogin(string usuario, string senha)
        {
            _query = "SELECT * FROM Usuarios WHERE Login = @Login AND Senha = @Senha";
            usuarioModel = new UsuarioModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Login", usuario));
                        cmd.Parameters.Add(new SqlParameter("@Senha", GetHashSenha.GetSenha(senha)));
                        //cmd.Parameters.Add(new SqlParameter("@Senha", senha));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuarioModel.Id = int.Parse(reader["Id"].ToString());
                                usuarioModel.Login = reader["Login"].ToString();
                                usuarioModel.Cpf = reader["Cpf"].ToString();
                                usuarioModel.Nome = reader["Nome"].ToString();
                                usuarioModel.Cargo = reader["Cargo"].ToString();
                                usuarioModel.Senha = reader["Senha"].ToString();
                                usuarioModel.GrupoId = string.IsNullOrEmpty(reader["GrupoId"].ToString()) ? 0 : int.Parse(reader["GrupoId"].ToString());
                                usuarioModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                                usuarioModel.AlteraSenha = bool.Parse(reader["AlteraSenha"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o usuário para login.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

                if (usuarioModel.Id != 0)
                    return true;
                else
                    return false;
            }
        }

        public void Edit(IUsuarioModel usuario)
        {

            _query = "UPDATE Usuarios SET Nome = @Nome, Cargo = @Cargo, GrupoId = @GrupoId, Ativo = @Ativo, Senha = @Senha, AlteraSenha = @AlteraSenha " +
                    " WHERE Id = @Id";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", usuario.Id);
                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
                        cmd.Parameters.AddWithValue("@GrupoId", usuario.GrupoId);
                        cmd.Parameters.AddWithValue("@Ativo", usuario.Ativo);
                        cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                        cmd.Parameters.AddWithValue("@AlteraSenha", usuario.AlteraSenha);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar o registro do usuário.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IUsuarioModel> GetAll()
        {
            usuariosListModel = new List<IUsuarioModel>();
            IUsuarioModel usuario = new UsuarioModel();
            _query = "SELECT * FROM Usuarios";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario.Id = int.Parse(reader["Id"].ToString());
                                usuario.Login = reader["Login"].ToString();
                                usuario.Cpf = reader["Cpf"].ToString();
                                usuario.Nome = reader["Nome"].ToString();
                                usuario.Cargo = reader["Cargo"].ToString();
                                usuario.Senha =  reader["Senha"].ToString();
                                usuario.GrupoId = string.IsNullOrEmpty(reader["GrupoId"].ToString()) ? 0 : int.Parse(reader["GrupoId"].ToString());
                                usuario.Ativo = bool.Parse(reader["Ativo"].ToString());
                                usuario.AlteraSenha = bool.Parse(reader["AlteraSenha"].ToString());

                                usuariosListModel.Add(usuario);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível carregar a lista de Usuários.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return usuariosListModel;
        }

        public IUsuarioModel GetByLogin(string login)
        {
            
            IUsuarioModel usuario = new UsuarioModel();
            _query = "SELECT * FROM Usuarios WHERE Login = @Login";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Login", login));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                usuario.Id = int.Parse(reader["Id"].ToString());
                                usuario.Login = reader["Login"].ToString();
                                usuario.Cpf = reader["Cpf"].ToString();
                                usuario.Nome = reader["Nome"].ToString();
                                usuario.Cargo = reader["Cargo"].ToString();
                                usuario.Senha = reader["Senha"].ToString();
                                usuario.GrupoId = string.IsNullOrEmpty(reader["GrupoId"].ToString()) ? 0 : int.Parse(reader["GrupoId"].ToString());
                                usuario.Ativo = bool.Parse(reader["Ativo"].ToString());
                                usuario.AlteraSenha = bool.Parse(reader["AlteraSenha"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível carregar a lista de Usuários.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return usuario;
        }
    }
}
