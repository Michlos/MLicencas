using CommonComponents;

using DomainLayer.Fabrica;

using ServicesLayer.Fabrica;

using System.Data.SqlClient;

namespace InfraStructure.Repository.Fabrica
{
    public class FabricaRepository : IFabricaRepository
    {
        private string _connectionString;
        private string _query;
        private IFabricaModel fabricaModel;
        DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public FabricaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IFabricaModel Add(IFabricaModel fabrica)
        {
            this.fabricaModel = new FabricaModel();
            _query = "INSERT INTO Fabrica " +
                    "(NomeFantasia, RazaoSocial, Cnpj, Ie, Email, WebSite) " +
                    "VALUES " +
                    "(@NomeFantasia, @RazaoSocial, @Cnpj, @Ie, @Email, @WebSite) ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@NomeFantasia", fabrica.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", fabrica.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", fabrica.Cnpj);
                        cmd.Parameters.AddWithValue("@Ie", fabrica.Ie);
                        cmd.Parameters.AddWithValue("@Email", fabrica.Email);
                        cmd.Parameters.AddWithValue("@WebSite", fabrica.WebSite);

                        cmd.ExecuteNonQuery();
                        this.fabricaModel = GetFabrica();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível adicionar a Fábrica no sistema", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.fabricaModel;
        }

        public void Edit(IFabricaModel fabrica)
        {
            _query = "UPDATE Fabrica SET " +
                    "NomeFantasia = @NomeFantasia, RazaoSocial = @RazaoSocial, Cnpj = @Cnpj, Ie = @Ie, Email = @Email, WebSite = @WebSite ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@NomeFantasia", fabrica.NomeFantasia);
                        cmd.Parameters.AddWithValue("@RazaoSocial", fabrica.RazaoSocial);
                        cmd.Parameters.AddWithValue("@Cnpj", fabrica.Cnpj);
                        cmd.Parameters.AddWithValue("@Ie", fabrica.Ie);
                        cmd.Parameters.AddWithValue("@Email", fabrica.Email);
                        cmd.Parameters.AddWithValue("@WebSite", fabrica.WebSite);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível alterar os dados  da Fábrica", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IFabricaModel GetFabrica()
        {
            this.fabricaModel = new FabricaModel();
            _query = "SELECT * FROM Fabrica";
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
                                this.fabricaModel.Id = int.Parse(reader["Id"].ToString());
                                this.fabricaModel.NomeFantasia = reader["NomeFantasia"].ToString();
                                this.fabricaModel.RazaoSocial = reader["RazaoSocial"].ToString();
                                this.fabricaModel.Cnpj = reader["Cnpj"].ToString();
                                this.fabricaModel.Ie = reader["Ie"].ToString();
                                this.fabricaModel.Email = reader["Email"].ToString();
                                this.fabricaModel.WebSite = reader["WebSite"].ToString();


                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    this.dataAccessStatus.setValues("Erro", false, e.Message, "Não foi possível recuperar os dados da Fábrica", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return this.fabricaModel;
        }
    }
}
