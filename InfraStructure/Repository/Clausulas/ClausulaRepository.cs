using CommonComponents;

using DomainLayer.Clientes.Contratos.Clausulas;

using ServicesLayer.Clausulas;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Clausulas
{
    public class ClausulaRepository : IClausulasRepository
    {
        private string _connectionString;
        private string _query;
        private IClausulaModel clausulaModel;
        private List<IClausulaModel> clausulaListModel = new List<IClausulaModel>();
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public ClausulaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IClausulaModel Add(IClausulaModel clausula)
        {
            int idReturned;
            this.clausulaModel = new ClausulaModel();
            _query = "INSERT INTO Clausulas (Titulo, ContratoId) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES (@Titulo, @ContratoId) ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Titulo", clausula.Titulo);
                        cmd.Parameters.AddWithValue("@ContratoId", clausula.ContratoId);

                        idReturned = (int)cmd.ExecuteScalar();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar a Cláusula.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.clausulaModel = GetById(idReturned);
            }
            return this.clausulaModel;
        }

        public void Delete(int clausulaId)
        {
            _query = "DELETE Clausulas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.Add(new SqlParameter("@Id", clausulaId));

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover a Cláusula do contrato.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Edit(IClausulaModel clausula)
        {
            _query = "UPDATE Clausulas SET Titulo = @Titulo, WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", clausula.Id);
                        cmd.Parameters.AddWithValue("@Titulo", clausula.Titulo);

                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível alterar a Cláusula do contrato.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IClausulaModel> GetAll()
        {
            this.clausulaListModel.Clear();
            _query = "SELECT * FROM Clausulas";
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
                                this.clausulaModel = new ClausulaModel();

                                this.clausulaModel.Id = int.Parse(reader["Id"].ToString());
                                this.clausulaModel.Titulo = reader["Titulo"].ToString();
                                this.clausulaModel.ContratoId = int.Parse(reader["ContratoId"].ToString());

                                this.clausulaListModel.Add(this.clausulaModel);


                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Cláusulas.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.clausulaListModel;
        }

        public IEnumerable<IClausulaModel> GetAllByContratoId(int contratoId)
        {
            this.clausulaListModel.Clear();
            _query = "SELECT * FROM Clausulas WHERE ContratoId = @ContratoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContratoId", contratoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.clausulaModel = new ClausulaModel();

                                this.clausulaModel.Id = int.Parse(reader["Id"].ToString());
                                this.clausulaModel.Titulo = reader["Titulo"].ToString();
                                this.clausulaModel.ContratoId = int.Parse(reader["ContratoId"].ToString());

                                this.clausulaListModel.Add(this.clausulaModel);


                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Cláusulas do Contrato.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.clausulaListModel;
        }

        public IClausulaModel GetById(int clausulaId)
        {
            this.clausulaModel = new ClausulaModel();
            _query = "SELECT * FROM Clausulas WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", clausulaId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.clausulaModel.Id = int.Parse(reader["Id"].ToString());
                                this.clausulaModel.Titulo = reader["Titulo"].ToString();
                                this.clausulaModel.ContratoId = int.Parse(reader["ContratoId"].ToString());
                            }
                        }

                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar os dados da Cláusulas por Id", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.clausulaModel;
        }
    }
}
