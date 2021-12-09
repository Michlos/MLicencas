using CommonComponents;

using DomainLayer.Enderecos;

using ServicesLayer.TiposEnderecos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TiposEnderecos
{
    public class TipoEnderecoRepository : ITiposEnderecosRepository
    {
        private string _connectionString;
        private string _query;
        private ITipoEnderecoModel tipoEnderecoModel;
        private List<ITipoEnderecoModel> tipoEnderecoListModel;
        DataAccessStatus dataAccessSatatus = new DataAccessStatus();

        public TipoEnderecoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITipoEnderecoModel> GetAll()
        {
            this.tipoEnderecoListModel = new List<ITipoEnderecoModel>();
            _query = "SELECT * FROM TiposEndereco";
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
                                this.tipoEnderecoModel = new TipoEnderecoModel();
                                this.tipoEnderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.tipoEnderecoModel.Tipo = reader["Tipo"].ToString();
                                this.tipoEnderecoListModel.Add(this.tipoEnderecoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessSatatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Endereços", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessSatatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.tipoEnderecoListModel;
        }

        public ITipoEnderecoModel GetById(int id)
        {
            this.tipoEnderecoModel = new TipoEnderecoModel();
            _query = "SELECT * FROM TiposEndereco WHERE Id = @Id";
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
                                this.tipoEnderecoModel.Id = int.Parse(reader["Id"].ToString());
                                this.tipoEnderecoModel.Tipo = reader["Tipo"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessSatatus.setValues("Error", false, e.Message, "Não foi possível recuperar Tipos de Endereço pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessSatatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.tipoEnderecoModel;
        }
    }
}
