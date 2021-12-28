using CommonComponents;

using DomainLayer.Clientes.Contratos;

using ServicesLayer.Contratos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Contratos
{
    public class ContratoRepository : IContratosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private IContratoModel contratoModel;
        private readonly List<IContratoModel> contratoListModel = new List<IContratoModel>();
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();


        public ContratoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IContratoModel Add(IContratoModel contrato)
        {
            int idReturned;
            this.contratoModel = new ContratoModel();
            _query = "INSERT INTO Contratos " +
                     "(Nome, Termo, DataRegistro, DataVencimento, Valor, Parcelas, ValorParcela, Prorrogacoes, ClienteId, SoftwareId, SituacaoId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES" +
                     "(@Nome, @Termo, @DataRegistro, @DataVencimento, @Valor, @Parcelas, @ValorParcela, @Prorrogacoes, @ClienteId, @SoftwareId, @SituacaoId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Nome", contrato.Nome);
                        cmd.Parameters.AddWithValue("@Termo", contrato.Termo);
                        cmd.Parameters.AddWithValue("@DataRegistro", contrato.DataRegistro);
                        cmd.Parameters.AddWithValue("@DataVencimento", contrato.DataVencimento);
                        cmd.Parameters.AddWithValue("@Valor", contrato.Valor);
                        cmd.Parameters.AddWithValue("@Parcelas", contrato.Parcelas);
                        cmd.Parameters.AddWithValue("@ValorParcela", contrato.ValorParcela);
                        cmd.Parameters.AddWithValue("@Prorrogacoes", contrato.Prorrogacoes);
                        cmd.Parameters.AddWithValue("@ClienteId", contrato.ClienteId);
                        cmd.Parameters.AddWithValue("@SoftwareId", contrato.SoftwareId);
                        cmd.Parameters.AddWithValue("@SituacaoId", contrato.SituacaoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar um novo Contrato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.contratoModel = GetById(idReturned);
            }
            return this.contratoModel;
        }

        public void AlteraSituacao(int situacaoId, int contratoId)
        {
            _query = "UPDATE Contratos SET SituacaoId = @SituacaoId WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@SituacaoId", situacaoId));
                        cmd.Parameters.Add(new SqlParameter("@Id", contratoId));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar a Situação do Contrato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IContratoModel contrato)
        {
            _query = "UPDATE Contratos SET Nome = @Nome, Termo = @Termo, DataVencimento = @DataVencimento, SoftwareId = @SoftwareId, SituacaoId = @SituacaoId, Valor = @Valor, Parcelas = @Parcelas, ValorParcela = @ValorParcela " +
                     "WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", contrato.Id);
                        cmd.Parameters.AddWithValue("@Nome", contrato.Nome);
                        cmd.Parameters.AddWithValue("@Termo", contrato.Termo);
                        cmd.Parameters.AddWithValue("@DataRegistro", contrato.DataRegistro);
                        cmd.Parameters.AddWithValue("@DataVencimento", contrato.DataVencimento);
                        cmd.Parameters.AddWithValue("@Valor", contrato.Valor);
                        cmd.Parameters.AddWithValue("@Parcelas", contrato.Parcelas);
                        cmd.Parameters.AddWithValue("@ValorParcela", contrato.ValorParcela);
                        cmd.Parameters.AddWithValue("@Prorrogacoes", contrato.Prorrogacoes);
                        cmd.Parameters.AddWithValue("@SoftwareId", contrato.SoftwareId);
                        cmd.Parameters.AddWithValue("@SituacaoId", contrato.SituacaoId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar os dados do Contrato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContratoModel> GetAll()
        {
            this.contratoListModel.Clear();
            _query = "SELECT * FROM Contratos";
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
                                contratoModel = new ContratoModel();

                                contratoModel.Id = int.Parse(reader["Id"].ToString());
                                contratoModel.Nome = reader["Nome"].ToString();
                                contratoModel.Termo = reader["Termo"].ToString();
                                contratoModel.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                contratoModel.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                contratoModel.Valor = double.Parse(reader["Valor"].ToString());
                                contratoModel.Parcelas = int.Parse(reader["Parcelas"].ToString());
                                contratoModel.ValorParcela = double.Parse(reader["ValorParcela"].ToString());
                                contratoModel.Prorrogacoes = int.Parse(reader["Prorrogacoes"].ToString());
                                contratoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                contratoModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                contratoModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                                contratoListModel.Add(contratoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Contratos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contratoListModel;
        }

        public IEnumerable<IContratoModel> GetAllByClienteId(int clienteId)
        {
            this.contratoListModel.Clear();
            _query = "SELECT * FROM Contratos WHERE ClienteId = @ClienteId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ClienteId", clienteId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contratoModel = new ContratoModel();

                                contratoModel.Id = int.Parse(reader["Id"].ToString());
                                contratoModel.Nome = reader["Nome"].ToString();
                                contratoModel.Termo = reader["Termo"].ToString();
                                contratoModel.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                contratoModel.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                contratoModel.Valor = double.Parse(reader["Valor"].ToString());
                                contratoModel.Parcelas = int.Parse(reader["Parcelas"].ToString());
                                contratoModel.ValorParcela = double.Parse(reader["ValorParcela"].ToString());
                                contratoModel.Prorrogacoes = int.Parse(reader["Prorrogacoes"].ToString());
                                contratoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                contratoModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                contratoModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                                contratoListModel.Add(contratoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Contratos do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contratoListModel;
        }

        public IEnumerable<IContratoModel> GetAllBySoftwareId(int softwareId)
        {
            this.contratoListModel.Clear();
            _query = "SELECT * FROM Contratos WHERE SoftwareId = @SoftwareId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@SoftwareId", softwareId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contratoModel = new ContratoModel();

                                contratoModel.Id = int.Parse(reader["Id"].ToString());
                                contratoModel.Nome = reader["Nome"].ToString();
                                contratoModel.Termo = reader["Termo"].ToString();
                                contratoModel.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                contratoModel.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                contratoModel.Valor = double.Parse(reader["Valor"].ToString());
                                contratoModel.Parcelas = int.Parse(reader["Parcelas"].ToString());
                                contratoModel.ValorParcela = double.Parse(reader["ValorParcela"].ToString());
                                contratoModel.Prorrogacoes = int.Parse(reader["Prorrogacoes"].ToString());
                                contratoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                contratoModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                contratoModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                                contratoListModel.Add(contratoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Contratos por Software", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contratoListModel;
        }

        public IContratoModel GetById(int contratoId)
        {
            this.contratoModel = new ContratoModel();
            _query = "SELECT * FROM Contratos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", contratoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                contratoModel.Id = int.Parse(reader["Id"].ToString());
                                contratoModel.Nome = reader["Nome"].ToString();
                                contratoModel.Termo = reader["Termo"].ToString();
                                contratoModel.DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString());
                                contratoModel.DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString());
                                contratoModel.Valor = double.Parse(reader["Valor"].ToString());
                                contratoModel.Parcelas = int.Parse(reader["Parcelas"].ToString());
                                contratoModel.ValorParcela = double.Parse(reader["ValorParcela"].ToString());
                                contratoModel.Prorrogacoes = int.Parse(reader["Prorrogacoes"].ToString());
                                contratoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                contratoModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                contratoModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Contrato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contratoModel;
        }

        public IContratoModel Prorroga(IContratoModel contrato, DateTime dataProrroga)
        {
            this.contratoModel = new ContratoModel();
            _query = "UPDATE Contratos SET Prorrogacoes = @Prorrogacoes, DataVencimento = @DataVencimento WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@Id", contrato.Id));
                        cmd.Parameters.Add(new SqlParameter("@Prorrogacoes", contrato.Prorrogacoes++));
                        cmd.Parameters.Add(new SqlParameter("@DataVencimento", dataProrroga));

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível prorrogar o Contrato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            this.contratoModel = GetById(contrato.Id);
            return this.contratoModel;
        }
    }
}
