using CommonComponents;

using DomainLayer.Softwares;

using ServicesLayer.Softwares;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Softwares
{
    public class SoftwareRepository : ISoftwaresRepository
    {
        private string _connectionString, _query;
        private int idReturned;
        private ISoftwareModel softwareModel;
        private List<ISoftwareModel> softwareListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public SoftwareRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISoftwareModel Add(ISoftwareModel software)
        {
            softwareModel = new SoftwareModel();
            _query = "INSERT INTO Softwares (Nome, Descricao, PublicoAlvo, Versao, ClienteServidor, PlataformaId, OsId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES (@Nome, @Descricao, @PublicoAlvo, @Versao, @ClienteServidor, @PlataformaId, @OsId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Nome", software.Nome);
                        cmd.Parameters.AddWithValue("@Descricao", software.Descricao);
                        cmd.Parameters.AddWithValue("@PublicoAlvo", software.PublicoAlvo);
                        cmd.Parameters.AddWithValue("@Versao", software.Versao);
                        cmd.Parameters.AddWithValue("@ClienteServidor", software.ClienteServidor);
                        cmd.Parameters.AddWithValue("@PlataformaId", software.PlataformaId);
                        cmd.Parameters.AddWithValue("@OsId", software.OsId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Adicionar o Software.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            if (idReturned != 0)
            {
                softwareModel = GetById(idReturned);
            }

            return softwareModel;
        }

        public void Edit(ISoftwareModel software)
        {
            softwareModel = new SoftwareModel();
            _query = "UPDATE Softwares SET " +
                     "Nome = @Nome, Descricao = @Descricao, PublicoAlvo = @PublicoAlvo, Versao = @Versao, ClienteServidor = @ClienteServidor, " +
                     "PlataformaId = @PlataformaId, OsId = @OsId " +
                     "WHERE Id = @Id ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", software.Id);
                        cmd.Parameters.AddWithValue("@Nome", software.Nome);
                        cmd.Parameters.AddWithValue("@Descricao", software.Descricao);
                        cmd.Parameters.AddWithValue("@PublicoAlvo", software.PublicoAlvo);
                        cmd.Parameters.AddWithValue("@Versao", software.Versao);
                        cmd.Parameters.AddWithValue("@ClienteServidor", software.ClienteServidor);
                        cmd.Parameters.AddWithValue("@PlataformaId", software.PlataformaId);
                        cmd.Parameters.AddWithValue("@OsId", software.OsId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Editar o Software.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }

        }

        public IEnumerable<ISoftwareModel> GetAll()
        {
            softwareListModel = new List<ISoftwareModel>();
            _query = "SELECT * FROM Softwares";

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
                                softwareModel = new SoftwareModel();

                                softwareModel.Id = int.Parse(reader["Id"].ToString());
                                softwareModel.Nome = reader["Nome"].ToString();
                                softwareModel.Descricao = reader["Descricao"].ToString();
                                softwareModel.PublicoAlvo = reader["PublicoAlvo"].ToString();
                                softwareModel.Versao = reader["Versao"].ToString();
                                softwareModel.ClienteServidor = bool.Parse(reader["ClienteServidor"].ToString());
                                softwareModel.PlataformaId = int.Parse(reader["PlataformaId"].ToString());
                                softwareModel.OsId = int.Parse(reader["OsId"].ToString());

                                softwareListModel.Add(softwareModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Recupera a lista de Softwares.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            return softwareListModel;
        }

        public ISoftwareModel GetById(int softwareId)
        {
            softwareModel = new SoftwareModel();
            _query = "SELECT * FROM Softwares WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {

                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", softwareId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                softwareModel.Id = int.Parse(reader["Id"].ToString());
                                softwareModel.Nome = reader["Nome"].ToString();
                                softwareModel.Descricao = reader["Descricao"].ToString();
                                softwareModel.PublicoAlvo = reader["PublicoAlvo"].ToString();
                                softwareModel.Versao = reader["Versao"].ToString();
                                softwareModel.ClienteServidor = bool.Parse(reader["ClienteServidor"].ToString());
                                softwareModel.PlataformaId = int.Parse(reader["PlataformaId"].ToString());
                                softwareModel.OsId = int.Parse(reader["OsId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Recupera o Software pelo ID.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            return softwareModel;
        }
    }
}
