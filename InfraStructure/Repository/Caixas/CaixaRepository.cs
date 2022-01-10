using CommonComponents;

using DomainLayer.Financeiro.Caixa;

using ServicesLayer.Caixa;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.Caixas
{
    public class CaixaRepository : ICaixaRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private ICaixaModel caixaModel;
        private List<ICaixaModel> caixaListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public CaixaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICaixaModel Add(ICaixaModel caixa)
        {
            _query = "INSERT INTO Caixa (SaldoAnterior, SaldoFinal)  " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@SaldoAnterior, @SaldoFinal)";
            caixaModel = new CaixaModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@SaldoAnterior", caixa.SaldoAnterior);
                        cmd.Parameters.AddWithValue("@SaldoFinal", caixa.SaldoFinal);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possívle adicionar novo Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                caixaModel = GetById(idReturned);
            }
            return caixaModel;
        }


        public IEnumerable<ICaixaModel> GetAll()
        {
            _query = "SELECT * FROM Caixa";
            caixaListModel = new List<ICaixaModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? datafechamento;    
                                if (string.IsNullOrEmpty(reader["DataFechamento"].ToString()))
                                    datafechamento = null;
                                else
                                    datafechamento = DateTime.Parse(reader["DataFechamento"].ToString());

                                caixaModel = new CaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    DataAbertura = DateTime.Parse(reader["DataAbertura"].ToString()),
                                    DataFechamento = datafechamento,
                                    SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString()),
                                    SaldoFinal = double.Parse(reader["SaldoFinal"].ToString())
                                };
                                caixaListModel.Add(caixaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Caixas", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return caixaListModel;
        }

        public ICaixaModel GetByDataAbertura(DateTime dataAbertura)
        {
            _query = "SELECT * FROM Caixa WHERE DataAbertura = @DataAbertura";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@DataAbertura", dataAbertura));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? datafechamento;
                                if (string.IsNullOrEmpty(reader["DataFechamento"].ToString()))
                                    datafechamento = null;
                                else
                                    datafechamento = DateTime.Parse(reader["DataFechamento"].ToString());

                                caixaModel = new CaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    DataAbertura = DateTime.Parse(reader["DataAbertura"].ToString()),
                                    DataFechamento = datafechamento,
                                    SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString()),
                                    SaldoFinal = double.Parse(reader["SaldoFinal"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Caixa pela Data de Abertura stipulada.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return caixaModel;
        }

        public ICaixaModel GetById(int caixaId)
        {
            _query = "SELECT * FROM Caixa WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("Id", caixaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime? datafechamento;
                                if (string.IsNullOrEmpty(reader["DataFechamento"].ToString()))
                                    datafechamento = null;
                                else
                                    datafechamento = DateTime.Parse(reader["DataFechamento"].ToString());

                                caixaModel = new CaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    DataAbertura = DateTime.Parse(reader["DataAbertura"].ToString()),
                                    DataFechamento = datafechamento,
                                    SaldoAnterior = double.Parse(reader["SaldoAnterior"].ToString()),
                                    SaldoFinal = double.Parse(reader["SaldoFinal"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar as informações do Caixa pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return caixaModel;
        }

        public ICaixaModel UpdateSaldo(double saldoFinal, int caixaId)
        {
            caixaModel = new CaixaModel();
            _query = "UPDATE Caixa SET SaldoFinal = @SaldoFinal OUTPUT INSERTED.Id WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", caixaId));
                        cmd.Parameters.Add(new SqlParameter("@SaldoFinal", saldoFinal));
                        idReturned = (int)cmd.ExecuteScalar();
                        
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar o saldo do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                caixaModel = GetById(idReturned);
            }
            return caixaModel;
        }

        public ICaixaModel CloseCaixa(DateTime dataFechamento, int caixaId)
        {
            _query = "UPDATE Caixa SET DataFechamento = @DataFechamento OUTPUT INSERTED.Id WHERE Id = @Id";
            caixaModel = new CaixaModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", caixaId));
                        cmd.Parameters.Add(new SqlParameter("@DataFechamento", dataFechamento));
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível fechar o Caixa.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                caixaModel = GetById(idReturned);
            }
            return caixaModel;
        }
    }
}
