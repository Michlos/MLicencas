using CommonComponents;

using DomainLayer.Financeiro;

using ServicesLayer.ContasBancarias;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.ContaBancaria
{
    public class ContaBancariaRepository : IContasBancariasRepository
    {
        private readonly string _connectonString;
        private string _query;
        private IContaBancariaModel contaModel;
        private List<IContaBancariaModel> contaListModel;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        private int idReturned;

        public ContaBancariaRepository(string connectonString)
        {
            _connectonString = connectonString;
        }

        public IContaBancariaModel Add(IContaBancariaModel contaModel)
        {
            _query = "INSERT INTO ContasBancarias (Agencia, AgenciaDV, Conta, ContaDV, EmiteBoleto, BancoId, TipoContaId) " +
                     " OUTPUT INSERTED.Id " +
                     " VALUES " +
                     " (@Agencia, @AgenciaDV, @Conta, @ContaDV, @EmiteBoleto, @BancoId, @TipoContaId)";
            this.contaModel = new ContaBancariaModel();
            using (SqlConnection connection = new SqlConnection(_connectonString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@Agencia", contaModel.Agencia);
                        cmd.Parameters.AddWithValue("@AgenciaDV", contaModel.AgenciaDV);
                        cmd.Parameters.AddWithValue("@Conta", contaModel.Conta);
                        cmd.Parameters.AddWithValue("@ContaDV", contaModel.ContaDV);
                        cmd.Parameters.AddWithValue("@EmiteBoleto", contaModel.EmiteBoleto);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.BancoId);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.TipoContaId);

                        idReturned = (int)cmd.ExecuteScalar();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível registrar a conta bancária.", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            if (idReturned != 0)
            {
                this.contaModel = GetById(idReturned);
            }
            return this.contaModel;
        }

        public void Edit(IContaBancariaModel contaModel)
        {
            _query = "UPDATE ContasBancarias SET " +
                " Agencia = @Agencia, AgenciaDV = @AgenciaDV, Conta = @Conta, ContaDV = @ContaDV, EmiteBoleto = @EmiteBoleto " +
                " WHERE Id = @Id ";
            using (SqlConnection connection = new SqlConnection(_connectonString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(_query, connection))
                    {
                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@Id", contaModel.Id);
                        cmd.Parameters.AddWithValue("@Agencia", contaModel.Agencia);
                        cmd.Parameters.AddWithValue("@AgenciaDV", contaModel.AgenciaDV);
                        cmd.Parameters.AddWithValue("@Conta", contaModel.Conta);
                        cmd.Parameters.AddWithValue("@ContaDV", contaModel.ContaDV);
                        cmd.Parameters.AddWithValue("@EmiteBoleto", contaModel.EmiteBoleto);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.BancoId);
                        cmd.Parameters.AddWithValue("@BancoId", contaModel.TipoContaId);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível atualizar dados da Conta Bancária", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<IContaBancariaModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContaBancariaModel> GetAllByBancoId(int bancoId)
        {
            throw new NotImplementedException();
        }

        public IContaBancariaModel GetById(int contaId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int contaId)
        {
            throw new NotImplementedException();
        }
    }
}
