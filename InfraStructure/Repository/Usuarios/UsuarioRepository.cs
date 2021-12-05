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
        private IEnumerable<IUsuarioModel> usuariosListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public UsuarioRepository(){}

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUsuarioModel Add(IUsuarioModel usuario)
        {
            _query = "INSERT INTO Usuarios (Login, Nome, Cpf, Cargo) " +
                    " OUTPUT INSERTED.Id " +
                    " VALUES (@Login, @Nome, @Cpf, @Cargo)";
            int idREturned;
            usuariosListModel = new List<IUsuarioModel>();
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

                        idREturned = (int)cmd.ExecuteScalar();
                        usuariosListModel = GetAll();



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

            return usuariosListModel.Where(userId => userId.Id == idREturned).FirstOrDefault();
        }

        public void Edit(IUsuarioModel usuario)
        {
            int idToEdit = usuario.Id;

            _query = "UPDATE Usuarios SET @Nome = Nome, @Cargo = Cargo, @GrupoId = GrupoId, @Ativo = Ativo " +
                    " WHERE Id = idToEdit";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                        cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo);
                        cmd.Parameters.AddWithValue("@GrupoId", usuario.GrupoId);
                        cmd.Parameters.AddWithValue("@Ativo", usuario.Ativo);

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
                                usuario.GrupoId = string.IsNullOrEmpty(reader["GrupoId"].ToString()) ? 0 : int.Parse(reader["GrupoId"].ToString());
                                usuario.Ativo = bool.Parse(reader["Ativo"].ToString());

                                usuariosListModel.Append<IUsuarioModel>(usuario);
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
    }
}
