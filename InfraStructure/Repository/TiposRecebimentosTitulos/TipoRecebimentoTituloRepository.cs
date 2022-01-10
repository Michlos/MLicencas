using CommonComponents;

using DomainLayer.Financeiro.Recebiveis;

using ServicesLayer.TiposRecebimentosTitulos;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.TiposRecebimentosTitulos
{
    public class TipoRecebimentoTituloRepository : ITiposRecebimentosTitulosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private ITipoRecebimentoTituloModel tipoModel;
        private List<ITipoRecebimentoTituloModel> tipoListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public IEnumerable<ITipoRecebimentoTituloModel> GetAll()
        {
            _query = "SELECT * FROM TipoRecebimentoTitulo";
            tipoListModel = new List<ITipoRecebimentoTituloModel>();
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
                                tipoModel = new TipoRecebimentoTituloModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = reader["Tipo"].ToString()
                                };
                                tipoListModel.Add(tipoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Recebimentos de Título", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoListModel;
        }

        public ITipoRecebimentoTituloModel GetById(int id)
        {
            _query = "SELECT * FROM TipoRecebimentoTitulo WHERE Id = @Id";
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
                                tipoModel = new TipoRecebimentoTituloModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = reader["Tipo"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Tipo de Recebimento de Título por Id", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tipoModel;
        }
    }
}
