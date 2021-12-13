using CommonComponents;

using DomainLayer.Fabrica;

using ServicesLayer.EnderecosFabricaServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.EnderecosFabrica
{
    public class EnderecoFabricaRepository : IEnderecosFabricaRepository
    {
        private string _connectionString;
        private string _query;
        private IEnderecoFabricaModel enderecoModel;
        private List<IEnderecoFabricaModel> enderecoListModel;
        DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public EnderecoFabricaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnderecoFabricaModel Add(IEnderecoFabricaModel endereco)
        {
            this.enderecoModel = new EnderecoFabricaModel();
            int idReturned;
            _query = "INSERT INTO EnderecosFabrica " +
                     "(Logradouro, Complemento, Numero, Cep, UfId, CidadeId, BairroId, TipoEnderecoId, FabricaId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@Logradouro, @Complemento, @Numero, @Cep, @UfId, @CidadeId, @BairroId, @TipoEnderecoId, @FabricaId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                        cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
                        cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
                        cmd.Parameters.AddWithValue("@Cep", endereco.Cep);
                        cmd.Parameters.AddWithValue("@UfId", endereco.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", endereco.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", endereco.BairroId);
                        cmd.Parameters.AddWithValue("@TipoEnderecoId", endereco.TipoEnderecoId);
                        cmd.Parameters.AddWithValue("@FabricaId", endereco.FabricaId);

                        idReturned = (int)cmd.ExecuteScalar();
                        this.enderecoModel = GetById(idReturned);
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível adicionar Endereço", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.enderecoModel;
        }

        public void Delete(int enderecoId)
        {
            _query = "DELETE FROM EnderecosFabrica WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", enderecoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o Endereço selecionado", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IEnderecoFabricaModel endereco)
        {
            _query = "UPDATE EnderecosFabrica SET " +
                     "Logradouro = @Logradouro, Complemento = @Complemento, Numero = @Numero, Cep = @Cep, UfId = @UfId, CidadeId = @CidadeId, BairroId = @BairroId, TipoEnderecoId = @TipoEnderecoId " +
                     "WHERE Id = @Id ";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", endereco.Id);
                        cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                        cmd.Parameters.AddWithValue("@Complemento", endereco.Complemento);
                        cmd.Parameters.AddWithValue("@Numero", endereco.Numero);
                        cmd.Parameters.AddWithValue("@Cep", endereco.Cep);
                        cmd.Parameters.AddWithValue("@UfId", endereco.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", endereco.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", endereco.BairroId);
                        cmd.Parameters.AddWithValue("@TipoEnderecoId", endereco.TipoEnderecoId);
                        cmd.Parameters.AddWithValue("@FabricaId", endereco.FabricaId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível Alterar o Endereço", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IEnderecoFabricaModel> GetAll()
        {
            this.enderecoListModel = new List<IEnderecoFabricaModel>();
            _query = "SELECT * FROM EnderecosFabrica";
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
                                this.enderecoModel = new EnderecoFabricaModel();

                                this.enderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.enderecoModel.Logradouro = reader["Logradouro"].ToString();
                                this.enderecoModel.Complemento = reader["Complemento"].ToString();
                                this.enderecoModel.Numero = reader["Numero"].ToString();
                                this.enderecoModel.Cep = reader["Cep"].ToString();
                                this.enderecoModel.UfId = int.Parse(reader["UfId"].ToString());
                                this.enderecoModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                this.enderecoModel.BairroId = int.Parse(reader["BairroId"].ToString());
                                this.enderecoModel.TipoEnderecoId = int.Parse(reader["TipoEnderecoId"].ToString());
                                this.enderecoModel.FabricaId = int.Parse(reader["FabricaId"].ToString());

                                this.enderecoListModel.Add(this.enderecoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Endereços", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.enderecoListModel;
        }

        public IEnderecoFabricaModel GetById(int enderecoId)
        {
            this.enderecoModel = new EnderecoFabricaModel();
            _query = "SELECT * FROM EnderecosFabrica WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", enderecoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.enderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.enderecoModel.Logradouro = reader["Logradouro"].ToString();
                                this.enderecoModel.Complemento = reader["Complemento"].ToString();
                                this.enderecoModel.Numero = reader["Numero"].ToString();
                                this.enderecoModel.Cep = reader["Cep"].ToString();
                                this.enderecoModel.UfId = int.Parse(reader["UfId"].ToString());
                                this.enderecoModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                this.enderecoModel.BairroId = int.Parse(reader["BairroId"].ToString());
                                this.enderecoModel.TipoEnderecoId = int.Parse(reader["TipoEnderecoId"].ToString());
                                this.enderecoModel.FabricaId = int.Parse(reader["FabricaId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Endereços", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.enderecoModel;
        }
    }
}
