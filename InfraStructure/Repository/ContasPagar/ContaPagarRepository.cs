using CommonComponents;

using DomainLayer.Financeiro.Pagaveis;

using ServicesLayer.ContasPagar;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ContasPagar
{
    public class ContaPagarRepository : IContasPagarRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IContaPagarModel contaModel;
        private readonly List<IContaPagarModel> contaListModel = new List<IContaPagarModel>();
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ContaPagarRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IContaPagarModel Add(IContaPagarModel contaPagarModel)
        {
            _query = "INSERT INTO ContasPagar (DataVencimento, Valor, Historico " + (contaPagarModel.CodigoBarrasDigitavel != 0 ? ", CodigoBarrasDigitavel) " : ") ") +
                     "OUTPUT INSERTED.Id " +
                     "VALUES (@DataVencimento, @Valor, @Historico " + (contaPagarModel.CodigoBarrasDigitavel != 0 ? ", @CodigoBarrasDigitavel) " : ") ");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@DataVencimento", contaPagarModel.DataVencimento);
                        cmd.Parameters.AddWithValue("@Valor", contaPagarModel.Valor);
                        cmd.Parameters.AddWithValue("@Historico", contaPagarModel.Historico);
                        if (contaPagarModel.CodigoBarrasDigitavel != 0)
                            cmd.Parameters.AddWithValue("@CodigoBarrasDigitavel", contaPagarModel.CodigoBarrasDigitavel);

                        idReturned = (int)cmd.ExecuteScalar(); 
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar registro de Contas a Pagar.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            contaModel = new ContaPagarModel();
            if (idReturned != 0)
            {
                contaModel = GetById(idReturned);
            }
            return contaModel;
        }

        public void Edit(IContaPagarModel contaPagarModel)
        {
            _query = "UPDATE ContasPagar SET DataVencimento = @DataVencimento, Valor = @Valor, Historico = @Historico, Liquidado = @Liquidado " + (contaPagarModel.CodigoBarrasDigitavel != 0 ? ", CodigoBarrasDigitavel = @CodigoBarrasDigitavel " : "") +
                     " WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", contaPagarModel.Id);
                        cmd.Parameters.AddWithValue("@DataVencimento", contaPagarModel.DataVencimento);
                        cmd.Parameters.AddWithValue("@Valor", contaPagarModel.Valor);
                        cmd.Parameters.AddWithValue("@Historico", contaPagarModel.Historico);
                        cmd.Parameters.AddWithValue("@Liquidado", contaPagarModel.Liquidado);
                        if(contaPagarModel.CodigoBarrasDigitavel != 0)
                            cmd.Parameters.AddWithValue("@CodigoBarrasDigitavel", contaPagarModel.CodigoBarrasDigitavel);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualuzar registro de Contas a Pagar", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContaPagarModel> GetAll()
        {
            _query = "SELECT * FROM ContasPagar";
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
                                contaModel = new ContaPagarModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    CodigoBarrasDigitavel = string.IsNullOrEmpty(reader["CodigoBarrasDigitavel"].ToString()) ? 0 :  Int64.Parse(reader["CodigoBarrasDigitavel"].ToString()),
                                    Liquidado = bool.Parse(reader["Liquidado"].ToString())
                                };
                                contaListModel.Add(contaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carregar a lista de Contas a Pagar.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaListModel;
        }

        public IContaPagarModel GetById(int contaId)
        {
            _query = "SELECT * FROM ContasPagar WHERE Id = @Id";
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
                                contaModel = new ContaPagarModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString()),
                                    Historico = reader["Historico"].ToString(),
                                    CodigoBarrasDigitavel = string.IsNullOrEmpty(reader["CodigoBarrasDigitavel"].ToString()) ? 0 : Int64.Parse(reader["CodigoBarrasDigitavel"].ToString()),
                                    Liquidado = bool.Parse(reader["Liquidado"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível carregar a lista de Contas a Pagar.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
            _query = "DELETE FROM ContasPagar WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", contaId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro de Contas a Pagar", e.HelpLink, e.ErrorCode, e.StackTrace);
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
