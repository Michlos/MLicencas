using CommonComponents;

using DomainLayer.Clientes.Contratos.Incisos;

using ServicesLayer.Contratos.Incisos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Incisos
{
    public class IncisoRepository : IIncisosRepository
    {
        private string _connectionString, _query;
        private int idReturned;
        private IIncisoModel incisoModel;
        private List<IIncisoModel> incisoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public IncisoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IIncisoModel Add(IIncisoModel incisoModel)
        {
            this.incisoModel = new IncisoModel();
            _query = "INSERT INTO Incisos (Termo, ClausulaId) OUTPUT INSERTED.Id VALUES (@Termo, @ClusulaId)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Termo", incisoModel.Termo);
                        cmd.Parameters.AddWithValue("@ClausulaId", incisoModel.ClausulaId);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar inciso ao contrato.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.incisoModel = GetById(idReturned);
            }
            return this.incisoModel;
        }

        public void Delete(int incisoId)
        {
            _query = "DELETE Incisos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", incisoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o registro do inciso.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IIncisoModel incisoModel)
        {
            _query = "UPDATE Incisos SET Termo = @Termo, ClausulaId = @ClausulaId WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", incisoModel.Id);
                        cmd.Parameters.AddWithValue("@Termo", incisoModel.Termo);
                        cmd.Parameters.AddWithValue("@ClausulaId", incisoModel.ClausulaId);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar os dados do Inciso.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IIncisoModel> GetAll()
        {
            incisoListModel = new List<IIncisoModel>();
            _query = "SELECT * FROM Incisos";
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
                                this.incisoModel = new IncisoModel();

                                this.incisoModel.Id = int.Parse(reader["Id"].ToString());
                                this.incisoModel.Termo = reader["Termo"].ToString();
                                this.incisoModel.ClausulaId = int.Parse(reader["ClausulaId"].ToString());

                                incisoListModel.Add(this.incisoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Incisos.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return incisoListModel;
        }

        public IEnumerable<IIncisoModel> GetAllByClausula(int clausulaId)
        {
            incisoListModel = new List<IIncisoModel>();
            _query = "SELECT * FROM Incisos WHERE ClausulaId = @ClausulaId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ClausulaId", clausulaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.incisoModel = new IncisoModel();

                                this.incisoModel.Id = int.Parse(reader["Id"].ToString());
                                this.incisoModel.Termo = reader["Termo"].ToString();
                                this.incisoModel.ClausulaId = int.Parse(reader["ClausulaId"].ToString());

                                incisoListModel.Add(this.incisoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Incisos pela Clausula.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return incisoListModel;
        }

        public IIncisoModel GetById(int incisoId)
        {
            this.incisoModel = new IncisoModel();
            _query = "SELECT * FROM Incisos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", incisoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.incisoModel.Id = int.Parse(reader["Id"].ToString());
                                this.incisoModel.Termo = reader["Termo"].ToString();
                                this.incisoModel.ClausulaId = int.Parse(reader["ClausulaId"].ToString());

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Incisos pela Clausula.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.incisoModel;
        }
    }
}
