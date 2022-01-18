using CommonComponents;

using DomainLayer.Financeiro.Recebiveis;

using ServicesLayer.TitulosRecebiveis;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.TitulosRecebiveis
{
    public class TituloRecebivelRepository : ITitulosRecebiveisRepository
    {
        private readonly string _connectionString;
        private string _query;
        private int idReturned;
        private ITituloRecebivelModel tituloModel;
        private List<ITituloRecebivelModel> tituloListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public TituloRecebivelRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ITituloRecebivelModel Add(ITituloRecebivelModel tituloModel)
        {
            _query = "INSERT INTO TitulosRecebiveis " +
                "(ClienteId, ContratoId, CodigoJurosMoraId, CodigoProtestoId, CodigoBaixaId, Parcela, TotalParcelas, ValorParcela, DataVencimento, DataJurosMora, TaxaJurosMOra, DiasParaProtesto, DiasParaBaixa) " +
                "OUTPUT INSERTED.Id " +
                "VALUES " +
                "(@ClienteId, @ContratoId, @CodigoJurosMoraId, @CodigoProtestoId, @CodigoBaixaId, @Parcela, @TotalParcelas, @ValorParcela, @DataVencimento, @DataJurosMora, @TaxaJurosMOra, @DiasParaProtesto, @DiasParaBaixa) ";
            this.tituloModel = new TituloRecebivelModel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@ClienteId", tituloModel.ClienteId);
                        cmd.Parameters.AddWithValue("@ContratoId", tituloModel.ContratoId);
                        cmd.Parameters.AddWithValue("@CodigoJurosMoraId", tituloModel.CodigoJurosMoraId);
                        cmd.Parameters.AddWithValue("@CodigoProtestoId", tituloModel.CodigoProtestoId);
                        cmd.Parameters.AddWithValue("@CodigoBaixaId", tituloModel.CodigoBaixaId);
                        cmd.Parameters.AddWithValue("@Parcela", tituloModel.Parcela);
                        cmd.Parameters.AddWithValue("@TotalParcelas", tituloModel.TotalParcelas);
                        cmd.Parameters.AddWithValue("@ValorParcela", tituloModel.ValorParcela);
                        cmd.Parameters.AddWithValue("@DataVencimento", tituloModel.DataVencimento);
                        cmd.Parameters.AddWithValue("@DataJurosMora", tituloModel.DataJurosMora);
                        cmd.Parameters.AddWithValue("@TaxaJurosMora", tituloModel.TaxaJurosMora);
                        cmd.Parameters.AddWithValue("@DiasParaProtesto", tituloModel.DiasParaProtesto);
                        cmd.Parameters.AddWithValue("@DiasParaBaixa", tituloModel.DiasParaBaixa);
                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o título a receber.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.tituloModel = GetById(idReturned);
            }
            return this.tituloModel;
        }

        public void Edit(ITituloRecebivelModel tituloModel)
        {
            _query = "UPDATE TitulosRecebiveis SET CodigoJurosMoraId = @CodigoJurosMoraId, " +
                "CodigoProtestoId = @CodigoProestoId, CodigoBaixaId = @CodigoBaixaId, Parcela = @Parcela, " +
                "ValorParcela = @ValorParcela, DataVencimento = @DataVencimento, DataJurosMora = @DataJurosMora, " +
                "DiasParaProtesto = @DiasParaProtesto, DiasParaBaixa = @DiasParaBaixa, Quitado = @Quitado , BoletoBancario = @BoletoBancario" +
                "WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", tituloModel.Id);
                        cmd.Parameters.AddWithValue("@CodigoJurosMoraId", tituloModel.CodigoJurosMoraId);
                        cmd.Parameters.AddWithValue("@CodigoProtestoId", tituloModel.CodigoProtestoId);
                        cmd.Parameters.AddWithValue("@CodigoBaixaId", tituloModel.CodigoBaixaId);
                        cmd.Parameters.AddWithValue("@Parcela", tituloModel.Parcela);
                        cmd.Parameters.AddWithValue("@ValorParcela", tituloModel.ValorParcela);
                        cmd.Parameters.AddWithValue("@DataVencimento", tituloModel.DataVencimento);
                        cmd.Parameters.AddWithValue("@DataJurosMora", tituloModel.DataJurosMora);
                        cmd.Parameters.AddWithValue("@TaxaJurosMora", tituloModel.TaxaJurosMora);
                        cmd.Parameters.AddWithValue("@DiasParaProtesto", tituloModel.DiasParaProtesto);
                        cmd.Parameters.AddWithValue("@DiasParaBaixa", tituloModel.DiasParaBaixa);
                        cmd.Parameters.AddWithValue("@Quitado", tituloModel.Quitado);
                        cmd.Parameters.AddWithValue("@BoletoBancario", tituloModel.BoletoBancario);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível editar o título a receber.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<ITituloRecebivelModel> GetAll()
        {
            _query = "SELECT * FROM TitulosRecebiveis";
            tituloListModel = new List<ITituloRecebivelModel>();
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
                                this.tituloModel = new TituloRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ClienteId = int.Parse(reader["ClienteId"].ToString()),
                                    ContratoId = int.Parse(reader["ContratoId"].ToString()),
                                    CodigoJurosMoraId = int.Parse(reader["CodigoJurosMoraId"].ToString()),
                                    CodigoProtestoId = int.Parse(reader["CodigoProtestoId"].ToString()),
                                    CodigoBaixaId = int.Parse(reader["CodigoBaixaId"].ToString()),
                                    Parcela = int.Parse(reader["Parcela"].ToString()),
                                    TotalParcelas = int.Parse(reader["TotalParcelas"].ToString()),
                                    ValorParcela = double.Parse(reader["ValorParcela"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    DataJurosMora = DateTime.Parse(reader["DataJurosMora"].ToString()),
                                    TaxaJurosMora = double.Parse(reader["TaxaJurosMora"].ToString()),
                                    DiasParaProtesto = int.Parse(reader["DiasParaProtesto"].ToString()),
                                    DiasParaBaixa = int.Parse(reader["DiasParaBaixa"].ToString()),
                                    Quitado = bool.Parse(reader["Quitado"].ToString()),
                                    BoletoBancario = bool.Parse(reader["BoletoBancario"].ToString())
                                };
                                tituloListModel.Add(this.tituloModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Titulos a Receber.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tituloListModel;
        }

        public IEnumerable<ITituloRecebivelModel> GetAllByClienteId(int clienteId)
        {
            _query = "SELECT * FROM TitulosRecebiveis WHERE ClienteId = @ClienteId";
            tituloListModel = new List<ITituloRecebivelModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ClienteId", clienteId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.tituloModel = new TituloRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ClienteId = int.Parse(reader["ClienteId"].ToString()),
                                    ContratoId = int.Parse(reader["ContratoId"].ToString()),
                                    CodigoJurosMoraId = int.Parse(reader["CodigoJurosMoraId"].ToString()),
                                    CodigoProtestoId = int.Parse(reader["CodigoProtestoId"].ToString()),
                                    CodigoBaixaId = int.Parse(reader["CodigoBaixaId"].ToString()),
                                    Parcela = int.Parse(reader["Parcela"].ToString()),
                                    TotalParcelas = int.Parse(reader["TotalParcelas"].ToString()),
                                    ValorParcela = double.Parse(reader["ValorParcela"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    DataJurosMora = DateTime.Parse(reader["DataJurosMora"].ToString()),
                                    TaxaJurosMora = double.Parse(reader["TaxaJurosMora"].ToString()),
                                    DiasParaProtesto = int.Parse(reader["DiasParaProtesto"].ToString()),
                                    DiasParaBaixa = int.Parse(reader["DiasParaBaixa"].ToString()),
                                    Quitado = bool.Parse(reader["Quitado"].ToString()),
                                    BoletoBancario = bool.Parse(reader["BoletoBancario"].ToString())
                                };
                                tituloListModel.Add(this.tituloModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Titulos a Receber do Cliente Selecionado.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tituloListModel;
        }

        public IEnumerable<ITituloRecebivelModel> GetAllByContratoId(int contratoId)
        {
            _query = "SELECT * FROM TitulosRecebiveis WHERE ContratoId = @ContratoId";
            tituloListModel = new List<ITituloRecebivelModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@ContratoId", contratoId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.tituloModel = new TituloRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ClienteId = int.Parse(reader["ClienteId"].ToString()),
                                    ContratoId = int.Parse(reader["ContratoId"].ToString()),
                                    CodigoJurosMoraId = int.Parse(reader["CodigoJurosMoraId"].ToString()),
                                    CodigoProtestoId = int.Parse(reader["CodigoProtestoId"].ToString()),
                                    CodigoBaixaId = int.Parse(reader["CodigoBaixaId"].ToString()),
                                    Parcela = int.Parse(reader["Parcela"].ToString()),
                                    TotalParcelas = int.Parse(reader["TotalParcelas"].ToString()),
                                    ValorParcela = double.Parse(reader["ValorParcela"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    DataJurosMora = DateTime.Parse(reader["DataJurosMora"].ToString()),
                                    TaxaJurosMora = double.Parse(reader["TaxaJurosMora"].ToString()),
                                    DiasParaProtesto = int.Parse(reader["DiasParaProtesto"].ToString()),
                                    DiasParaBaixa = int.Parse(reader["DiasParaBaixa"].ToString()),
                                    Quitado = bool.Parse(reader["Quitado"].ToString()),
                                    BoletoBancario = bool.Parse(reader["BoletoBancario"].ToString())
                                };
                                tituloListModel.Add(this.tituloModel);
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Titulos a Receber do Contrato Selecionado.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return tituloListModel;
        }

        public ITituloRecebivelModel GetById(int tituloId)
        {
            _query = "SELECT * FROM TitulosRecebiveis WHERE Id = @Id";
            tituloListModel = new List<ITituloRecebivelModel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", tituloId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                this.tituloModel = new TituloRecebivelModel()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    ClienteId = int.Parse(reader["ClienteId"].ToString()),
                                    ContratoId = int.Parse(reader["ContratoId"].ToString()),
                                    CodigoJurosMoraId = int.Parse(reader["CodigoJurosMoraId"].ToString()),
                                    CodigoProtestoId = int.Parse(reader["CodigoProtestoId"].ToString()),
                                    CodigoBaixaId = int.Parse(reader["CodigoBaixaId"].ToString()),
                                    Parcela = int.Parse(reader["Parcela"].ToString()),
                                    TotalParcelas = int.Parse(reader["TotalParcelas"].ToString()),
                                    ValorParcela = double.Parse(reader["ValorParcela"].ToString()),
                                    DataRegistro = DateTime.Parse(reader["DataRegistro"].ToString()),
                                    DataVencimento = DateTime.Parse(reader["DataVencimento"].ToString()),
                                    DataJurosMora = DateTime.Parse(reader["DataJurosMora"].ToString()),
                                    TaxaJurosMora = double.Parse(reader["TaxaJurosMora"].ToString()),
                                    DiasParaProtesto = int.Parse(reader["DiasParaProtesto"].ToString()),
                                    DiasParaBaixa = int.Parse(reader["DiasParaBaixa"].ToString()),
                                    Quitado = bool.Parse(reader["Quitado"].ToString()),
                                    BoletoBancario = bool.Parse(reader["BoletoBancario"].ToString())
                                };
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Titulo a Receber.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.tituloModel;
        }
    }
}
