using CommonComponents;

using DomainLayer.Clientes.Telefones;

using ServicesLayer.TelefonesContatosClientes;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TelefonesContatosClientes
{
    public class TelefoneContatoCliente : ITelefonesContatosClientesRepository
    {
        private string _connectionString;
        private string _query;
        private ITelefoneContatoClienteModel telefoneContatoModel;
        private List<ITelefoneContatoClienteModel> telefoneContatoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TelefoneContatoCliente(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ITelefoneContatoClienteModel Add(ITelefoneContatoClienteModel telefoneModel)
        {
            int idReturned;
            this.telefoneContatoModel = new TelefoneContatoClienteModel();
            _query = "INSERT INTO TelefonesContatosClientes " +
                     "(Numero, Operadora, Ramal, TipoTelefoneId, ContatoId)" +
                     "OUTPUT INSERTED.Id" +
                     "VALUES" +
                     "(@Numero, @Operadora, @Ramal, @TipoTelefoneId, @ContatoId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Numero", telefoneModel.Numero);
                        cmd.Parameters.AddWithValue("@Operadora", telefoneModel.Operadora);
                        cmd.Parameters.AddWithValue("@Ramal", telefoneModel.Ramal);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneModel.TipoTelefoneId);
                        cmd.Parameters.AddWithValue("@ContatoId", telefoneModel.ContatoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível adicionar o Telefone", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.telefoneContatoModel = GetById(idReturned);
            }
            return this.telefoneContatoModel;

        }

        public void Delte(int telefoneId)
        {

            _query = "DELETE TelefonesContatosClientes WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", telefoneId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Nâo foi possível remover o Telefone do Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(ITelefoneContatoClienteModel telefoneModel)
        {
            _query = "UPDATE TelefonesContatosClientes SET " +
                     "Numero = @Numero, Operadora = @Operadora, Ramal = @Ramal, TipoTelefoneId = @TipoTelefoneId " +
                     "WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", telefoneModel.Id);
                        cmd.Parameters.AddWithValue("@Numero", telefoneModel.Numero);
                        cmd.Parameters.AddWithValue("@Operadora", telefoneModel.Operadora);
                        cmd.Parameters.AddWithValue("@Ramal", telefoneModel.Ramal);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefoneModel.TipoTelefoneId);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Nâo foi possível alterar o Telefone do Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public IEnumerable<ITelefoneContatoClienteModel> GetAll()
        {
            this.telefoneContatoListModel = new List<ITelefoneContatoClienteModel>();
            _query = "SELECT * FROM TelefonesContatosClientes";

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
                                this.telefoneContatoModel = new TelefoneContatoClienteModel();

                                this.telefoneContatoModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneContatoModel.Numero = reader["Numero"].ToString();
                                this.telefoneContatoModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneContatoModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneContatoModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneContatoModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                                this.telefoneContatoListModel.Add(this.telefoneContatoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Nâo foi possível recuperar a lista de Telefones", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneContatoListModel;
        }

        public IEnumerable<ITelefoneContatoClienteModel> GetAllByContatoId(int contatoId)
        {
            this.telefoneContatoListModel = new List<ITelefoneContatoClienteModel>();
            _query = "SELECT * FROM TelefonesContatosClientes WHERE ContatoId = @ContatoId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContatoId", contatoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.telefoneContatoModel = new TelefoneContatoClienteModel();

                                this.telefoneContatoModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneContatoModel.Numero = reader["Numero"].ToString();
                                this.telefoneContatoModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneContatoModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneContatoModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneContatoModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                                this.telefoneContatoListModel.Add(this.telefoneContatoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Nâo foi possível recuperar a lista de Telefones do Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneContatoListModel;
        }

        public ITelefoneContatoClienteModel GetById(int telefoneId)
        {
            this.telefoneContatoModel = new TelefoneContatoClienteModel();
            _query = "SELECT * FROM TelefonesContatosClientes WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", telefoneId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.telefoneContatoModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneContatoModel.Numero = reader["Numero"].ToString();
                                this.telefoneContatoModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneContatoModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneContatoModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneContatoModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Nâo foi possível recuperar a lista de Telefones por Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneContatoModel;
        }
    }
}
