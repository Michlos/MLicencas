using CommonComponents;

using DomainLayer.Softwares.SistemasOperacionais;

using ServicesLayer.SistemasOperacionais;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.SistemasOperacionais
{
    public class SistemaOperacionalRepository : ISistemasOperacionaisRepository
    {
        private string _connectionString, _query;
        private int idReturned;
        private ISistemaOperacionalModel osModel;
        private List<ISistemaOperacionalModel> osListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();


        public SistemaOperacionalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public ISistemaOperacionalModel Add(ISistemaOperacionalModel osModel)
        {
            _query = "INSERT INTO SistemasOperacionais (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
            osModel = new SistemaOperacionalModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", osModel.Nome);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Adicionar o Sistema Operacional.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                osModel = GetById(idReturned);
            }
            return osModel;
        }

        public void Edit(ISistemaOperacionalModel osModel)
        {
            _query = "UPDATE SistemasOperacionais SET Nome = @Nome WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", osModel.Id);
                        cmd.Parameters.AddWithValue("@Nome", osModel.Nome);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Editar o Sistema Operacional.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ISistemaOperacionalModel> GetAll()
        {
            _query = "SELECT * FROM SistemasOperacionais";
            osListModel = new List<ISistemaOperacionalModel>();
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
                                osModel = new SistemaOperacionalModel();

                                osModel.Id = int.Parse(reader["Id"].ToString());
                                osModel.Nome = reader["Nome"].ToString();

                                osListModel.Add(osModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a Lista de Sistemas Operacionais.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return osListModel;
        }

        public ISistemaOperacionalModel GetById(int osId)
        {
            _query = "SELECT * FROM SistemasOperacionais WHERE Id = @Id";
            osModel = new SistemaOperacionalModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", osId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                osModel.Id = int.Parse(reader["Id"].ToString());
                                osModel.Nome = reader["Nome"].ToString();


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar Sistema Operacional pelo ID.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return osModel;
        }
    }
}
