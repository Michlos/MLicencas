using CommonComponents;

using DomainLayer.Clientes;

using ServicesLayer.ClientesServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.Clientes
{
    public class ClienteRepository : IClientesRepository
    {
        private string _connectionString;
        private string _query;
        private IClienteModel clienteModel;
        private List<IClienteModel> clienteListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IClienteModel Add(IClienteModel clienteModel)
        {
            int idReturned;
            this.clienteModel = new ClienteModel();
            _query = "INSERT INTO Clientes " +
                     "(NomeFantasia, RazaoSocial, Cnpj, Ie, Email, WebSite, SituacaoId)" +
                     "OUTPUT INSERTED.Id" +
                     "VALUES" +
                     "(@NomeFantasia, @RazaoSocial, @Cnpj, @Ie, @Email, @WebSite, @SituacaoId) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@NomeFantasia", clienteModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", clienteModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", clienteModel.Cnpj);
                        cmd.Parameters.AddWithValue("@Ie", clienteModel.Ie);
                        cmd.Parameters.AddWithValue("@Email", clienteModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", clienteModel.WebSite);
                        cmd.Parameters.AddWithValue("@SituacaoId", clienteModel.SituacaoId);

                        idReturned = (int)cmd.ExecuteScalar();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.clienteModel = GetById(idReturned);
            }
            return this.clienteModel;
        }

        public void Edid(IClienteModel clienteModel)
        {
            _query = "UPDATE Clientes SET" +
                     "NomeFantasia = @NomeFantasia, RazaoSocial = @RazaoSocial, Cnpj = @Cnpj, Ie = @Ie, Email = @Email, WebSite = @WebSite, SituacaoId = @SituacaoId " +
                     "WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", clienteModel.Id);
                        cmd.Parameters.AddWithValue("@NomeFantasia", clienteModel.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", clienteModel.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", clienteModel.Cnpj);
                        cmd.Parameters.AddWithValue("@Ie", clienteModel.Ie);
                        cmd.Parameters.AddWithValue("@Email", clienteModel.Email);
                        cmd.Parameters.AddWithValue("@WebSite", clienteModel.WebSite);
                        cmd.Parameters.AddWithValue("@SituacaoId", clienteModel.SituacaoId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar dados do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IClienteModel> GetAll()
        {
            this.clienteListModel = new List<IClienteModel>();
            _query = "SELECT * FROM Clientes";

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
                                this.clienteModel = new ClienteModel();
                                this.clienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.clienteModel.NomeFantasia = reader["NomeFantasia"].ToString();
                                this.clienteModel.RazaoSocial = reader["RazaoSocial"].ToString();
                                this.clienteModel.Cnpj = reader["Cnpj"].ToString();
                                this.clienteModel.Ie = reader["Ie"].ToString();
                                this.clienteModel.Email = reader["Email"].ToString();
                                this.clienteModel.WebSite = reader["WebSite"].ToString();
                                this.clienteModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                                this.clienteListModel.Add(this.clienteModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Clientes", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return this.clienteListModel;
        }

        public IEnumerable<IClienteModel> GetAllBySituacaoId(int situacaoId)
        {
            this.clienteListModel = new List<IClienteModel>();
            _query = "SELECT * FROM Clientes WHERE SituacaoId = @SituacaoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {

                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@SituacaoId", situacaoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.clienteModel = new ClienteModel();

                                this.clienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.clienteModel.NomeFantasia = reader["NomeFantasia"].ToString();
                                this.clienteModel.RazaoSocial = reader["RazaoSocial"].ToString();
                                this.clienteModel.Cnpj = reader["Cnpj"].ToString();
                                this.clienteModel.Ie = reader["Ie"].ToString();
                                this.clienteModel.Email = reader["Email"].ToString();
                                this.clienteModel.WebSite = reader["WebSite"].ToString();
                                this.clienteModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());

                                this.clienteListModel.Add(this.clienteModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Clientes por Situação", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return this.clienteListModel;
        }

        public IClienteModel GetById(int clienteId)
        {
            this.clienteModel = new ClienteModel();
            _query = "SELECT * FROM Clientes WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {

                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", clienteId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.clienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.clienteModel.NomeFantasia = reader["NomeFantasia"].ToString();
                                this.clienteModel.RazaoSocial = reader["RazaoSocial"].ToString();
                                this.clienteModel.Cnpj = reader["Cnpj"].ToString();
                                this.clienteModel.Ie = reader["Ie"].ToString();
                                this.clienteModel.Email = reader["Email"].ToString();
                                this.clienteModel.WebSite = reader["WebSite"].ToString();
                                this.clienteModel.SituacaoId = int.Parse(reader["SituacaoId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar dados do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

            return this.clienteModel;
        }
    }
}
