using CommonComponents;

using DomainLayer.Financeiro.Caixa;

using ServicesLayer.EstornosCaixa;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.EstornosCaixa
{
    public class EstornoCaixaRepository : IEstornosCaixaRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IEstornoCaixaModel estornoCaixaModel;
        private List<IEstornoCaixaModel> estornoCaixaListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public EstornoCaixaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEstornoCaixaModel Add(IEstornoCaixaModel estornoModel)
        {
            _query = "INSERT INTO EstornosCaixa " +
                     "(LancamentoCaixaId, TipoLancamentoId, Valor) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@LancamentoCaixaId, @TipoLancamentoId, @Valor) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@LancamentoCaixaId", estornoModel.LancamentoCaixaId);
                        cmd.Parameters.AddWithValue("@TipoLancamentoId", estornoModel.TipoLancamentoId);
                        cmd.Parameters.AddWithValue("@Valor", estornoModel.Valor);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o Estorno do Lançamento do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            estornoCaixaModel = new EstornoCaixaModel();
            if (idReturned != 0)
            {
                estornoCaixaModel = GetById(idReturned);
            }
            return estornoCaixaModel;
        }

        public IEnumerable<IEstornoCaixaModel> GetAll()
        {
            _query = "SELECT * FROM EstornosCaixa";
            estornoCaixaListModel = new List<IEstornoCaixaModel>();
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
                                estornoCaixaModel = new EstornoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoCaixaId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                                estornoCaixaListModel.Add(estornoCaixaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Estornos de Lançamentos de Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoCaixaListModel;
        }

        public IEstornoCaixaModel GetById(int estornoId)
        {
            _query = "SELECT * FROM EstornosCaixa WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", estornoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estornoCaixaModel = new EstornoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoCaixaId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estorno de Lançamento de Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoCaixaModel;
        }

        public IEstornoCaixaModel GetByLancamentoId(int lancamentoId)
        {
            _query = "SELECT * FROM EstornosCaixa WHERE LancamentoCaixaId = @LancamentoCaixaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@LancamentoCaixaId", lancamentoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                estornoCaixaModel = new EstornoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoCaixaId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estorno de Lançamento de Caixa pelo Número do Lançamento", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoCaixaModel;
        }

        public void Remove(int estornoId)
        {
            _query = "DELETE FROM EstornosCaixa WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", estornoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível deletar o registro do estorno.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

        }
    }
}
