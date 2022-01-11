using CommonComponents;

using DomainLayer.Financeiro.Caixa;

using ServicesLayer.LancamentosCaixa;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.LancamentosCaixa
{
    public class LancamentoCaixaRepository : ILancamentosCaixaRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private ILancamentoCaixaModel lancamentoModel;
        private List<ILancamentoCaixaModel> lancamentoListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public LancamentoCaixaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ILancamentoCaixaModel Add(ILancamentoCaixaModel lancamento)
        {
            lancamentoModel = new LancamentoCaixaModel();
            _query = "INSERT INTO LancamentosCaixa " +
                     "OUTPUT INSERTED.Id " +
                     "(CaixaId, TipoLancamentoId, Valor, Historico) VALUES " +
                     "(@CaixaId, @TipoLancamentoId, @Valor, @Historico)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@CaixaId", lancamento.CaixaId);
                        cmd.Parameters.AddWithValue("@TipoLancamentoId", lancamento.TipoLancamentoId);
                        cmd.Parameters.AddWithValue("@Valor", lancamento.Valor);
                        cmd.Parameters.AddWithValue("@Historico", lancamento.Historico);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o Lançamento do Caixa.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                lancamentoModel = GetById(idReturned);
            }
            return lancamentoModel;
        }

        public void Edit(ILancamentoCaixaModel lancamento)
        {
            _query = "UPDATE LancamentosCaixa SET TipoLancamentoId = @TipoLancamentoId, " +
                "DataLancamento = @DataLancamento, Valor = @Valor, Historico = @Historico, Estornado = @Estornado " +
                "WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", lancamento.Id);
                        cmd.Parameters.AddWithValue("@TipoLancamentoId", lancamento.TipoLancamentoId);
                        cmd.Parameters.AddWithValue("@DataLancamento", lancamento.DataLancamento);
                        cmd.Parameters.AddWithValue("@Valor", lancamento.Valor);
                        cmd.Parameters.AddWithValue("@Historico", lancamento.Historico);
                        cmd.Parameters.AddWithValue("@Estornado", lancamento.Estornado);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar o Lançamento do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ILancamentoCaixaModel> GetAll()
        {
            lancamentoListModel = new List<ILancamentoCaixaModel>();
            _query = "SELECT * FROM LancamentosCaixa";
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
                                lancamentoModel = new LancamentoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    CaixaId = int.Parse(reader["CaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Estornado = bool.Parse(reader["Estornado"].ToString())
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recupera a lista de Lançamentos do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public IEnumerable<ILancamentoCaixaModel> GetAllByCaixaId(int caixaId)
        {
            lancamentoListModel = new List<ILancamentoCaixaModel>();
            _query = "SELECT * FROM LancamentosCaixa WHERE CaixaId = @CaixaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@CaixaId", caixaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    CaixaId = int.Parse(reader["CaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Estornado = bool.Parse(reader["Estornado"].ToString())
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recupera a lista de Lançamentos do Caixa pelo Id do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public ILancamentoCaixaModel GetById(int lancamentoId)
        {
            _query = "SELECT * FROM LancamentosCaixa WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", lancamentoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    CaixaId = int.Parse(reader["CaixaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Estornado = bool.Parse(reader["Estornado"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recupera o Lançamentos do Caixa pelo seu Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoModel;
        }
    }
}
