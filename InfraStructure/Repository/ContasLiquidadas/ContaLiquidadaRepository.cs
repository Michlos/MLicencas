using CommonComponents;

using DomainLayer.Financeiro.Pagaveis;

using ServicesLayer.ContasLiquidadas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ContasLiquidadas
{
    public class ContaLiquidadaRepository : IContasLiquidadasRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IContaLiquidadaModel contaModel;
        private readonly List<IContaLiquidadaModel> contaListModel = new List<IContaLiquidadaModel>();
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();
        public IContaLiquidadaModel Add(IContaLiquidadaModel contaModel)
        {
            _query = "INSERT INTO ContasLiquidadas (ContaPagarId, OrigemPagamentoId, DataPagamento, Valor, ValorPago, Historico, Integracao) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@ContaPagarId, @OrigemPagamentoId, @DataPagamento, @Valor, @ValorPago, @Historico, @Integracao) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ContaPagarId", contaModel.ContaPagarId);
                        cmd.Parameters.AddWithValue("@OrigemPagamentoId", contaModel.OrigemPagamentoId);
                        cmd.Parameters.AddWithValue("@DataPagamento", contaModel.DataPagamento);
                        cmd.Parameters.AddWithValue("@Valor", contaModel.Valor);
                        cmd.Parameters.AddWithValue("@ValorPago", contaModel.ValorPago);
                        cmd.Parameters.AddWithValue("@Historico", contaModel.Historico);
                        cmd.Parameters.AddWithValue("@Integracao", contaModel.Integracao);
                        idReturned = (int)cmd.ExecuteScalar();


                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar pagamento de Conta.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            this.contaModel = new ContaLiquidadaModel();
            if (idReturned != 0)
            {
                this.contaModel = GetById(idReturned);
            }
            return this.contaModel;
        }

        public void Estornar(IContaLiquidadaModel contaModel)
        {
            _query = "UPDATE ContasLiquidadas SET Estornado = @Estornaro, ValorPago = @ValorPago WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", contaModel.Id);
                        cmd.Parameters.AddWithValue("@Estornado", contaModel.Estornado);
                        cmd.Parameters.AddWithValue("@ValorPago", contaModel.ValorPago);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível estornar o pagamento registrado.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContaLiquidadaModel> GetAll()
        {
            _query = "SELECT * FROM ContasLiquidadas";
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
                                contaModel = new ContaLiquidadaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaPagarId = int.Parse(reader["ContaPagarId"].ToString()),
                                    OrigemPagamentoId = int.Parse(reader["OrigemPagamentoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataPagamento = DateTime.Parse(reader["DataPagamento"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    ValorPago = double.Parse(reader["ValorPagor"].ToString()),
                                    Estornado = bool.Parse(reader["Estornado"].ToString()),
                                    Integracao = bool.Parse(reader["Integracao"].ToString())
                                };
                                contaListModel.Add(contaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Contas Liquidadas.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaListModel;
        }

        public IEnumerable<IContaLiquidadaModel> GetByContaPagarId(int contaPagarId)
        {
            _query = "SELECT * FROM ContasLiquidadas WHERE ContaPagarId = @ContaPagarId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaPagarId", contaPagarId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contaModel = new ContaLiquidadaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaPagarId = int.Parse(reader["ContaPagarId"].ToString()),
                                    OrigemPagamentoId = int.Parse(reader["OrigemPagamentoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataPagamento = DateTime.Parse(reader["DataPagamento"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    ValorPago = double.Parse(reader["ValorPagor"].ToString()),
                                    Estornado = bool.Parse(reader["Estornado"].ToString()),
                                    Integracao = bool.Parse(reader["Integracao"].ToString())
                                };
                                contaListModel.Add(contaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Contas Liquidadas pelo Id do Contas a Pagar.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaListModel;
        }

        public IContaLiquidadaModel GetById(int contaId)
        {
            _query = "SELECT * FROM ContasLiquidadas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", contaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contaModel = new ContaLiquidadaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaPagarId = int.Parse(reader["ContaPagarId"].ToString()),
                                    OrigemPagamentoId = int.Parse(reader["OrigemPagamentoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataPagamento = DateTime.Parse(reader["DataPagamento"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    ValorPago = double.Parse(reader["ValorPagor"].ToString()),
                                    Estornado = bool.Parse(reader["Estornado"].ToString()),
                                    Integracao = bool.Parse(reader["Integracao"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Conta Liquidada pelo ID.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaModel;
        }

        public void Remove(int contaId)
        {
            _query = "DELETE FROM ContasLiquidadas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("Id", contaId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro de Contas Liquidadas", e.HelpLink, e.ErrorCode, e.StackTrace);
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
