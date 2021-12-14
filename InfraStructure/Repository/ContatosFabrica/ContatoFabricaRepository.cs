using CommonComponents;

using DomainLayer.Fabrica;

using ServicesLayer.ContatosFabricaServices;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.ContatosFabrica
{
    public class ContatoFabricaRepository : IContatosFabricaRepository
    {
        private string _connectionString;
        private string _query;
        private IContatoFabricaModel contatoFabricaModel;
        private List<IContatoFabricaModel> contatoFabricaListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ContatoFabricaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IContatoFabricaModel Add(IContatoFabricaModel contatoFabrica)
        {
            this.contatoFabricaModel = new ContatoFabricaModel();
            int idReturned;
            _query = "INSERT INTO ContatosFabrica " +
                     "(Nome, Cargo, Email, FabricaId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES " +
                     "(@Nome, @Cargo, @Email, @FabricaId) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", contatoFabrica.Nome);
                        cmd.Parameters.AddWithValue("@Cargo", contatoFabrica.Cargo);
                        cmd.Parameters.AddWithValue("@Email", contatoFabrica.Email);
                        cmd.Parameters.AddWithValue("@FabricaId", contatoFabrica.FabricaId);

                        idReturned = (int)cmd.ExecuteScalar();
                        try
                        {
                            if (idReturned != 0)
                            {
                                this.contatoFabricaModel = GetById(idReturned);
                            }
                        }
                        catch (SqlException sqe)
                        {

                            throw new Exception($"Contato adicionar mas não poder ser recuperado do banco. \nErrorMessage:{sqe.Message}", sqe.InnerException);
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar novo Contato.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoFabricaModel;
        }

        public void Delete(int contatoId)
        {
            _query = "DELETE FROM ContatosFabrica WHERE Id = @Id";
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
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover o contato do sistema.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IContatoFabricaModel contatoFabrica)
        {
            _query = "UPDATE ContatosFabrica SET Nome = @Nome, Cargo = @Cargo, Email = @Email WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", contatoFabrica.Id);
                        cmd.Parameters.AddWithValue("@Nome", contatoFabrica.Nome);
                        cmd.Parameters.AddWithValue("@Cargo", contatoFabrica.Cargo);
                        cmd.Parameters.AddWithValue("@Email", contatoFabrica.Email);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar dados do Contato", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContatoFabricaModel> GetAll()
        {
            this.contatoFabricaListModel = new List<IContatoFabricaModel>();
            _query = "SELECT * FROM ContatosFabrica";
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
                                this.contatoFabricaModel = new ContatoFabricaModel();

                                this.contatoFabricaModel.Id = int.Parse(reader["Id"].ToString());
                                this.contatoFabricaModel.Nome = reader["Nome"].ToString();
                                this.contatoFabricaModel.Cargo = reader["Cargo"].ToString();
                                this.contatoFabricaModel.Email = reader["Email"].ToString();
                                this.contatoFabricaModel.FabricaId = int.Parse(reader["FabricaId"].ToString());

                                this.contatoFabricaListModel.Add(this.contatoFabricaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Lista de Contatos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoFabricaListModel;
        }

        public IContatoFabricaModel GetById(int contatoId)
        {
            this.contatoFabricaModel = new ContatoFabricaModel();
            _query = "SELECT * FROM ContatosFabrica WHERE Id = @Id";
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

                                this.contatoFabricaModel.Id = int.Parse(reader["Id"].ToString());
                                this.contatoFabricaModel.Nome = reader["Nome"].ToString();
                                this.contatoFabricaModel.Cargo = reader["Cargo"].ToString();
                                this.contatoFabricaModel.Email = reader["Email"].ToString();
                                this.contatoFabricaModel.FabricaId = int.Parse(reader["FabricaId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Lista de Contatos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.contatoFabricaModel;
        }
    }
}
