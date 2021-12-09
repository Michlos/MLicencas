using CommonComponents;

using DomainLayer.Enderecos;

using ServicesLayer.Cidades;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Cidades
{
    public class CidadeRepository : ICidadesRepository
    {
        private string _connectionString;
        private ICidadeModel cidadeModel;
        private List<ICidadeModel> cidadeListModel;
        private string _query;
        DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public CidadeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ICidadeModel> GetAll()
        {
            this.cidadeListModel = new List<ICidadeModel>();
            _query = "SELECT * FROM Cidades";
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
                                this.cidadeModel = new CidadeModel();

                                this.cidadeModel.Id = int.Parse(reader["Id"].ToString());
                                this.cidadeModel.Nome = reader["Nome"].ToString();
                                this.cidadeModel.Uf = reader["Uf"].ToString();
                                this.cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                this.cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                this.cidadeListModel.Add(this.cidadeModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista das Cidades", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.cidadeListModel;
        }

        public IEnumerable<ICidadeModel> GetAllByUf(string uf)
        {
            this.cidadeListModel = new List<ICidadeModel>();
            _query = "SELECT * FROM Cidades WHERE Uf = @Uf";
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
                                this.cidadeModel = new CidadeModel();

                                this.cidadeModel.Id = int.Parse(reader["Id"].ToString());
                                this.cidadeModel.Nome = reader["Nome"].ToString();
                                this.cidadeModel.Uf = reader["Uf"].ToString();
                                this.cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                this.cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                this.cidadeListModel.Add(this.cidadeModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista das Cidades", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.cidadeListModel;
        }

        public IEnumerable<ICidadeModel> GetAllByUfId(int ufId)
        {
            this.cidadeListModel = new List<ICidadeModel>();
            _query = "SELECT * FROM Cidades WHERE EstadoId = @EstadoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@EstadoId", ufId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.cidadeModel = new CidadeModel();

                                this.cidadeModel.Id = int.Parse(reader["Id"].ToString());
                                this.cidadeModel.Nome = reader["Nome"].ToString();
                                this.cidadeModel.Uf = reader["Uf"].ToString();
                                this.cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                this.cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());

                                this.cidadeListModel.Add(this.cidadeModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista das Cidades", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.cidadeListModel;
        }

        public ICidadeModel GetById(int cidadeId)
        {
            this.cidadeModel = new CidadeModel();
            _query = "SELECT * FROM Cidades WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", cidadeId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.cidadeModel.Id = int.Parse(reader["Id"].ToString());
                                this.cidadeModel.Nome = reader["Nome"].ToString();
                                this.cidadeModel.Uf = reader["Uf"].ToString();
                                this.cidadeModel.CodIbge = reader["CodIbge"].ToString();
                                this.cidadeModel.EstadoId = int.Parse(reader["EstadoId"].ToString());
                                
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista das Cidades", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.cidadeModel;
        }
    }
}
