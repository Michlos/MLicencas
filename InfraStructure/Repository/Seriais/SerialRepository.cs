using CommonComponents;

using DomainLayer.Clientes.Contratos.Seriais;

using ServicesLayer.Seriais;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.Seriais
{
    public class SerialRepository : ISeriaisRepository
    {
        private string _connectionString;
        private string _query;
        private ISerialModel serialModel;
        private List<ISerialModel> serialListModel = new List<ISerialModel>();
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public SerialRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISerialModel Add(ISerialModel serial)
        {
            int idReturned;
            serialModel = new SerialModel();
            _query = "INSERT INTO Seriais (SoftwareId, ClienteId, ContratoId, Chave, HashChave, HashCliente) " +
                "OUTPUT INSERTED.Id " +
                "VALUES  " +
                "(@SoftwareId, @ClienteId, @ContratoId, @Chave, @HashChave, @HashCliente)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@SoftwareId", serial.SoftwareId);
                        cmd.Parameters.AddWithValue("@ClienteId", serial.ClienteId);
                        cmd.Parameters.AddWithValue("@ContratoId", serial.ContratoId);
                        cmd.Parameters.AddWithValue("@Chave", serial.Chave);
                        cmd.Parameters.AddWithValue("@HashChave", serial.HashChave);
                        cmd.Parameters.AddWithValue("@HashCliente", serial.HashCliente);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível adicionar o novo Serial.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.serialModel = GetById(idReturned);
            }
            return this.serialModel;

        }

        public IEnumerable<ISerialModel> GetAllByClienteId(int clienteId)
        {
            this.serialListModel.Clear();
            _query = "SELECT * FROM Seriais WHERE ClienteId = @ClienteId";
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
                                this.serialModel = new SerialModel();

                                this.serialModel.Id = int.Parse(reader["Id"].ToString());
                                this.serialModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                this.serialModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.serialModel.ContratoId = int.Parse(reader["ContratoId"].ToString());
                                this.serialModel.Chave = reader["Chave"].ToString();
                                this.serialModel.HashChave = reader["HashChave"].ToString();
                                this.serialModel.HashCliente = reader["HashCliente"].ToString();

                                this.serialListModel.Add(this.serialModel);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar lista de Números de Série do cliente.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.serialListModel;
        }

        public ISerialModel GetByContratoId(int contratoId)
        {
            this.serialModel = new SerialModel();
            _query = "SELECT * FROM Seriais WHERE ContratoId = @ContratoId";
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

                                this.serialModel.Id = int.Parse(reader["Id"].ToString());
                                this.serialModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                this.serialModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.serialModel.ContratoId = int.Parse(reader["ContratoId"].ToString());
                                this.serialModel.Chave = reader["Chave"].ToString();
                                this.serialModel.HashChave = reader["HashChave"].ToString();
                                this.serialModel.HashCliente = reader["HashCliente"].ToString();


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Número de Série do Contrato.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.serialModel;
        }

        public ISerialModel GetById(int serialId)
        {
            this.serialModel = new SerialModel();
            _query = "SELECT * FROM Seriais WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", serialId));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                this.serialModel.Id = int.Parse(reader["Id"].ToString());
                                this.serialModel.SoftwareId = int.Parse(reader["SoftwareId"].ToString());
                                this.serialModel.ClienteId = int.Parse(reader["ClienteId"].ToString());
                                this.serialModel.ContratoId = int.Parse(reader["ContratoId"].ToString());
                                this.serialModel.Chave = reader["Chave"].ToString();
                                this.serialModel.HashChave = reader["HashChave"].ToString();
                                this.serialModel.HashCliente = reader["HashCliente"].ToString();


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar o Número de Série pelo Id.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.serialModel;
        }

        public ISerialModel Renew(ISerialModel serial)
        {
            
            this.serialModel = new SerialModel();
            _query = "UPDATE Seriais SET Chave = @Chave, HashChave = @HashChave WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Id", serial.Id);
                        cmd.Parameters.AddWithValue("@Chave", serial.Chave);
                        cmd.Parameters.AddWithValue("@HashChave", serial.HashChave);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível renovar o Número de Série.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }

            }
            this.serialModel = GetById(serial.Id);
            return this.serialModel;

        }

        public void UnloadHash(int serialId)
        {
            _query = "UPDATE Seriais SET HashChave = @HashChave WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.Add(new SqlParameter("@Id", serialId));
                        cmd.Parameters.Add(new SqlParameter("@HashChave", string.Empty));
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível remover a Hash da Série.", e.HelpLink, e.ErrorCode, e.StackTrace);
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
