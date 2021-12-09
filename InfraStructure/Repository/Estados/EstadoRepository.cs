using CommonComponents;

using DomainLayer.Enderecos;

using ServicesLayer.Estados;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Estados
{
    public class EstadoRepository : IEstadosRepository
    {
        private string _connectionString;
        private string _query;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();
        private IEstadoModel estadoModel;
        private List<IEstadoModel> estadoListModel;

        public EstadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IEstadoModel> GetAll()
        {
            _query = "SELECT * FROM Estados";
            estadoListModel = new List<IEstadoModel>();
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
                                estadoModel = new EstadoModel();

                                estadoModel.Id = int.Parse(reader["Id"].ToString());
                                estadoModel.Nome = reader["Nome"].ToString();
                                estadoModel.Uf = reader["Uf"].ToString();
                                estadoModel.CodIbge = reader["CodIbge"].ToString();

                                estadoListModel.Add(estadoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Estados", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.estadoListModel;
        }

        public IEstadoModel GetById(int estadoId)
        {
            _query = "SELECT * FROM Estados WHERE Id = @Id";
            this.estadoModel = new EstadoModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", estadoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.estadoModel.Id = int.Parse(reader["Id"].ToString());
                                this.estadoModel.Nome = reader["Nome"].ToString();
                                this.estadoModel.Uf = reader["Uf"].ToString();
                                this.estadoModel.CodIbge = reader["CodIbge"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estado pelo Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.estadoModel;
        }

        public IEstadoModel GetByUf(string uf)
        {
            _query = "SELECT * FROM Estados WHERE Uf = @Uf";
            this.estadoModel = new EstadoModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Uf", uf));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.estadoModel.Id = int.Parse(reader["Id"].ToString());
                                this.estadoModel.Nome = reader["Nome"].ToString();
                                this.estadoModel.Uf = reader["Uf"].ToString();
                                this.estadoModel.CodIbge = reader["CodIbge"].ToString();

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estado pela UF", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.estadoModel;
        }
    }
}
