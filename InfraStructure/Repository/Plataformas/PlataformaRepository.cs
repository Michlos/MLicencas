using CommonComponents;

using DomainLayer.Softwares.Plataformas;

using ServicesLayer.Plataformas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Plataformas
{
    public class PlataformaRepository : IPlataformasRepository
    {
        private string _connectionString;
        private string _query;
        private int idReturned;
        private IPlataformaModel plataformaModel;
        private List<IPlataformaModel> plataformaListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();


        public PlataformaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IPlataformaModel Add(IPlataformaModel plataforma)
        {
            plataformaModel = new PlataformaModel();
            _query = "INSERT INTO Plataformas (Nome) OUTPUT INSERTED.Id VALUES (@Nome)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", plataforma.Nome);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Adicionar Plataforma", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                plataformaModel = GetById(idReturned);
            }
            return plataformaModel;
        }

        public void Edit(IPlataformaModel plataforma)
        {
            _query = "UPDATE Plataformas SET Nome = @Nome WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", plataforma.Id);
                        cmd.Parameters.AddWithValue("@Nome", plataforma.Nome);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Editar a Plataforma", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }


            }
        }

        public IEnumerable<IPlataformaModel> GetAll()
        {
            _query = "SELECT * FROM Plataformas";
            plataformaListModel = new List<IPlataformaModel>();
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
                                plataformaModel = new PlataformaModel();

                                plataformaModel.Id = int.Parse(reader["Id"].ToString());
                                plataformaModel.Nome = reader["Nome"].ToString();

                                plataformaListModel.Add(plataformaModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Plataformas", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return plataformaListModel;
        }

        public IPlataformaModel GetById(int plataformaId)
        {
            _query = "SELECT * FROM Plataformas WHERE Id = @Id";
            plataformaModel = new PlataformaModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("Id", plataformaId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                plataformaModel.Id = int.Parse(reader["Id"].ToString());
                                plataformaModel.Nome = reader["Nome"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Plataformas", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return plataformaModel;
        }
    }
}
