using CommonComponents;

using DomainLayer.Financeiro.Recebiveis;

using ServicesLayer.DestinosRecebimentos;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.DestinosRecebiveis
{
    public class DestinoRecebivelRepository : IDestinosRecebiveisRepository
    {
        private readonly string _connectionString;
        private string _query;
        private readonly List<IDestinoRecebivelModel> destinoListModel = new List<IDestinoRecebivelModel>();
        private IDestinoRecebivelModel destinoModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public DestinoRecebivelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IDestinoRecebivelModel> GetAll()
        {
            _query = "SELECT * FROM DestinosRecebiveis";
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
                                destinoModel = new DestinoRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Destino = reader["Destino"].ToString(),
                                    Codigo = char.Parse(reader["Codigo"].ToString())
                                };
                                destinoListModel.Add(destinoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Origens de Recebíveis.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return destinoListModel;
        }

        public IDestinoRecebivelModel GetByCodigo(char codigo)
        {
            _query = "SELECT * FROM DestinosRecebiveis WHERE Codigo = @Codigo";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Codigo", codigo));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                destinoModel = new DestinoRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Destino = reader["Destino"].ToString(),
                                    Codigo = char.Parse(reader["Codigo"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Origens de Recebíveis.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return destinoModel;
        }

        public IDestinoRecebivelModel GetById(int id)
        {
            _query = "SELECT * FROM DestinosRecebiveis WHERE ID = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                destinoModel = new DestinoRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Destino = reader["Destino"].ToString(),
                                    Codigo = char.Parse(reader["Codigo"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Origens de Recebíveis.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return destinoModel;
        }
    }
}
