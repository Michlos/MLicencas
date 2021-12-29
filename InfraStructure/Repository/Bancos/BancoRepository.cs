using CommonComponents;

using DomainLayer.Financeiro;

using ServicesLayer.Bancos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Bancos
{
    public class BancoRepository : IBancosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private IBancoModel bancoModel;
        private List<IBancoModel> bancoListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();
        private int idReturned;

        public BancoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IBancoModel Add(IBancoModel bancoModel)
        {
            _query = "INSERT INTO Bancos (Nome, CodigoBC) OUTPUT INSERTED.Id VALUES (@Nome, @CodigoBC)";

            this.bancoModel = new BancoModel();
            
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Nome", bancoModel.Nome);
                        cmd.Parameters.AddWithValue("@CodigoBC", bancoModel.CodigoBc);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o Banco.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.bancoModel = GetById(idReturned);
            }

            return this.bancoModel;
        }

        public void Edit(IBancoModel bancoModel)
        {
            _query = "UPDATE Bancos SET Nome = @Nome, CodigoBC = @CodigoBC WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", bancoModel.Id);
                        cmd.Parameters.AddWithValue("@Nome", bancoModel.Nome);
                        cmd.Parameters.AddWithValue("@CodigoBC", bancoModel.CodigoBc);
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atalizar os dados do Banco", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IBancoModel> GetAll()
        {
            _query = "SELECT * FROM Bancos";
            bancoListModel = new List<IBancoModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bancoModel = new BancoModel();

                                bancoModel.Id = int.Parse(reader["Id"].ToString());
                                bancoModel.Nome = reader["Nome"].ToString();
                                bancoModel.CodigoBc = reader["CodigoBC"].ToString();

                                bancoListModel.Add(bancoModel);

                                
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Bancos.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return bancoListModel;
        }

        public IBancoModel GetById(int bancoId)
        {
            _query = "SELECT * FROM Bancos WHERE Id = @Id";

            bancoModel = new BancoModel();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", bancoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                bancoModel.Id = int.Parse(reader["Id"].ToString());
                                bancoModel.Nome = reader["Nome"].ToString();
                                bancoModel.CodigoBc = reader["CodigoBC"].ToString();
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Banco pelo ID", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return bancoModel;
        }

        public void Remove(int bancoId)
        {
            _query = "DELETE Bancos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", bancoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover o Banco.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
