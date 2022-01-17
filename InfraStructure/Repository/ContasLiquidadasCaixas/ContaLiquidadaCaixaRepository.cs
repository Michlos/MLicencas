using CommonComponents;

using DomainLayer.Financeiro.Pagaveis;

using ServicesLayer.ContasLiquidadasCaixas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ContasLiquidadasCaixas
{
    public class ContaLiquidadaCaixaRepository : IContasLiquidadasCaixasRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IContaLiquidadaCaixaModel model;
        private readonly List<IContaLiquidadaCaixaModel> listModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();
        public IContaLiquidadaCaixaModel Add(IContaLiquidadaCaixaModel model)
        {
            _query = "INSERT INTO ContasLiquidadasCaixa (ContaLiquidadaId, LancamentoCaixaId) " +
                "OUTPUT INSERTED.Id " +
                "VALUES (@ContaLiquidadaId, @LancamentoCaixaId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ContaLiquidadaId", model.ContaLiquidadaId);
                        cmd.Parameters.AddWithValue("@LancamentoCaixaId", model.LancamentoCaixaId);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar referência cruzada de Conta Liquidada/Lançamento Caixa.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            this.model = new ContaLiquidadaCaixaModel();
            if (idReturned != 0)
            {
                this.model = GetById(idReturned);
            }
            return this.model;

        }

        public IEnumerable<IContaLiquidadaCaixaModel> GetAll()
        {
            _query = "SELECT * FROM ContasLiquidadasCaixas";
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
                                model = new ContaLiquidadaCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString())
                                };
                                listModel.Add(model);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de referências cruzadas de ContasLiquidadas/LancamentosCaixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IContaLiquidadaCaixaModel GetByContaLiquidada(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasCaixas WHERE ContaLiquidadaId = @ContaLiquidadaId";
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
                                model = new ContaLiquidadaCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a referência cruzada de ContasLiquidadas/LancamentosCaixa pelo Id da Conta", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public IContaLiquidadaCaixaModel GetById(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasCaixas WHERE Id = @Id";
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
                                model = new ContaLiquidadaCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a referência cruzada de ContasLiquidadas/LancamentosCaixa pelo Id da Conta", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public IContaLiquidadaCaixaModel GetByLancamentoCaixa(int id)
        {
            _query = "SELECT * FROM ContasLiquidadasCaixas WHERE LancamentoCaixaId = @LancamentoCaixaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@LancamentoCaixaId", id));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                model = new ContaLiquidadaCaixaModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ContaLiquidadaId = int.Parse(reader["ContaLiquidadaId"].ToString()),
                                    LancamentoCaixaId = int.Parse(reader["LancamentoCaixaId"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de referências cruzadas de ContasLiquidadas/LancamentosCaixa pelo Id do Lancamento do Caixa", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return model;
        }

        public void Remove(int id)
        {
            _query = "DELETE FROM ContasLiquidadasCaixas WHERE Id = @Id";
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
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar a referência cruzada.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
