using CommonComponents;

using DomainLayer.Financeiro;

using ServicesLayer.TiposContasBancarias;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.TiposContasBancarias
{
    public class TipoContaBancariaRepository : ITiposContasBancariasRepository
    {
        private readonly string _connectionString;
        private string _query;
        private ITipoContaBancariaModel tipoModel;
        private List<ITipoContaBancariaModel> tipoListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TipoContaBancariaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoContaBancariaModel> GetAll()
        {
            _query = "SELECT * FROM TipoContaBancaria";

            tipoListModel = new List<ITipoContaBancariaModel>();
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
                                tipoModel = new TipoContaBancariaModel();

                                tipoModel.Id = int.Parse(reader["Id"].ToString());
                                tipoModel.Tipo = reader["Tipo"].ToString();

                                tipoListModel.Add(tipoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Contas Bancárias", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoListModel;
        }

        public ITipoContaBancariaModel GetById(int tipoId)
        {
            _query = "SELECT * FROM TipoContaBancaria WHERE Id = @Id";
            tipoModel = new TipoContaBancariaModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", tipoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipoModel.Id = int.Parse(reader["Id"].ToString());
                                tipoModel.Tipo = reader["Tipo"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o tipo de conta pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoModel;
        }

        public ITipoContaBancariaModel GetByTipo(string tipoNome)
        {
            _query = "SELECT * FROM TipoContaBancaria WHERE Tipo = @Tipo";
            tipoModel = new TipoContaBancariaModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Tipo", tipoNome));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipoModel.Id = int.Parse(reader["Id"].ToString());
                                tipoModel.Tipo = reader["Tipo"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o tipo de conta pela descrição.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoModel;
        }
    }
}
