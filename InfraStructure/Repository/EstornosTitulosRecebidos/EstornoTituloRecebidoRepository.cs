using CommonComponents;

using DomainLayer.Financeiro.Recebiveis;

using ServicesLayer.EstornosTitulosRecebidos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InfraStructure.Repository.EstornosTitulosRecebidos
{
    public class EstornoTituloRecebidoRepository : IEstornosTitulosRecebidosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private IEstornoTituloRecebidoModel estornoModel;
        private List<IEstornoTituloRecebidoModel> estornoListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public IEstornoTituloRecebidoModel Add(IEstornoTituloRecebidoModel estornoModel)
        {
            _query = "INSERT INTO EstornosTitulosRecebidos (TituloRecebidoId, Valor) " +
                     "OUTPUT INSERTED.Id " +
                     "VALUES (@TituloRecebidoId, @Valor)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TituloRecebidoId", estornoModel.TituloRecebidoId);
                        cmd.Parameters.AddWithValue("@Valor", estornoModel.Valor);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar o estorno do Título Recebido.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            this.estornoModel = new EstornoTituloRecebidoModel();
            if (idReturned != 0)
            {
                this.estornoModel = GetById(idReturned);
            }
            return this.estornoModel;

        }

        public IEnumerable<IEstornoTituloRecebidoModel> GetAll()
        {
            _query = "SELECT * FROM EstornosTitulosRecebidos";
            estornoListModel = new List<IEstornoTituloRecebidoModel>();
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
                                this.estornoModel = new EstornoTituloRecebidoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TituloRecebidoId = int.Parse(reader["TituloRecebidoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                                estornoListModel.Add(this.estornoModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Estornos de Títulos Recebidos", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoListModel;
        }

        public IEstornoTituloRecebidoModel GetById(int estornoId)
        {
            _query = "SELECT * FROM EstornosTitulosRecebidos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", estornoId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.estornoModel = new EstornoTituloRecebidoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TituloRecebidoId = int.Parse(reader["TituloRecebidoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estorno de Títulos Selecionado", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoModel;
        }

        public IEstornoTituloRecebidoModel GetByTituloId(int tituloId)
        {
            _query = "SELECT * FROM EstornosTitulosRecebidos WHERE TituloRecebidoId = @TituloRecebidoId";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@TituloRecebidoId", tituloId));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.estornoModel = new EstornoTituloRecebidoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TituloRecebidoId = int.Parse(reader["TituloRecebidoId"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    Valor = double.Parse(reader["Valor"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Estorno de Títulos pelo Id do Título.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return estornoModel;
        }

        public void Remove(int estornoId)
        {
            _query = "DELETE FROM EstornosTitulosRecebidos WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", estornoId));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível apagar o Estorno.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
