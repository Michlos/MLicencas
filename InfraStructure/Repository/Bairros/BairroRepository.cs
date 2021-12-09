using CommonComponents;

using DomainLayer.Enderecos;

using ServicesLayer.Bairros;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Bairros
{
    public class BairroRepository : IBairrosRepository
    {
        private string _connectionString;
        private string _query;
        private IBairroModel bairroModel;
        private List<IBairroModel> bairroListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public BairroRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IBairroModel Add(IBairroModel bairroModel)
        {
            int returnedId;
            this.bairroModel = new BairroModel();
            _query = "INSERT INTO Bairros (Nome, CidadeId) OUTPUT INSERTED.Id VALUES (@Nome, @CidadeId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Nome", bairroModel.Nome);
                        cmd.Parameters.AddWithValue("@CidadeId", bairroModel.CidadeId);

                        returnedId = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o Bairro", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            if (returnedId != 0)
            {
                this.bairroModel = GetById(returnedId);
            }
            return this.bairroModel;
        }

        public void Edit(IBairroModel bairroModel)
        {
            _query = "UPDATE Bairros SET Nome = @Nome WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", bairroModel.Id);
                        cmd.Parameters.AddWithValue("@Nome", bairroModel.Nome);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar o nome do Bairro", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IBairroModel> GetAll()
        {
            this.bairroListModel = new List<IBairroModel>();
            _query = "SELECT * FROM Bairros";
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
                                this.bairroModel = new BairroModel();

                                this.bairroModel.Id = int.Parse(reader["Id"].ToString());
                                this.bairroModel.Nome = reader["Nome"].ToString();
                                this.bairroModel.CidadeId = int.Parse(reader["CidadeId"].ToString());

                                this.bairroListModel.Add(this.bairroModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Todos os Bairros", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.bairroListModel;
        }

        public IEnumerable<IBairroModel> GetAllByCidadeId(int cidadeId)
        {
            this.bairroListModel = new List<IBairroModel>();
            _query = "SELECT * FROM Bairros WHERE CidadeId = @CidadeId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CidadeId", cidadeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.bairroModel = new BairroModel();

                                this.bairroModel.Id = int.Parse(reader["Id"].ToString());
                                this.bairroModel.Nome = reader["Nome"].ToString();
                                this.bairroModel.CidadeId = int.Parse(reader["CidadeId"].ToString());

                                this.bairroListModel.Add(this.bairroModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Bairros da Cidade Selecionada", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.bairroListModel;
        }

        public IBairroModel GetById(int bairroId)
        {
            this.bairroModel = new BairroModel();
            _query = "SELECT * FROM Bairros WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", bairroId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.bairroModel.Id = int.Parse(reader["Id"].ToString());
                                this.bairroModel.Nome = reader["Nome"].ToString();
                                this.bairroModel.CidadeId = int.Parse(reader["CidadeId"].ToString());

                                this.bairroListModel.Add(this.bairroModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados do Bairro", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.bairroModel;
        }
    }
}
