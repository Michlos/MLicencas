using CommonComponents;

using DomainLayer.Telefones;

using ServicesLayer.TiposTelefones;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TiposTelefones
{
    public class TipoTelefoneRepository : ITiposTelefonesRepository
    {
        private string _connectionString;
        private string _query;
        private ITipoTelefoneModel tipoTelefoneModel;
        private List<ITipoTelefoneModel> tipoTelefoneListModel;
        DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TipoTelefoneRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoTelefoneModel> GetAll()
        {
            this.tipoTelefoneListModel = new List<ITipoTelefoneModel>();
            _query = "SELECT * FROM TiposTelefone";

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
                                this.tipoTelefoneModel = new TipoTelefoneModel();

                                this.tipoTelefoneModel.Id = int.Parse(reader["Id"].ToString());
                                this.tipoTelefoneModel.Tipo = reader["Tipo"].ToString();
                                this.tipoTelefoneModel.Mascara = reader["Mascara"].ToString();

                                this.tipoTelefoneListModel.Add(this.tipoTelefoneModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Telefones", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.tipoTelefoneListModel;
        }

        public ITipoTelefoneModel GetById(int tipoId)
        {
            this.tipoTelefoneModel = new TipoTelefoneModel();
            _query = "SELECT * FROM TiposTelefone WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", tipoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.tipoTelefoneModel.Id = int.Parse(reader["Id"].ToString());
                                this.tipoTelefoneModel.Tipo = reader["Tipo"].ToString();
                                this.tipoTelefoneModel.Mascara = reader["Mascara"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Telefones", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.tipoTelefoneModel;
        }
    }
}
