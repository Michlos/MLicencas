using CommonComponents;

using DomainLayer.Financeiro;

using ServicesLayer.ContasBancarias;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.ContaBancaria
{
    public class ContaBancariaRepository : IContasBancariasRepository
    {
        private readonly string _connectonString;
        private string _query;
        private IContaBancariaModel contaModel;
        private List<IContaBancariaModel> contaListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        private int idReturned;

        public ContaBancariaRepository(string connectonString)
        {
            _connectonString = connectonString;
        }

        public IContaBancariaModel Add(IContaBancariaModel contaModel)
        {
            _query = "INSERT INTO ContasBancarias (Agencia, AgenciaDV, Conta, ContaDV, EmiteBoleto, BancoId, TipoContaId) " +
                     " OUTPUT INSERTED.Id " +
                     " VALUES " +
                     " (@Agencia, @AgenciaDV, @Conta, @ContaDV, @EmiteBoleto, @BancoId, @TipoContaId)";
            this.contaModel = new ContaBancariaModel();
            using (SqlConnection connection = new SqlConnection(_connectonString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Agencia", contaModel.Agencia);
                        cmd.Parameters.AddWithValue("@AgenciaDV", contaModel.AgenciaDV);
                        cmd.Parameters.AddWithValue("@Conta", contaModel.Conta);
                        cmd.Parameters.AddWithValue("@ContaDV", contaModel.ContaDV);
                        cmd.Parameters.AddWithValue("@EmiteBoleto", contaModel.EmiteBoleto);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.BancoId);
                        cmd.Parameters.AddWithValue("@TipoContaId", contaModel.TipoContaId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar a conta bancária.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.contaModel = GetById(idReturned);
            }
            return this.contaModel;
        }

        public void Edit(IContaBancariaModel contaModel)
        {
            _query = "UPDATE ContasBancarias SET " +
                " Agencia = @Agencia, AgenciaDV = @AgenciaDV, Conta = @Conta, ContaDV = @ContaDV, EmiteBoleto = @EmiteBoleto " +
                " WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectonString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", contaModel.Id);
                        cmd.Parameters.AddWithValue("@Agencia", contaModel.Agencia);
                        cmd.Parameters.AddWithValue("@AgenciaDV", contaModel.AgenciaDV);
                        cmd.Parameters.AddWithValue("@Conta", contaModel.Conta);
                        cmd.Parameters.AddWithValue("@ContaDV", contaModel.ContaDV);
                        cmd.Parameters.AddWithValue("@EmiteBoleto", contaModel.EmiteBoleto);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.BancoId);
                        cmd.Parameters.AddWithValue("@TipoContaId", contaModel.TipoContaId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar dados da Conta Bancária", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContaBancariaModel> GetAll()
        {
            _query = "SELECT * FROM ContasBancarias";
            contaListModel = new List<IContaBancariaModel>();

            using (SqlConnection connection = new SqlConnection(_connectonString))
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
                                contaModel = new ContaBancariaModel();

                                contaModel.Id = int.Parse(reader["Id"].ToString());
                                contaModel.Agencia = reader["Agencia"].ToString();
                                contaModel.AgenciaDV = reader["AgenciaDV"].ToString();
                                contaModel.Conta = reader["Conta"].ToString();
                                contaModel.ContaDV = reader["ContaDV"].ToString();
                                contaModel.EmiteBoleto = bool.Parse(reader["EmiteBoleto"].ToString());
                                contaModel.BancoId = int.Parse(reader["BancoId"].ToString());
                                contaModel.TipoContaId = int.Parse(reader["TipoContaId"].ToString());

                                contaListModel.Add(contaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Contas Bancárias.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaListModel;

        }

        public IEnumerable<IContaBancariaModel> GetAllByBancoId(int bancoId)
        {
            _query = "SELECT * FROM ContasBancarias WHERE BancoId = @BancoId";
            contaListModel = new List<IContaBancariaModel>();

            using (SqlConnection connection = new SqlConnection(_connectonString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@BancoId", bancoId));
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contaModel = new ContaBancariaModel();

                                contaModel.Id = int.Parse(reader["Id"].ToString());
                                contaModel.Agencia = reader["Agencia"].ToString();
                                contaModel.AgenciaDV = reader["AgenciaDV"].ToString();
                                contaModel.Conta = reader["Conta"].ToString();
                                contaModel.ContaDV = reader["ContaDV"].ToString();
                                contaModel.EmiteBoleto = bool.Parse(reader["EmiteBoleto"].ToString());
                                contaModel.BancoId = int.Parse(reader["BancoId"].ToString());
                                contaModel.TipoContaId = int.Parse(reader["TipoContaId"].ToString());

                                contaListModel.Add(contaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Contas Bancárias do Banco Selecionado", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contaListModel;
        }

        public IContaBancariaModel GetById(int contaId)
        {
            _query = "SELECT * FROM ContasBancarias WHERE Id = @Id";
            contaModel = new ContaBancariaModel();

            using (SqlConnection connection = new SqlConnection(_connectonString))
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
                                contaModel.Id = int.Parse(reader["Id"].ToString());
                                contaModel.Agencia = reader["Agencia"].ToString();
                                contaModel.AgenciaDV = reader["AgenciaDV"].ToString();
                                contaModel.Conta = reader["Conta"].ToString();
                                contaModel.ContaDV = reader["ContaDV"].ToString();
                                contaModel.EmiteBoleto = bool.Parse(reader["EmiteBoleto"].ToString());
                                contaModel.BancoId = int.Parse(reader["BancoId"].ToString());
                                contaModel.TipoContaId = int.Parse(reader["TipoContaId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Conta Bancária pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);
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
            _query = "DELETE ContasBancarias WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectonString))
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
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover a conta bancária do banco de dados.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
