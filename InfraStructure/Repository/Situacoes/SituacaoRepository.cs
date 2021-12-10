using CommonComponents;

using DomainLayer.Situacao;

using ServicesLayer.SituacoesServices;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.Situacoes
{
    public class SituacaoRepository : ISituacoesRepository
    {
        private string _connectionString;
        private string _query;
        private ISituacaoModel situacaoModel;
        private List<ISituacaoModel> situacaoListModel;
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public SituacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ISituacaoModel> GetAll()
        {
            this.situacaoListModel = new List<ISituacaoModel>();
            _query = "SELECT * FROM Situacao";
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
                                this.situacaoModel = new SituacaoModel();

                                this.situacaoModel.Id = int.Parse(reader["Id"].ToString());
                                this.situacaoModel.Descricao = reader["Descricao"].ToString();

                                this.situacaoListModel.Add(this.situacaoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Status/Situações", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.situacaoListModel;
        }

        public ISituacaoModel GetById(int situacaoId)
        {
            this.situacaoModel = new SituacaoModel();
            _query = "SELECT * FROM Situacao WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", situacaoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.situacaoModel.Id = int.Parse(reader["Id"].ToString());
                                this.situacaoModel.Descricao = reader["Descricao"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Status/Situação", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.situacaoModel;
        }
    }
}
