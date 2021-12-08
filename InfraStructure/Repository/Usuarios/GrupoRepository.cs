using CommonComponents;

using DomainLayer.Usuarios;

using ServicesLayer.Usuarios;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.Usuarios
{
    public class GrupoRepository : IGruposRepository
    {
        private string _connectionString;
        private string _query;
        private IGrupoModel grupoModel;
        private List<IGrupoModel> grupoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public GrupoRepository(){}

        public GrupoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IGrupoModel Add(IGrupoModel grupo)
        {
            _query = "INSERT INTO Grupos (Nome, Ativo) " +
                     " OUTPUT INSERTED.Id " +
                     " VALUES (@Nome, @Ativo)";
            int returnedId;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", grupo.Nome);
                        cmd.Parameters.AddWithValue("@Ativo", grupo.Ativo);

                        returnedId = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar novo Grupo de Acesso", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            grupoModel = new GrupoModel();
            if (returnedId != 0)
            {
                grupoModel = GetById(returnedId);
            }
            return grupoModel;
        }

        public void Edit(IGrupoModel grupo)
        {
            _query = "UPDATE Grupos SET Nome=@Nome, Ativo=@Ativo WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", grupo.Id);
                        cmd.Parameters.AddWithValue("@Nome", grupo.Nome);
                        cmd.Parameters.AddWithValue("@Ativo", grupo.Ativo);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar dados do Grupo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IGrupoModel> GetAll()
        {
            grupoListModel = new List<IGrupoModel>();
            _query = "SELECT * FROM Grupos";
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
                                grupoModel = new GrupoModel();
                                grupoModel.Id = int.Parse(reader["Id"].ToString());
                                grupoModel.Nome = reader["Nome"].ToString();
                                grupoModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                                grupoListModel.Add(grupoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Grupos de Acesso", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return grupoListModel;
        }

        public IGrupoModel GetById(int grupoId)
        {
            grupoModel = new GrupoModel();
            _query = "SELECT * FROM Grupos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", grupoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                grupoModel.Id = int.Parse(reader["Id"].ToString());
                                grupoModel.Nome = reader["Nome"].ToString();
                                grupoModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Grupo pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
            }
            return grupoModel;
        }
    }
}
