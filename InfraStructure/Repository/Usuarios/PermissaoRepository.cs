using CommonComponents;

using DomainLayer.Usuarios;

using ServicesLayer.Usuarios;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.Usuarios
{
    public class PermissaoRepository : IPermissoesRepository
    {
        private string _connectionString;
        private string _query;
        private IPermissaoModel permissaoModel;
        private List<IPermissaoModel> perissaoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();


        public PermissaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IPermissaoModel Add(IPermissaoModel permissao)
        {
            permissaoModel = new PermissaoModel();
            int returnedId;
            _query = "INSERT INTO Permissoes (GrupoId, ModuloId, Ativo) " +
                     " OUTPUT INSERTED.Id " +
                     " VALUES (@GupoId, @ModuloId, @Ativo)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("GrupoId", permissao.GrupId);
                        cmd.Parameters.AddWithValue("ModuloId", permissao.ModuloId);
                        cmd.Parameters.AddWithValue("Ativo", permissao.Ativo);

                        returnedId = (int)cmd.ExecuteScalar();

                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar a permissão", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            if (returnedId != 0)
            {
                permissaoModel = GetById(returnedId);
            }
            return permissaoModel;
        }

        public void Desable(int permissaoId)
        {
            _query = "UPDATE Permissoes SET Ativo = 0 WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", permissaoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Desabilitar a Permissão", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Enable(int permissaoId)
        {
            _query = "UPDATE Permissoes SET Ativo = 1 WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", permissaoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Habilitar a Permissão", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IPermissaoModel> GetAll()
        {
            perissaoListModel = new List<IPermissaoModel>();
            _query = "SELECT * FROM Permissoes";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissaoModel = new PermissaoModel();

                            permissaoModel.Id = int.Parse(reader["Id"].ToString());
                            permissaoModel.GrupId = int.Parse(reader["GrupoId"].ToString());
                            permissaoModel.ModuloId = int.Parse(reader["ModuloId"].ToString());
                            permissaoModel.Ativo = bool.Parse(reader["Ativo"].ToString());

                            perissaoListModel.Add(permissaoModel);

                        }
                    }
                }
            }
            return perissaoListModel;
        }

        public IEnumerable<IPermissaoModel> GetAllByGrupo(int grupoId)
        {
            perissaoListModel = new List<IPermissaoModel>();
            _query = "SELECT * FROM Permissoes WHERE GrupoId = @GrupoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_query, connection))
                {
                    cmd.Prepare();
                    cmd.Parameters.Add(new SqlParameter("@GrupoId", grupoId));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissaoModel = new PermissaoModel();

                            permissaoModel.Id = int.Parse(reader["Id"].ToString());
                            permissaoModel.GrupId = int.Parse(reader["GrupoId"].ToString());
                            permissaoModel.ModuloId = int.Parse(reader["ModuloId"].ToString());
                            permissaoModel.Ativo = bool.Parse(reader["Ativo"].ToString());

                            perissaoListModel.Add(permissaoModel);

                        }
                    }
                }
            }
            return perissaoListModel;
        }

        public IPermissaoModel GetById(int permissaoId)
        {
            permissaoModel = new PermissaoModel();
            _query = "SELECT * FROM Permissoes WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_query, connection))
                {
                    cmd.Prepare();
                    cmd.Parameters.Add(new SqlParameter("@Id", permissaoId));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissaoModel.Id = int.Parse(reader["Id"].ToString());
                            permissaoModel.GrupId = int.Parse(reader["GrupoId"].ToString());
                            permissaoModel.ModuloId = int.Parse(reader["ModuloId"].ToString());
                            permissaoModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                        }
                    }
                }
            }
            return permissaoModel;
        }

        public bool GetPermissao(IPermissaoModel permissao)
        {
            permissaoModel = new PermissaoModel();
            _query = "SELECT * FROM Permissoes WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_query, connection))
                {
                    cmd.Prepare();
                    cmd.Parameters.Add(new SqlParameter("@Id", permissao.Id));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            permissaoModel.Id = int.Parse(reader["Id"].ToString());
                            permissaoModel.GrupId = int.Parse(reader["GrupoId"].ToString());
                            permissaoModel.ModuloId = int.Parse(reader["ModuloId"].ToString());
                            permissaoModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                        }
                    }
                }
            }
            return permissaoModel.Ativo;
        }
    }
}
