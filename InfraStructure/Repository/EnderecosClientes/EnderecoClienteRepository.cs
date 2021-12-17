using CommonComponents;

using DomainLayer.Clientes.Enderecos;

using ServicesLayer.EnderecosClientes;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.EnderecosClientes
{
    public class EnderecoClienteRepository : IEnderecosClientesRepository
    {
        private string _connectionString;
        private string _query;
        private IEnderecoClienteModel enderecoModel;
        private List<IEnderecoClienteModel> enderecoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();


        public EnderecoClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnderecoClienteModel Add(IEnderecoClienteModel enderecoModel)
        {
            int idReturned;
            this.enderecoModel = new EnderecoClienteModel();
            _query = "INSERT INTO EnderecosClientes " +
                     "(Logradouro, Complemento, Numero, Cep, UfId, CidadeId, BairroId, TipoEnderecoId, ClienteId, Responsavel) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@Logradouro, @Complemento, @Numero, @Cep, @UfId, @CidadeId, @BairroId, @TipoEnderecoId, @ClienteId, @Responsavel) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Logradouro", enderecoModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Complemento", enderecoModel.Complemento);
                        cmd.Parameters.AddWithValue("@Numero", enderecoModel.Numero);
                        cmd.Parameters.AddWithValue("@Cep", enderecoModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", enderecoModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", enderecoModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", enderecoModel.BairroId);
                        cmd.Parameters.AddWithValue("@TipoEnderecoId", enderecoModel.TipoEnderecoId);
                        cmd.Parameters.AddWithValue("@ClienteId", enderecoModel.ClienteId);
                        cmd.Parameters.AddWithValue("@Responsavel", enderecoModel.Responsavel);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar novo Endereço ao Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.enderecoModel = GetById(idReturned);
            }
            return this.enderecoModel;
        }


        public void Delete(int enderecoId)
        {
            _query = "DELETE EnderecosClientes WHERE Id = @Id";
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
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover o Endereço do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IEnderecoClienteModel enderecoModel)
        {
            _query = "UPDATE EnderecosClientes SET " +
                     "Logradouro = @Logradouro, Complemento = @Complemento, Numero = @Numero, Cep = @Cep, UfId = @UfId, CidadeId = @CidadeId, BairroId = @BairroId, TipoEnderecoId = @TipoEnderecoId, Responsavel = @Responsavel " +
                     "WHERE Id = @Id ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", enderecoModel.Id);
                        cmd.Parameters.AddWithValue("@Logradouro", enderecoModel.Logradouro);
                        cmd.Parameters.AddWithValue("@Complemento", enderecoModel.Complemento);
                        cmd.Parameters.AddWithValue("@Numero", enderecoModel.Numero);
                        cmd.Parameters.AddWithValue("@Cep", enderecoModel.Cep);
                        cmd.Parameters.AddWithValue("@UfId", enderecoModel.UfId);
                        cmd.Parameters.AddWithValue("@CidadeId", enderecoModel.CidadeId);
                        cmd.Parameters.AddWithValue("@BairroId", enderecoModel.BairroId);
                        cmd.Parameters.AddWithValue("@TipoEnderecoId", enderecoModel.TipoEnderecoId);
                        cmd.Parameters.AddWithValue("@Responsavel", enderecoModel.Responsavel);


                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar os dados do Endereço do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IEnderecoClienteModel> GetAll()
        {
            this.enderecoListModel = new List<IEnderecoClienteModel>();
            _query = "SELECT * FROM EnderecosClientes";

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
                                this.enderecoModel = new EnderecoClienteModel();

                                this.enderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.enderecoModel.Logradouro = reader["Logradouro"].ToString();
                                this.enderecoModel.Complemento = reader["Complemento"].ToString();
                                this.enderecoModel.Numero = reader["Numero"].ToString();
                                this.enderecoModel.Cep = reader["Cep"].ToString();
                                this.enderecoModel.UfId = int.Parse(reader["UfId"].ToString());
                                this.enderecoModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                this.enderecoModel.BairroId = int.Parse(reader["BairroId"].ToString());
                                this.enderecoModel.TipoEnderecoId = int.Parse(reader["TipoEnderecoId"].ToString());
                                this.enderecoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.enderecoModel.Responsavel = bool.Parse(reader["Responsavel"].ToString());

                                this.enderecoListModel.Add(this.enderecoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Enderecos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.enderecoListModel;
        }

        public IEnumerable<IEnderecoClienteModel> GetAllByClienteId(int clienteId)
        {
            this.enderecoListModel = new List<IEnderecoClienteModel>();
            _query = "SELECT * FROM EnderecosClientes WHERE ClienteId = @ClienteId";

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
                                this.enderecoModel = new EnderecoClienteModel();

                                this.enderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.enderecoModel.Logradouro = reader["Logradouro"].ToString();
                                this.enderecoModel.Complemento = reader["Complemento"].ToString();
                                this.enderecoModel.Numero = reader["Numero"].ToString();
                                this.enderecoModel.Cep = reader["Cep"].ToString();
                                this.enderecoModel.UfId = int.Parse(reader["UfId"].ToString());
                                this.enderecoModel.CidadeId = int.Parse(reader["CidadeId"].ToString());
                                this.enderecoModel.BairroId = int.Parse(reader["BairroId"].ToString());
                                this.enderecoModel.TipoEnderecoId = int.Parse(reader["TipoEnderecoId"].ToString());
                                this.enderecoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.enderecoModel.Responsavel = bool.Parse(reader["Responsavel"].ToString());

                                this.enderecoListModel.Add(this.enderecoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Enderecos do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.enderecoListModel;
        }

        public IEnderecoClienteModel GetById(int enderecoId)
        {
            this.enderecoModel = new EnderecoClienteModel();
            _query = "SELECT * FROM EnderecosClientes WHERE Id = @Id";

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
                                this.enderecoModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.enderecoModel.Responsavel = bool.Parse(reader["Responsavel"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Enderecos do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
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
