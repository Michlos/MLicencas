using CommonComponents;

using DomainLayer.Financeiro.Bancos.ContaBancaria;

using ServicesLayer.LancamentosContasBancarias;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.LancamentosContasBancarias
{
    public class LancamentoContaBancariaRepository : ILancamentosContasBancariasRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private List<ILancamentoContaBancariaModel> lancamentoListModel;
        private ILancamentoContaBancariaModel lancamentoModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public LancamentoContaBancariaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ILancamentoContaBancariaModel Add(ILancamentoContaBancariaModel lancamento)
        {
            lancamentoModel = new LancamentoContaBancariaModel();
            _query = "INSERT INTO LancamentosContasBancarias " +
                     "OUTPUT INSERTED.Id " +
                     "(ContaId, TipoLancamentoId, Valor, Historico) VALUES " +
                     "(@ContaId, @TipoLancamentoId, @Valor, @Historico) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ContaId", lancamento.ContaId);
                        cmd.Parameters.AddWithValue("@TipoLancamentoId", lancamento.TipoLancamentoId);
                        cmd.Parameters.AddWithValue("@Valor", lancamento.Valor);
                        cmd.Parameters.AddWithValue("@Historico", lancamento.Historico);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar Lançamento Bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
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

        public void Edit(ILancamentoContaBancariaModel lancamento)
        {
            _query = "UPDATE LancamentosContasBancarias SET TipoLancamentoId = @TipoLancamentoId,  " +
                "DataLancamento = @DataLancamento, Valor = @Valor, Historico = @Historico " +
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
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar o Lançamento Bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAll()
        {
            _query = "SELECT * FROM LancamentosContasBancarias";
            lancamentoListModel = new List<ILancamentoContaBancariaModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd  = new SqlCommand(_query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoContaBancariaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaId = int.Parse(reader["ContaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString()
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Lancamentos em Contas Bancárias.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaId(int contaId)
        {
            _query = "SELECT * FROM LancamentosContasBancarias WHERE ContaId = @ContaId";
            lancamentoListModel = new List<ILancamentoContaBancariaModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaId", contaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoContaBancariaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaId = int.Parse(reader["ContaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString()
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Lancamentos em Contas Bancárias da Conta Especificada.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndDatas(int contaId, DateTime dataIni, DateTime dataFim)
        {
            _query = "SELECT * FROM LancamentosContasBancarias WHERE ContaId = @ContaId AND DataLancamento >= @DataIni AND DataLacamento <= @DataFim";
            lancamentoListModel = new List<ILancamentoContaBancariaModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaId", contaId));
                        cmd.Parameters.Add(new SqlParameter("@DataIni", dataIni));
                        cmd.Parameters.Add(new SqlParameter("@DataFim", dataFim)); 

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoContaBancariaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaId = int.Parse(reader["ContaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString()
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Lancamentos da Conta nas Datas especificadas.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public IEnumerable<ILancamentoContaBancariaModel> GetAllByContaIdAndMonth(int contaId, int month)
        {
            _query = "SELECT * FROM LancamentosContasBancarias WHERE ContaId = @ContaId AND MONTH(DataLancamento) = @Month";
            lancamentoListModel = new List<ILancamentoContaBancariaModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaId", contaId));
                        cmd.Parameters.Add(new SqlParameter("@Month", month));


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lancamentoModel = new LancamentoContaBancariaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaId = int.Parse(reader["ContaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString()
                                };
                                lancamentoListModel.Add(lancamentoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Lancamentos da Conta Bancária no mês especificado.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return lancamentoListModel;
        }

        public ILancamentoContaBancariaModel GetById(int lancamentoId)
        {
            _query = "SELECT * FROM LancamentosContasBancarias WHERE Id = @Id";
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
                                lancamentoModel = new LancamentoContaBancariaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaId = int.Parse(reader["ContaId"].ToString()),
                                    TipoLancamentoId = int.Parse(reader["TipoLancamentoId"].ToString()),
                                    DataLancamento = DateTime.Parse(reader["DataLancamento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Lancamento em Conta Bancária pelo ID.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
