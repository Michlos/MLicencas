using CommonComponents;

using DomainLayer.Fabrica;

using ServicesLayer.TelefonesContatosFabricaServices;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InfraStructure.Repository.TelefonesContatosFabrica
{
    public class TelefoneContatoFabricaRepository : ITelefonesContatosFabricaRepository
    {
        private string _connectionString;
        private string _query;
        private ITelefoneContatoFabricaModel telefoneModel;
        private List<ITelefoneContatoFabricaModel> telefoneListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TelefoneContatoFabricaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ITelefoneContatoFabricaModel Add(ITelefoneContatoFabricaModel telefone)
        {
            int idReturned;
            this.telefoneModel = new TelefoneContatoFabricaModel();
            _query = "INSERT INTO TelefonesContatosFabrica " +
                     "(Numero, Operadora, Ramal, TipoTelefoneId, ContatoId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@Numero, @Operadora, @Ramal, @TipoTelefoneId, @ContatoId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
                        cmd.Parameters.AddWithValue("@Operadora", telefone.Operadora);
                        cmd.Parameters.AddWithValue("@Ramal", telefone.Ramal);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefone.TipoTelefoneId);
                        cmd.Parameters.AddWithValue("@ContatoId", telefone.ContatoId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar Telefone de Contato", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.telefoneModel = GetById(idReturned);
            }
            return this.telefoneModel;
        }

        public void Delete(int telefoneId)
        {
            _query = "DELETE FROM TelefonesContatosFabrica WHERE Id = @Id";
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
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover o Telefone de Contato", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(ITelefoneContatoFabricaModel telefone)
        {
            _query = "UPDATE TelefonesContatosFabrica SET " +
                     "Numero = @Numero, Operadora = @Operadora, Ramal = @Ramal, TipoTelefoneId = @TipoTelefoneId " +
                     "WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", telefone.Id);
                        cmd.Parameters.AddWithValue("@Numero", telefone.Numero);
                        cmd.Parameters.AddWithValue("@Operadora", telefone.Operadora);
                        cmd.Parameters.AddWithValue("@Ramal", telefone.Ramal);
                        cmd.Parameters.AddWithValue("@TipoTelefoneId", telefone.TipoTelefoneId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar o Telefone", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public IEnumerable<ITelefoneContatoFabricaModel> GetAll()
        {
            this.telefoneListModel = new List<ITelefoneContatoFabricaModel>();
            _query = "SELECT * FROM TelefonesContatosFabrica";
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
                                this.telefoneModel = new TelefoneContatoFabricaModel();

                                this.telefoneModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneModel.Numero = reader["Numero"].ToString();
                                this.telefoneModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                                this.telefoneListModel.Add(this.telefoneModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Telefones", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneListModel;
        }

        public IEnumerable<ITelefoneContatoFabricaModel> GetAllByContatoId(int contatoId)
        {
            this.telefoneListModel = new List<ITelefoneContatoFabricaModel>();
            _query = "SELECT * FROM TelefonesContatosFabrica WHERE ContatoId = @ContatoId";
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
                                this.telefoneModel = new TelefoneContatoFabricaModel();

                                this.telefoneModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneModel.Numero = reader["Numero"].ToString();
                                this.telefoneModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                                this.telefoneListModel.Add(this.telefoneModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Telefones pelo ContatoId", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneListModel;
        }

        public ITelefoneContatoFabricaModel GetById(int telefoneId)
        {
            this.telefoneModel = new TelefoneContatoFabricaModel();
            _query = "SELECT * FROM TelefonesContatosFabrica WHERE Id = @Id";
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

                                this.telefoneModel.Id = int.Parse(reader["Id"].ToString());
                                this.telefoneModel.Numero = reader["Numero"].ToString();
                                this.telefoneModel.Operadora = reader["Operadora"].ToString();
                                this.telefoneModel.Ramal = reader["Ramal"].ToString();
                                this.telefoneModel.TipoTelefoneId = int.Parse(reader["TipoTelefoneId"].ToString());
                                this.telefoneModel.ContatoId = int.Parse(reader["ContatoId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Telefones pelo ContatoId", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.telefoneModel;
        }
    }
}
