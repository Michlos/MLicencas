using CommonComponents;

using DomainLayer.Clientes.Contatos;

using ServicesLayer.ContatosClientes;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ContatosClientes
{
    public class ContatoClienteRepository : IContatosClientesRepository
    {
        private string _connectionString;
        private string _query;
        private IContatoClienteModel contatoClienteModel;
        private List<IContatoClienteModel> contatoClienteListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ContatoClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IContatoClienteModel Add(IContatoClienteModel contatoClienteModel)
        {
            int idReturned;
            this.contatoClienteModel = new ContatoClienteModel();
            _query = "INSERT INTO ContatosClientes " +
                     "(Contato, Cargo, Email, ClienteId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@Contato, @Cargo, @Email, @ClienteId) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Contato", contatoClienteModel.Contato);
                        cmd.Parameters.AddWithValue("@Cargo", contatoClienteModel.Cargo);
                        cmd.Parameters.AddWithValue("@Email", contatoClienteModel.Email);
                        cmd.Parameters.AddWithValue("@ClienteId", contatoClienteModel.ClienteId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível adicionar novo Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.contatoClienteModel = GetById(idReturned);
            }
            return this.contatoClienteModel;
        }

        public void Delete(int contatoId)
        {
            _query = "DELETE ContatosClientes WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", contatoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível remover o Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IContatoClienteModel contatoModel)
        {
            _query = "UPDATE ContatosClientes SET " +
                     "Contato = @Contato, Cargo = @Cargo, Email = @Email " +
                     "WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", contatoModel.Id);
                        cmd.Parameters.AddWithValue("@Contato", contatoModel.Contato);
                        cmd.Parameters.AddWithValue("@Cargo", contatoModel.Cargo);
                        cmd.Parameters.AddWithValue("@Email", contatoModel.Email);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível alterar dados do Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContatoClienteModel> GetAll()
        {
            this.contatoClienteListModel = new List<IContatoClienteModel>();
            _query = "SELECT * FROM ContatosClientes ";
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
                                this.contatoClienteModel = new ContatoClienteModel();

                                this.contatoClienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.contatoClienteModel.Contato = reader["Contato"].ToString();
                                this.contatoClienteModel.Cargo = reader["Cargo"].ToString();
                                this.contatoClienteModel.Email = reader["Email"].ToString();
                                this.contatoClienteModel.ClienteId = int.Parse(reader["ClienteId"].ToString());

                                this.contatoClienteListModel.Add(this.contatoClienteModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível recuperar a lista de Contatos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoClienteListModel;
        }

        public IEnumerable<IContatoClienteModel> GetAllByClienteId(int clienteId)
        {
            this.contatoClienteListModel = new List<IContatoClienteModel>();
            _query = "SELECT * FROM ContatosClientes WHERE ClienteId = @ClienteId ";
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
                                this.contatoClienteModel = new ContatoClienteModel();

                                this.contatoClienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.contatoClienteModel.Contato = reader["Contato"].ToString();
                                this.contatoClienteModel.Cargo = reader["Cargo"].ToString();
                                this.contatoClienteModel.Email = reader["Email"].ToString();
                                this.contatoClienteModel.ClienteId = int.Parse(reader["ClienteId"].ToString());

                                this.contatoClienteListModel.Add(this.contatoClienteModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível recuperar a lista de Contatos do Cliente", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoClienteListModel;
        }

        public IContatoClienteModel GetById(int contatoId)
        {
            this.contatoClienteModel = new ContatoClienteModel();
            _query = "SELECT * FROM ContatosClientes WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", contatoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.contatoClienteModel.Id = int.Parse(reader["Id"].ToString());
                                this.contatoClienteModel.Contato = reader["Contato"].ToString();
                                this.contatoClienteModel.Cargo = reader["Cargo"].ToString();
                                this.contatoClienteModel.Email = reader["Email"].ToString();
                                this.contatoClienteModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível recuperar o Contato por Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoClienteModel;
        }
    }
}
