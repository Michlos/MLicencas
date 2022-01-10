using CommonComponents;

using DomainLayer.Financeiro.Recebiveis;

using ServicesLayer.TitulosRecebidos;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TitulosRecebidos
{
    public class TituloRecebidoRepository : ITitulosRecebidosRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private ITituloRecebidoModel tituloModel;
        private List<ITituloRecebidoModel> tituloListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TituloRecebidoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ITituloRecebidoModel Add(ITituloRecebidoModel titulo)
        {
            _query = "INSERT INTO TitulosRecebidos " +
                     "(TituloRecebivelId, TipoRecebimentoId, ValorTitulo, ValorRecebido, DataRecebimento)" +
                     "OUTPUT INSERTED.Id" +
                     "VALUES" +
                     "(@TituloRecebivelId, @TipoRecebimentoId, @ValorTitulo, @ValorRecebido, @DataRecebimento) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TituloRecebivelId", titulo.TituloRecebivelId);
                        cmd.Parameters.AddWithValue("@TipoRecebimentoId", titulo.TipoRecebimentoId);
                        cmd.Parameters.AddWithValue("@ValorTitulo", titulo.ValorTitulo);
                        cmd.Parameters.AddWithValue("@ValorRecebido", titulo.ValorRecebido);
                        cmd.Parameters.AddWithValue("@DataRecebimento", titulo.DataRecebimento);
                        idReturned = (int)cmd.ExecuteScalar();
                        
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar Titulo Recebido.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            tituloModel = new TituloRecebidoModel();
            if (idReturned != 0)
            {
                tituloModel = GetById(idReturned);
            }
            return tituloModel;

        }

        public void Edit(ITituloRecebidoModel titulo)
        {
            _query = "UPDATE TitulosRecebidos SET " +
                     "TipoRecebimentoId = @TipoRecebimentoId, ValorRecebido = @ValorRecebido, DataRecebimento = @DataRecebimento " +
                     "WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@TipoRecebimentoId", titulo.TipoRecebimentoId);
                        cmd.Parameters.AddWithValue("@ValorRecebido", titulo.ValorRecebido);
                        cmd.Parameters.AddWithValue("@DataRecebimento", titulo.DataRecebimento);
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar o Título Recebido.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ITituloRecebidoModel> GetAll()
        {
            _query = "SELECT * FROM TitulosRecebidos";
            tituloListModel = new List<ITituloRecebidoModel>();
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
                                tituloModel = new TituloRecebidoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TituloRecebivelId = int.Parse(reader["TituloRecebivelId"].ToString()),
                                    TipoRecebimentoId = int.Parse(reader["TipoRecebimentoId"].ToString()),
                                    ValorTitulo = double.Parse(reader["ValorTitulo"].ToString()),
                                    ValorRecebido = double.Parse(reader["ValorRecebido"].ToString()),
                                    DataRecebimento = DateTime.Parse(reader["DataRecebimento"].ToString())
                                };
                                tituloListModel.Add(tituloModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Títulos Recebidos.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tituloListModel;
        }

        public ITituloRecebidoModel GetById(int tituloId)
        {
            _query = "SELECT * FROM TitulosRecebidos WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cmd.Prepare();
                            cmd.Parameters.Add(new SqlParameter("@Id", tituloId));

                            while (reader.Read())
                            {
                                tituloModel = new TituloRecebidoModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TituloRecebivelId = int.Parse(reader["TituloRecebivelId"].ToString()),
                                    TipoRecebimentoId = int.Parse(reader["TipoRecebimentoId"].ToString()),
                                    ValorTitulo = double.Parse(reader["ValorTitulo"].ToString()),
                                    ValorRecebido = double.Parse(reader["ValorRecebido"].ToString()),
                                    DataRecebimento = DateTime.Parse(reader["DataRecebimento"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Título Recebido.", e.HelpLink, e.ErrorCode, e.StackTrace);

                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tituloModel;
        }
    }
}
