using CommonComponents;

using DomainLayer.Financeiro;

using ServicesLayer.TiposLancamentos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TipoLancamento
{
    public class TipoLancamentoRepository : ITiposLancamentosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private List<ITipoLancamentoModel> tipoListModel;
        private ITipoLancamentoModel tipoModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TipoLancamentoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoLancamentoModel> GetAll()
        {
            _query = "SELECT * FROM TiposLancamentos";
            tipoListModel = new List<ITipoLancamentoModel>();
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
                                tipoModel = new TipoLancamentoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = char.Parse(reader["Tipo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                tipoListModel.Add(tipoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar a lista de Tipos de Lançamentos.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoListModel;
        }

        public ITipoLancamentoModel GetById(int id)
        {
            _query = "SELECT * FROM TiposLancamentos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipoModel = new TipoLancamentoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = char.Parse(reader["Tipo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível recuperar o Tipo de Lançamento pelo Id.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
