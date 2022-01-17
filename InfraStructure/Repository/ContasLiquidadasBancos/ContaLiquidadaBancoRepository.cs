using CommonComponents;

using DomainLayer.Financeiro.Pagaveis;

using ServicesLayer.ContasLiquidadasBancos;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.ContasLiquidadasBancos
{
    public class ContaLiquidadaBancoRepository : IContasLiquidadasBancosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IContaLiquidadaBancoModel model;
        private readonly List<IContaLiquidadaBancoModel> listModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ContaLiquidadaBancoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IContaLiquidadaBancoModel Add(IContaLiquidadaBancoModel model)
        {
            _query = "INSERT INTO ContasLiquidadasBancos (ContaLiquidadaId, LancamentoContaBancariaId) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@ContaLiquidadaId, @LancamentoContaBancariaId) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ContaLiquidadaId", model.ContaLiquidadaId);
                        cmd.Parameters.AddWithValue("@LancamentoContaBancariaId", model.LancamentoContaBancariaId);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar Referência de Conta Liquidada com Lancamento Bancário.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            this.model = new ContaLiquidadaBancoModel();
            if (idReturned != 0)
            {
                this.model = GetById(idReturned);
            }
            return this.model;

        }

        public void Remove(int id)
        {
            _query = "DELETE FROM ContasLiquidadasBancos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Nâo foi possível remover o registro de referência Conta Liquidada ao Lancamento Bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContaLiquidadaBancoModel> GetAll()
        {
            _query = "SELECT * FROM ContasLiquidadasBancos";
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
                                model = new ContaLiquidadaBancoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoContaBancariaId = int.Parse(reader["LancamentoContaBancariaId"].ToString())
                                };
                                listModel.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de registros de referência Contas Liquidadas/LancamentoBancario.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IContaLiquidadaBancoModel GetById(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasBancos WHERE Id = @Id";
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
                                model = new ContaLiquidadaBancoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoContaBancariaId = int.Parse(reader["LancamentoContaBancariaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuparar a referência cruzada de Contas Liquidadas/LancamentoBancario.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public IContaLiquidadaBancoModel GetByContaLiquidadaId(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasBancos WHERE ContaLiquidadaId = @ContaLiquidadaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContaLiquidadaId", id));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model = new ContaLiquidadaBancoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoContaBancariaId = int.Parse(reader["LancamentoContaBancariaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuparar a referência cruzada de Contas Liquidadas/LancamentoBancario pelo Id da Conta Liquidada", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public IContaLiquidadaBancoModel GetByLancamentoBancarioId(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasBancos WHERE LancamentoContaBancariaId = @LancamentoContaBancariaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@LancamentoContaBancariaId", id));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model = new ContaLiquidadaBancoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoContaBancariaId = int.Parse(reader["LancamentoContaBancariaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuparar a referência cruzada de Contas Liquidadas/LancamentoBancario pelo Id do Lançamento Bancário", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);

                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }
    }
}
