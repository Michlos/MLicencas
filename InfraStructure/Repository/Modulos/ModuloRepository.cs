using CommonComponents;

using DomainLayer.Modulos;

using ServicesLayer.Modulos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Modulos
{
    public class ModuloRepository : IModulosRepository
    {
        private string _connectionString;
        private string _query;
        private IModuloModel moduloModel;
        private List<IModuloModel> modulosListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ModuloRepository() { }

        public ModuloRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IModuloModel Add(IModuloModel modulo)
        {
            _query = "INSERT INTO Modulos (Nome, Nivel, Ativo) " +
                     " OUTPUT INSERTED.Id " +
                     " VALUES (@Nome, @Nivel, @Ativo)";
            int returnedId;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", modulo.Nome);
                        cmd.Parameters.AddWithValue("@Nivel", modulo.Nivel);
                        cmd.Parameters.AddWithValue("@Ativo", modulo.Ativo);
                        returnedId = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o módulo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            moduloModel = new ModuloModel();
            if (returnedId != 0)
            {
                moduloModel = GetById(returnedId);
            }
            return moduloModel;
        }

        public IModuloModel Edit(IModuloModel modulo)
        {
            _query = " UPDATE Modulos " +
                     " SET (Nome = @Nome, Nivel = @Nivel, Ativo = @Ativo) " +
                     " WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", modulo.Id);
                        cmd.Parameters.AddWithValue("@Nome", modulo.Nome);
                        cmd.Parameters.AddWithValue("@Nivel", modulo.Nivel);
                        cmd.Parameters.AddWithValue("@Ativo", modulo.Ativo);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar o módulo", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return modulo;
        }

        public IEnumerable<IModuloModel> GetAll()
        {
            _query = " SELECT * FROM Modulos";
            modulosListModel = new List<IModuloModel>();
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
                                moduloModel = new ModuloModel();
                                moduloModel.Id = int.Parse(reader["Id"].ToString());
                                moduloModel.Nome = reader["Nome"].ToString();
                                moduloModel.Nivel = reader["Nivel"].ToString();
                                moduloModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                                modulosListModel.Add(moduloModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de módulos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return modulosListModel;

        }

        public IModuloModel GetByHieraquia(string nivel)
        {
            _query = " SELECT * FROM Modulos WHERE Nivel = @Nivel";
            moduloModel = new ModuloModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Nivel", nivel));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                moduloModel.Id = int.Parse(reader["Id"].ToString());
                                moduloModel.Nome = reader["Nome"].ToString();
                                moduloModel.Nivel = reader["Nivel"].ToString();
                                moduloModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados do Módulo pelo Nível", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return moduloModel;
        }

        public IModuloModel GetById(int moduloId)
        {
            _query = " SELECT * FROM Modulos WHERE Id = @Id";
            moduloModel = new ModuloModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", moduloId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                moduloModel.Id = int.Parse(reader["Id"].ToString());
                                moduloModel.Nome = reader["Nome"].ToString();
                                moduloModel.Nivel = reader["Nivel"].ToString();
                                moduloModel.Ativo = bool.Parse(reader["Ativo"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados do Módulo pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return moduloModel;
        }
    }
}
