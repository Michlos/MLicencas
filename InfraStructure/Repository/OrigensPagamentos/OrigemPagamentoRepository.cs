using CommonComponents;

using DomainLayer.Financeiro.Pagaveis;

using ServicesLayer.OrigensPagamentos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.OrigensPagamentos
{
    public class OrigemPagamentoRepository : IOrigensPagamentosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private readonly List<IOrigemPagamentoModel> origemListModel = new List<IOrigemPagamentoModel>();
        private IOrigemPagamentoModel origemModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public OrigemPagamentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IOrigemPagamentoModel> GetAll()
        {
            _query = "SELECT * FROM OrigensPagamentos";
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
                                origemModel = new OrigemPagamentoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Origem = reader["Origem"].ToString()
                                };
                                origemListModel.Add(origemModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Origens de Pagamentos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return origemListModel;
        }

        public IOrigemPagamentoModel GetById(int origemId)
        {
            _query = "SELECT * FROM OrigensPagamentos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", origemId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                origemModel = new OrigemPagamentoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Origem = reader["Origem"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Origens de Pagamentos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return origemModel;
        }
    }
}
