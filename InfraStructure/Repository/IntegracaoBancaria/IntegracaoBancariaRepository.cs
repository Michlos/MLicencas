using CommonComponents;

using DomainLayer.Financeiro.Integracoes.Bancaria;

using ServicesLayer.Integracao.Bancaria;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraStructure.Repository.IntegracaoBancaria
{
    public class IntegracaoBancariaRepository : IIntegracaoBancariaRepository
    {
        private readonly string _connectionString;
        private string _query;
        private readonly DataAccessStatus dataAccessStatus = new DataAccessStatus();

        public IntegracaoBancariaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<IA001_AlegacaoPagador> GetA001_AlegacaoPagador()
        {
            _query = "SELECT * FROM A001_AlegacaoPagador";
            List<IA001_AlegacaoPagador> listModel = new List<IA001_AlegacaoPagador>();
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
                                IA001_AlegacaoPagador model = new A001_AlegacaoPagador()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Significado = reader["Significado"].ToString()
                                };
                                listModel.Add(model);
                                
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista do domínio de Alegação do Pagador (A001)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC004_CodigoMovimentacaoRemessa> GetC004_CodigoMOvimentacaoRemessa()
        {
            _query = "SELECT * FROM C004_CodigoMovimentacaoRemessa";
            List<IC004_CodigoMovimentacaoRemessa> listModel = new List<IC004_CodigoMovimentacaoRemessa>();
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
                                IC004_CodigoMovimentacaoRemessa model = new C004_CodigoMovimentacaoRemessa()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista do domínio de Código de Movimentação de Remessa (C004)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC006_CodigoCarteira> GetC006_CodigoCarteira()
        {
            _query = "SELECT * FROM C006_CodigoCarteira";
            List<IC006_CodigoCarteira> listModel = new List<IC006_CodigoCarteira>();
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
                                IC006_CodigoCarteira model = new C006_CodigoCarteira()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista do domínio de Código de Carteira (C006)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC007_FormaCadastramentoTitulo> GetC007_FormaCadastramentoTitulo()
        {
            _query = "SELECT * FROM C007_FormaCadastramentoTitulo";
            List<IC007_FormaCadastramentoTitulo> listModel = new List<IC007_FormaCadastramentoTitulo>();
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
                                IC007_FormaCadastramentoTitulo model = new C007_FormaCadastramentoTitulo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Forma de Cadastramento do Título (C007)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC008_TipoDocumento> GetC008_TipoDocumento()
        {
            _query = "SELECT * FROM C008_TipoDocumento";
            List<IC008_TipoDocumento> listModel = new List<IC008_TipoDocumento>();
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
                                IC008_TipoDocumento model = new C008_TipoDocumento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Código de Carteira (C008)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC009_IdentEmissaoBoletoPagamento> GetC009_IdentEmissaoBoletoPagamento()
        {
            _query = "SELECT * FROM C009_IdentEmissaoBoletoPagamento";
            List<IC009_IdentEmissaoBoletoPagamento> listModel = new List<IC009_IdentEmissaoBoletoPagamento>();
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
                                IC009_IdentEmissaoBoletoPagamento model = new C009_IdentEmissaoBoletoPagamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Identificação Emissão Boleto (C009)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC010_IdentDistribuicao> GetC010_IdentDistribuicao()
        {
            _query = "SELECT * FROM C010_IdentDistribuicao";
            List<IC010_IdentDistribuicao> listModel = new List<IC010_IdentDistribuicao>();
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
                                IC010_IdentDistribuicao model = new C010_IdentDistribuicao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Identificação de Distribuição (C010)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC015_EspecieTitulo> GetC015_EspecieTitulo()
        {
            _query = "SELECT * FROM C015_EspecieTitulo";
            List<IC015_EspecieTitulo> listModel = new List<IC015_EspecieTitulo>();
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
                                IC015_EspecieTitulo model = new C015_EspecieTitulo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Espécie de Título (C015)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC016_IdentTituloAceito> GetC016_IdentTituloAceito()
        {
            _query = "SELECT * FROM C016_IdentTituloAceito";
            List<IC016_IdentTituloAceito> listModel = new List<IC016_IdentTituloAceito>();
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
                                IC016_IdentTituloAceito model = new C016_IdentTituloAceito()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Identificação de Título de Aceito (C016)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC018_CodigoJurosMora> GetC018_CodigoJuro()
        {
            _query = "SELECT * FROM C018_CodigoJurosMora";
            List<IC018_CodigoJurosMora> listModel = new List<IC018_CodigoJurosMora>();
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
                                IC018_CodigoJurosMora model = new C018_CodigoJurosMora()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Cóidigo de Juros de Mora (C018)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC021_CodigoDesconto> GetC021_CodigoDesconto()
        {
            _query = "SELECT * FROM C021_CodigoDesconto";
            List<IC021_CodigoDesconto> listModel = new List<IC021_CodigoDesconto>();
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
                                IC021_CodigoDesconto model = new C021_CodigoDesconto()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Cóidigo de Desconto (C021)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC026_CodigoProtesto> GetC026_CodigoProtesto()
        {
            _query = "SELECT * FROM C026_CodigoProtesto";
            List<IC026_CodigoProtesto> listModel = new List<IC026_CodigoProtesto>();
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
                                IC026_CodigoProtesto model = new C026_CodigoProtesto()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Cóidigo de Desconto (C021)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC028_CodigoBaixaDevolucao> GetC028_CodigoBaixaDevolucao()
        {
            _query = "SELECT * FROM C028_CodigoBaixaDevolucao";
            List<IC028_CodigoBaixaDevolucao> listModel = new List<IC028_CodigoBaixaDevolucao>();
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
                                IC028_CodigoBaixaDevolucao model = new C028_CodigoBaixaDevolucao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista Código de Baixa e Devolução (C028)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC039_AvisoDebitoAutomatico> GetC039_AvisoDebitoAutomatico()
        {
            _query = "SELECT * FROM C039_AvisoDebitoAutomatico";
            List<IC039_AvisoDebitoAutomatico> listModel = new List<IC039_AvisoDebitoAutomatico>();
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
                                IC039_AvisoDebitoAutomatico model = new C039_AvisoDebitoAutomatico()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Aviso de Débito Automático (C039)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC044_CodigoMovimentoRetorno> GetC044_CodigoMovimentoRetorno()
        {
            _query = "SELECT * FROM C044_CodigoMovimentoRetorno";
            List<IC044_CodigoMovimentoRetorno> listModel = new List<IC044_CodigoMovimentoRetorno>();
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
                                IC044_CodigoMovimentoRetorno model = new C044_CodigoMovimentoRetorno()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Código de Movimento e Retorno (C044)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC047A_TipoMotivoOcorrencia> GetC047A_TipoMOtivoOcorrencia()
        {
            _query = "SELECT * FROM C047A_TipoMotivoOcorrencia";
            List<IC047A_TipoMotivoOcorrencia> listModel = new List<IC047A_TipoMotivoOcorrencia>();
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
                                IC047A_TipoMotivoOcorrencia model = new C047A_TipoMotivoOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = char.Parse(reader["Tipo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipo de Motivo de Ocorrências (C047A) ", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC047_MotivoOcorrencia> GetC047_MotivoOcorrencia()
        {
            _query = "SELECT * FROM C047_MotivoOcorrencia";
            List<IC047_MotivoOcorrencia> listModel = new List<IC047_MotivoOcorrencia>();
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
                                IC047_MotivoOcorrencia model = new C047_MotivoOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TipoId = int.Parse(reader["TipoId"].ToString()),
                                    LiquidacaoBaixa = char.Parse(reader["LiquidacaoBaixa"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Motivo Ocorrência (C047)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IC066_IdentiRejeicoes> GetC066_IdentiRejeicoe()
        {
            _query = "SELECT * FROM C066_IdentiRejeicoes";
            List<IC066_IdentiRejeicoes> listModel = new List<IC066_IdentiRejeicoes>();
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
                                IC066_IdentiRejeicoes model = new C066_IdentiRejeicoes()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Identificação de Rejições (C066)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<ID006_ComplTipoServico> GetD006_ComplTipoServico()
        {
            _query = "SELECT * FROM D006_ComplTipoServico";
            List<ID006_ComplTipoServico> listModel = new List<ID006_ComplTipoServico>();
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
                                ID006_ComplTipoServico model = new D006_ComplTipoServico()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Complemento de Tipos de Serviços (D006)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<ID007_AvisoPagador> GetD007_AvisoPagador()
        {
            _query = "SELECT * FROM D007_AvisoPagador";
            List<ID007_AvisoPagador> listModel = new List<ID007_AvisoPagador>();
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
                                ID007_AvisoPagador model = new D007_AvisoPagador()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Aviso ao Pagador (D007)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IF001_NaturezaSaldoConta> GetF001_NaturezaSaldoConta()
        {
            _query = "SELECT * FROM F001_NaturezaSaldoConta";
            List<IF001_NaturezaSaldoConta> listModel = new List<IF001_NaturezaSaldoConta>();
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
                                IF001_NaturezaSaldoConta model = new F001_NaturezaSaldoConta()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Natureza do Saldo da Conta (F001)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IF005_NaturezaSituacaoSaldoInicial> GetF005_NaturezaSituacaoSaldoInicial()
        {
            _query = "SELECT * FROM F005_NaturezaSituacaoSaldoInicial";
            List<IF005_NaturezaSituacaoSaldoInicial> listModel = new List<IF005_NaturezaSituacaoSaldoInicial>();
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
                                IF005_NaturezaSituacaoSaldoInicial model = new F005_NaturezaSituacaoSaldoInicial()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Natureza da Situação do Saldo Inicial (F005)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG003_TipoRegistro> GetG003_TipoRegistro()
        {
            _query = "SELECT * FROM G003_TipoRegistro";
            List<IG003_TipoRegistro> listModel = new List<IG003_TipoRegistro>();
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
                                IG003_TipoRegistro model = new G003_TipoRegistro()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipo de Registro (G003)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG005_TipoInscricao> GetG005_TipoInscricao()
        {
            _query = "SELECT * FROM G005_TipoInscricao";
            List<IG005_TipoInscricao> listModel = new List<IG005_TipoInscricao>();
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
                                IG005_TipoInscricao model = new G005_TipoInscricao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipo de Inscrição (G005)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG015_CodigoRemessaRetorno> GetG015_CodigoRemessaRetorno()
        {
            _query = "SELECT * FROM G015_CodigoRemessaRetorno";
            List<IG015_CodigoRemessaRetorno> listModel = new List<IG015_CodigoRemessaRetorno>();
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
                                IG015_CodigoRemessaRetorno model = new G015_CodigoRemessaRetorno()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Codigo de Remessa e Retorno (G015)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG020_DensidadeArquivo> GetG020_DensidadeArquivo()
        {
            _query = "SELECT * FROM G020_DensidadeArquivo";
            List<IG020_DensidadeArquivo> listModel = new List<IG020_DensidadeArquivo>();
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
                                IG020_DensidadeArquivo model = new G020_DensidadeArquivo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Densidades do Arquivo (G020)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG025_TipoServico> GetG025_TipoServico()
        {
            _query = "SELECT * FROM G025_TipoServico";
            List<IG025_TipoServico> listModel = new List<IG025_TipoServico>();
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
                                IG025_TipoServico model = new G025_TipoServico()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Serviços (G025)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG028_TipoOperacao> GetG028_TipoOperacao()
        {
            _query = "SELECT * FROM G028_TipoOperacao";
            List<IG028_TipoOperacao> listModel = new List<IG028_TipoOperacao>();
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
                                IG028_TipoOperacao model = new G028_TipoOperacao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Operações (G028)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG029_FormaLancamento> GetG029_FormaLancamento()
        {
            _query = "SELECT * FROM G029_FormaLancamento";
            List<IG029_FormaLancamento> listModel = new List<IG029_FormaLancamento>();
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
                                IG029_FormaLancamento model = new G029_FormaLancamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Formas de Lançamentos (G029)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG040_TipoMoeda> GetG040_TipoMoeda()
        {
            _query = "SELECT * FROM G040_TipoMoeda";
            List<IG040_TipoMoeda> listModel = new List<IG040_TipoMoeda>();
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
                                IG040_TipoMoeda model = new G040_TipoMoeda()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Moedas (G040)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG059_CodigoOcorrenciaRetornoRemessa> GetG059_CodigoOcorrenciaRetornoRemessa()
        {
            _query = "SELECT * G059_CodigoOcorrenciaRetornoRemessa";
            List<IG059_CodigoOcorrenciaRetornoRemessa> listModel = new List<IG059_CodigoOcorrenciaRetornoRemessa>();
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
                                IG059_CodigoOcorrenciaRetornoRemessa model = new G059_CodigoOcorrenciaRetornoRemessa()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Código de Ocorrências de Retorno/Remessa (G059)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG060_TipoMovimento> GetG060_TipoMovimento()
        {
            _query = "SELECT * G060_TipoMovimento";
            List<IG060_TipoMovimento> listModel = new List<IG060_TipoMovimento>();
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
                                IG060_TipoMovimento model = new G060_TipoMovimento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Tipos de Movimentos (G060)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG061_CodigoInstrucaoMovimento> GetG061_CodigoInstrucaoMovimento()
        {
            _query = "SELECT * G061_CodigoInstrucaoMovimento";
            List<IG061_CodigoInstrucaoMovimento> listModel = new List<IG061_CodigoInstrucaoMovimento>();
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
                                IG061_CodigoInstrucaoMovimento model = new G061_CodigoInstrucaoMovimento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Códigos de Intrução de Movimento (G061)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG062_CodigoPadraoOcorrenciasPagador> GetG062_CodigoPadraoOcorrencia()
        {
            _query = "SELECT * G062_CodigoPadraoOcorrenciasPagador";
            List<IG062_CodigoPadraoOcorrenciasPagador> listModel = new List<IG062_CodigoPadraoOcorrenciasPagador>();
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
                                IG062_CodigoPadraoOcorrenciasPagador model = new G062_CodigoPadraoOcorrenciasPagador()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Códigos Padrões de Ocorrências para o Pagador (G062)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG065_CodigoMoeda> GetG065_CodigoMoeda()
        {
            _query = "SELECT * G065_CodigoMoeda";
            List<IG065_CodigoMoeda> listModel = new List<IG065_CodigoMoeda>();
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
                                IG065_CodigoMoeda model = new G065_CodigoMoeda()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Código Model (G065)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG067_IdentRegistroOpcional> GetG067_IOdentRegistroOpcional()
        {
            _query = "SELECT * G067_IdentRegistroOpcional";
            List<IG067_IdentRegistroOpcional> listModel = new List<IG067_IdentRegistroOpcional>();
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
                                IG067_IdentRegistroOpcional model = new G067_IdentRegistroOpcional()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de Identificação de Registros Opcionais (G067)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG073_CodigoMulta> GetG073_CodigoMulta()
        {
            _query = "SELECT * G073_CodigoMulta";
            List<IG073_CodigoMulta> listModel = new List<IG073_CodigoMulta>();
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
                                IG073_CodigoMulta model = new G073_CodigoMulta()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Codigo de Multa (G073)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG081_SituacaoSaldoInicial> GetG081_SituacaoSaldoInicial()
        {
            _query = "SELECT * G081_SituacaoSaldoInicial";
            List<IG081_SituacaoSaldoInicial> listModel = new List<IG081_SituacaoSaldoInicial>();
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
                                IG081_SituacaoSaldoInicial model = new G081_SituacaoSaldoInicial()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Situação do Saldo Inicial (G081)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel; ;
        }

        public IEnumerable<IG082_PosicaoSaldoInicial> GetG082_PosicaoSaldoInicial()
        {
            _query = "SELECT * G082_PosicaoSaldoInicial";
            List<IG082_PosicaoSaldoInicial> listModel = new List<IG082_PosicaoSaldoInicial>();
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
                                IG082_PosicaoSaldoInicial model = new G082_PosicaoSaldoInicial()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Posições de Saldo Inicial (G082)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG084_NaturezaLancamento> GetG084_NaturezaLancamento()
        {
            _query = "SELECT * G084_NaturezaLancamento";
            List<IG084_NaturezaLancamento> listModel = new List<IG084_NaturezaLancamento>();
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
                                IG084_NaturezaLancamento model = new G084_NaturezaLancamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Natureza de Lançamento (G084)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG085_TipoComplementoLancamento> GetG085_TipoComplementoLancamento()
        {
            _query = "SELECT * G085_TipoComplementoLancamento";
            List<IG085_TipoComplementoLancamento> listModel = new List<IG085_TipoComplementoLancamento>();
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
                                IG085_TipoComplementoLancamento model = new G085_TipoComplementoLancamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Complementos de Lançamentos (G085)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG087_IdentIsencaoCPMF> GetG087_IdentIsencaoCPMF()
        {
            _query = "SELECT * G087_IdentIsencaoCPMF";
            List<IG087_IdentIsencaoCPMF> listModel = new List<IG087_IdentIsencaoCPMF>();
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
                                IG087_IdentIsencaoCPMF model = new G087_IdentIsencaoCPMF()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Identificação de Isenção do CPMF (G087)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG091_TipoLancamento> GetG091_TipoLancamento()
        {
            _query = "SELECT * G091_TipoLancamento";
            List<IG091_TipoLancamento> listModel = new List<IG091_TipoLancamento>();
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
                                IG091_TipoLancamento model = new G091_TipoLancamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Lançmentos (G091)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG092_CategoriaLancamento> GetG092_CategoriaLancamento()
        {
            _query = "SELECT * G092_CategoriaLancamento";
            List<IG092_CategoriaLancamento> listModel = new List<IG092_CategoriaLancamento>();
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
                                IG092_CategoriaLancamento model = new G092_CategoriaLancamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TipoId = int.Parse(reader["TipoId"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "CAtegorias de Lançamentos (G092)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG098_SituacaoSaldoFinal> GetG098_SituacaoSaldoFinal()
        {
            _query = "SELECT * G098_SituacaoSaldoFinal";
            List<IG098_SituacaoSaldoFinal> listModel = new List<IG098_SituacaoSaldoFinal>();
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
                                IG098_SituacaoSaldoFinal model = new G098_SituacaoSaldoFinal()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "~Situações de Saldo Final (G098)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG099_PosicaoSaldoFinal> GetG099_PosicaoSaldoFinal()
        {
            _query = "SELECT * G099_PosicaoSaldoFinal";
            List<IG099_PosicaoSaldoFinal> listModel = new List<IG099_PosicaoSaldoFinal>();
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
                                IG099_PosicaoSaldoFinal model = new G099_PosicaoSaldoFinal()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),        
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Posições de Saldo Final (G099)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG100_FormaIniciacaoPix> GetG100_FormaIniciacaoPix()
        {
            _query = "SELECT * G100_FormaIniciacaoPix";
            List<IG100_FormaIniciacaoPix> listModel = new List<IG100_FormaIniciacaoPix>();
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
                                IG100_FormaIniciacaoPix model = new G100_FormaIniciacaoPix()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),              
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Inicialização do Pix (G100)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IG103_TipoChaveDICT> GetG103_TipoChaveDICT()
        {
            _query = "SELECT * G103_TipoChaveDICT";
            List<IG103_TipoChaveDICT> listModel = new List<IG103_TipoChaveDICT>();
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
                                IG103_TipoChaveDICT model = new G103_TipoChaveDICT()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),       
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Chave DICT (G103)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH008_StatusMutuario> GetH008_StatusMutuario()
        {
            _query = "SELECT * H008_StatusMutuario";
            List<IH008_StatusMutuario> listModel = new List<IH008_StatusMutuario>();
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
                                IH008_StatusMutuario model = new H008_StatusMutuario()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),        
                                    Codigo = int.Parse( reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Status do Mutuário (H008)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH009_RegimeContratoMutuario> GetH009_RegimeContratoMutuario()
        {
            _query = "SELECT * H009_RegimeContratoMutuario";
            List<IH009_RegimeContratoMutuario> listModel = new List<IH009_RegimeContratoMutuario>();
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
                                IH009_RegimeContratoMutuario model = new H009_RegimeContratoMutuario()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Regimes de Contrato para Mutuário (H009)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH010_SituacaoSindicalMutuario> GetH010_SituacaoSindicalMutuario()
        {
            _query = "SELECT * H010_SituacaoSindicalMutuario";
            List<IH010_SituacaoSindicalMutuario> listModel = new List<IH010_SituacaoSindicalMutuario>();
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
                                IH010_SituacaoSindicalMutuario model = new H010_SituacaoSindicalMutuario()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Situações Sindicais de Mutuários (H010)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH011_ComprometimentoVerbaRescisoria> GetH011_ComprometimentoVerbaRescisoria()
        {
            _query = "SELECT * H011_ComprometimentoVerbaRescisoria";
            List<IH011_ComprometimentoVerbaRescisoria> listModel = new List<IH011_ComprometimentoVerbaRescisoria>();
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
                                IH011_ComprometimentoVerbaRescisoria model = new H011_ComprometimentoVerbaRescisoria()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),   
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Comprometimentos de Verba Recisória (H011)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH014_IdentCentralSindical> GetH014_IdentCentralSindical()
        {
            _query = "SELECT * H014_IdentCentralSindical";
            List<IH014_IdentCentralSindical> listModel = new List<IH014_IdentCentralSindical>();
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
                                IH014_IdentCentralSindical model = new H014_IdentCentralSindical()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Identificações de Centrais Sindicais (H014)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH015_TipoOperacao> GetH015_TipoOperacao()
        {
            _query = "SELECT * H015_TipoOperacao";
            List<IH015_TipoOperacao> listModel = new List<IH015_TipoOperacao>();
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
                                IH015_TipoOperacao model = new H015_TipoOperacao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),    
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Operações (H015)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IH031_TipoResidualGarantido> GetH031_TipoResidualGarantido()
        {
            _query = "SELECT * H031_TipoResidualGarantido";
            List<IH031_TipoResidualGarantido> listModel = new List<IH031_TipoResidualGarantido>();
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
                                IH031_TipoResidualGarantido model = new H031_TipoResidualGarantido()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                      
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos Residuais Garantido (H031)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II004_RegimeEncargosFinanceiros> GetI004_RegimeEncargo()
        {
            _query = "SELECT * I004_RegimeEncargosFinanceiros";
            List<II004_RegimeEncargosFinanceiros> listModel = new List<II004_RegimeEncargosFinanceiros>();
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
                                II004_RegimeEncargosFinanceiros model = new I004_RegimeEncargosFinanceiros()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Regimes de Encargos Financeiros (I004)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II005_ModalidadeEncargosFinanceirosPos> GetI005_ModalidadeEncargo()
        {
            _query = "SELECT * I005_ModalidadeEncargosFinanceirosPos";
            List<II005_ModalidadeEncargosFinanceirosPos> listModel = new List<II005_ModalidadeEncargosFinanceirosPos>();
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
                                II005_ModalidadeEncargosFinanceirosPos model = new I005_ModalidadeEncargosFinanceirosPos()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Modalidades de Encargos Financerios (I005)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II007_FormaReposicao> GetI007_FormaReposicao()
        {
            _query = "SELECT * I007_FormaReposicao";
            List<II007_FormaReposicao> listModel = new List<II007_FormaReposicao>();
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
                                II007_FormaReposicao model = new I007_FormaReposicao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse( reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Reposição (I007)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II008_MetodologiaCalculoEncargos> GetI008_MetodologiaCalculoEncargo()
        {
            _query = "SELECT * I008_MetodologiaCalculoEncargos";
            List<II008_MetodologiaCalculoEncargos> listModel = new List<II008_MetodologiaCalculoEncargos>();
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
                                II008_MetodologiaCalculoEncargos model = new I008_MetodologiaCalculoEncargos()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Metodolgias de Cálculos dos Encargos (I008)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II011_TipoVencimentoParcelas> GetI011_TipoVencimentoParcela()
        {
            _query = "SELECT * I011_TipoVencimentoParcelas";
            List<II011_TipoVencimentoParcelas> listModel = new List<II011_TipoVencimentoParcelas>();
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
                                II011_TipoVencimentoParcelas model = new I011_TipoVencimentoParcelas()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString(),
                                    Detalhe = reader["Detalhe"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Vencimentos de Parcelas (I011)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II015_FormaPagamento> GetI015_FormaPagamento()
        {
            _query = "SELECT * I015_FormaPagamento";
            List<II015_FormaPagamento> listModel = new List<II015_FormaPagamento>();
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
                                II015_FormaPagamento model = new I015_FormaPagamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),        
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Pagamento (I015)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<II017_FormaPagamentoIOF> GetI017_FormaPagamentoIOF()
        {
            _query = "SELECT * I017_FormaPagamentoIOF";
            List<II017_FormaPagamentoIOF> listModel = new List<II017_FormaPagamentoIOF>();
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
                                II017_FormaPagamentoIOF model = new I017_FormaPagamentoIOF()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),              
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Pagamento de IOF (I017)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK001_CodigosOcorrencia> GetK001_Codigo()
        {
            _query = "SELECT * K001_CodigosOcorrencia";
            List<IK001_CodigosOcorrencia> listModel = new List<IK001_CodigosOcorrencia>();
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
                                IK001_CodigosOcorrencia model = new K001_CodigosOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),              
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Codigos de Ocorrências (K001)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK002A_CategoriaTipoMovimento> GetK002A_CategoriaTipoMovimento()
        {
            _query = "SELECT * K002A_CategoriaTipoMovimento";
            List<IK002A_CategoriaTipoMovimento> listModel = new List<IK002A_CategoriaTipoMovimento>();
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
                                IK002A_CategoriaTipoMovimento model = new K002A_CategoriaTipoMovimento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                          
                                    Categoria = reader["Categoria"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Categorias de tipos de Movimento (K002A)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK002_TipoMovimento> GetK002_TipoMovimento()
        {
            _query = "SELECT * K002_TipoMovimento";
            List<IK002_TipoMovimento> listModel = new List<IK002_TipoMovimento>();
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
                                IK002_TipoMovimento model = new K002_TipoMovimento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    CategoriaId = int.Parse(reader["CategoriaId"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Movimento (K002)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK003_CodigoFinalidadeMovimento> GetK003_CodigoFinalidadeMovimento()
        {
            _query = "SELECT * K003_CodigoFinalidadeMovimento";
            List<IK003_CodigoFinalidadeMovimento> listModel = new List<IK003_CodigoFinalidadeMovimento>();
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
                                IK003_CodigoFinalidadeMovimento model = new K003_CodigoFinalidadeMovimento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),       
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Finalidade de Movimento (K003)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK004_FormaEntradaDadosCheque> GetK004_FormaEsntradaDado()
        {
            _query = "SELECT * K004_FormaEntradaDadosCheque";
            List<IK004_FormaEntradaDadosCheque> listModel = new List<IK004_FormaEntradaDadosCheque>();
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
                                IK004_FormaEntradaDadosCheque model = new K004_FormaEntradaDadosCheque()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString(),
                                    Complemento = reader["Complemento"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Entradas de Dados dos Cheques (K004)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK006_TipoInscricaoEmitente> GetK006_TipoInscricaoEmitente()
        {
            _query = "SELECT * K006_TipoInscricaoEmitente";
            List<IK006_TipoInscricaoEmitente> listModel = new List<IK006_TipoInscricaoEmitente>();
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
                                IK006_TipoInscricaoEmitente model = new K006_TipoInscricaoEmitente()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                      
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Sincrições do Emitente (K006)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IK020_CodigoOcorrencia> GetK020_CodigoOcorrencia()
        {
            _query = "SELECT * K020_CodigoOcorrencia";
            List<IK020_CodigoOcorrencia> listModel = new List<IK020_CodigoOcorrencia>();
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
                                IK020_CodigoOcorrencia model = new K020_CodigoOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),            
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Ocorrências (K020)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN003_TipoIdentificacaoContribuinte> GetN003_TipoIdentificacaoContribuinte()
        {
            _query = "SELECT * N003_TipoIdentificacaoContribuinte";
            List<IN003_TipoIdentificacaoContribuinte> listModel = new List<IN003_TipoIdentificacaoContribuinte>();
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
                                IN003_TipoIdentificacaoContribuinte model = new N003_TipoIdentificacaoContribuinte()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Identificações do Contribuinte (N003)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN005A_TipoTributo> GetN005A_TipoTributo()
        {
            _query = "SELECT * N005A_TipoTributo";
            List<IN005A_TipoTributo> listModel = new List<IN005A_TipoTributo>();
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
                                IN005A_TipoTributo model = new N005A_TipoTributo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Tipo = reader["Tipo"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Tributos (N005A)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN005_CodigoIdentificacaoTributo> GetN005_CodigoIdentificacaoTributo()
        {
            _query = "SELECT * N005_CodigoIdentificacaoTributo";
            List<IN005_CodigoIdentificacaoTributo> listModel = new List<IN005_CodigoIdentificacaoTributo>();
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
                                IN005_CodigoIdentificacaoTributo model = new N005_CodigoIdentificacaoTributo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TipoId = int.Parse(reader["TipoId"].ToString()),
                                    Codigo = reader["Codigo"].ToString(), 
                                    Desricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Codigos de Identificações de Tributos (N005)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN019_OpcaoPagamento> GetN019_OpcaoPagamento()
        {
            _query = "SELECT * N019_OpcaoPagamento";
            List<IN019_OpcaoPagamento> listModel = new List<IN019_OpcaoPagamento>();
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
                                IN019_OpcaoPagamento model = new N019_OpcaoPagamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Opcões de Pagamentos (N019)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN020_OpcaoRetiradaCRVL> GetN020_OpcaoRetiradaCRVL()
        {
            _query = "SELECT * N020_OpcaoRetiradaCRVL";
            List<IN020_OpcaoRetiradaCRVL> listModel = new List<IN020_OpcaoRetiradaCRVL>();
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
                                IN020_OpcaoRetiradaCRVL model = new N020_OpcaoRetiradaCRVL()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Opções de Retirada CRVL (N020)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IN027_IdentificadorTributo> GetN027_IdentificadorTributo()
        {
            _query = "SELECT * N027_IdentificadorTributo";
            List<IN027_IdentificadorTributo> listModel = new List<IN027_IdentificadorTributo>();
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
                                IN027_IdentificadorTributo model = new N027_IdentificadorTributo()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Identificadores de Tributo (N027)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IP001_CodigoCamaraCentralizadora> GetP001_CodigoCamaraCentralizadora()
        {
            _query = "SELECT * P001_CodigoCamaraCentralizadora";
            List<IP001_CodigoCamaraCentralizadora> listModel = new List<IP001_CodigoCamaraCentralizadora>();
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
                                IP001_CodigoCamaraCentralizadora model = new P001_CodigoCamaraCentralizadora()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                                
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Camara Centralizadora (P001)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IP006_AvisoFavorecido> GetP006_AvisoFavorecido()
        {
            _query = "SELECT * P006_AvisoFavorecido";
            List<IP006_AvisoFavorecido> listModel = new List<IP006_AvisoFavorecido>();
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
                                IP006_AvisoFavorecido model = new P006_AvisoFavorecido()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),          
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Avisos ao Favorecido (P006)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IP014_IndicativoFormaPagamento> GetP014_IndicativoFormaPagamento()
        {
            _query = "SELECT * P014_IndicativoFormaPagamento";
            List<IP014_IndicativoFormaPagamento> listModel = new List<IP014_IndicativoFormaPagamento>();
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
                                IP014_IndicativoFormaPagamento model = new P014_IndicativoFormaPagamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                            
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Indicativos de Formas de Pagamento (P014)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV002_CodigoMovimentoRemessa> GetV002_CodigoMovimentoRemessa()
        {
            _query = "SELECT * V002_CodigoMovimentoRemessa";
            List<IV002_CodigoMovimentoRemessa> listModel = new List<IV002_CodigoMovimentoRemessa>();
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
                                IV002_CodigoMovimentoRemessa model = new V002_CodigoMovimentoRemessa()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                        
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Movimento de Remessa (V002)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV003_CodigoMovimentoRetorno> GetV003_CodigoMovimentoRetorno()
        {
            _query = "SELECT * V003_CodigoMovimentoRetorno";
            List<IV003_CodigoMovimentoRetorno> listModel = new List<IV003_CodigoMovimentoRetorno>();
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
                                IV003_CodigoMovimentoRetorno model = new V003_CodigoMovimentoRetorno()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                        
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Movimento Retorno (V003)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV005_FormaPagamento> GetV005_FormaPagamento()
        {
            _query = "SELECT * V005_FormaPagamento";
            List<IV005_FormaPagamento> listModel = new List<IV005_FormaPagamento>();
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
                                IV005_FormaPagamento model = new V005_FormaPagamento()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),       
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Pagamentos (V005)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV009_TipoVencimentoParcelas> GetV009_TipoVencimentoParcela()
        {
            _query = "SELECT * V009_TipoVencimentoParcelas";
            List<IV009_TipoVencimentoParcelas> listModel = new List<IV009_TipoVencimentoParcelas>();
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
                                IV009_TipoVencimentoParcelas model = new V009_TipoVencimentoParcelas()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Vencimentos das Parcelas (V009)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV010A_TipoMotivoOcorrencia> GetV010A_TipoMotivoOcorrencia()
        {
            _query = "SELECT * V010A_TipoMotivoOcorrencia";
            List<IV010A_TipoMotivoOcorrencia> listModel = new List<IV010A_TipoMotivoOcorrencia>();
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
                                IV010A_TipoMotivoOcorrencia model = new V010A_TipoMotivoOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Motivos de Ocorrência (V010A)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV010_MotivoOcorrencia> GetV010_MotivoOcorrencia()
        {
            _query = "SELECT * V010_MotivoOcorrencia";
            List<IV010_MotivoOcorrencia> listModel = new List<IV010_MotivoOcorrencia>();
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
                                IV010_MotivoOcorrencia model = new V010_MotivoOcorrencia()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    TipoId = int.Parse(reader["TipoId"].ToString()),
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString(),
                                    LiquidacaoBaixa = char.Parse(reader["LiquidacaoBaixa"].ToString())
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Motivos de Ocorrências (V010)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV020_FormaPagamentoIOF> GetV020_FormaPagamentoIOF()
        {
            _query = "SELECT * V020_FormaPagamentoIOF";
            List<IV020_FormaPagamentoIOF> listModel = new List<IV020_FormaPagamentoIOF>();
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
                                IV020_FormaPagamentoIOF model = new V020_FormaPagamentoIOF()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),              
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Formas de Pagamentos do IOF (V020)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV021_TipoEqualizacao> GetV021_TipoEqualizacao()
        {
            _query = "SELECT * V021_TipoEqualizacao";
            List<IV021_TipoEqualizacao> listModel = new List<IV021_TipoEqualizacao>();
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
                                IV021_TipoEqualizacao model = new V021_TipoEqualizacao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),          
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Equalização (V021)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV022_ModalidadeEqualizacao> GetV022_ModalidadeEqualizacao()
        {
            _query = "SELECT * V022_ModalidadeEqualizacao";
            List<IV022_ModalidadeEqualizacao> listModel = new List<IV022_ModalidadeEqualizacao>();
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
                                IV022_ModalidadeEqualizacao model = new V022_ModalidadeEqualizacao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                      
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Modalidades de Equalizações (V022)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV032_CodigoMoedaVendedor> GetV032_CodigoMoedaVendedor()
        {
            _query = "SELECT * V032_CodigoMoedaVendedor";
            List<IV032_CodigoMoedaVendedor> listModel = new List<IV032_CodigoMoedaVendedor>();
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
                                IV032_CodigoMoedaVendedor model = new V032_CodigoMoedaVendedor()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),                  
                                    Codigo = reader["Codigo"].ToString(),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Moeda Vendor (V032)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV040_CodigoDesconto> GetV040_CodigoDesconto()
        {
            _query = "SELECT * V040_CodigoDesconto";
            List<IV040_CodigoDesconto> listModel = new List<IV040_CodigoDesconto>();
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
                                IV040_CodigoDesconto model = new V040_CodigoDesconto()
                                {
                                    Id = int.Parse(reader["Id"].ToString()), 
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Desconto (V040)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV042_CodigoProtesto> GetV042_CodigoProtesto()
        {
            _query = "SELECT * V042_CodigoProtesto";
            List<IV042_CodigoProtesto> listModel = new List<IV042_CodigoProtesto>();
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
                                IV042_CodigoProtesto model = new V042_CodigoProtesto()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),        
                                    Codigo = int.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Códigos de Protesto (V042)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }

        public IEnumerable<IV047_TipoLancamentoValorEqualizacao> GetV047_TipoLancamentoValorEqualizacao()
        {
            _query = "SELECT * V047_TipoLancamentoValorEqualizacao";
            List<IV047_TipoLancamentoValorEqualizacao> listModel = new List<IV047_TipoLancamentoValorEqualizacao>();
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
                                IV047_TipoLancamentoValorEqualizacao model = new V047_TipoLancamentoValorEqualizacao()
                                {
                                    Id = int.Parse(reader["Id"].ToString()),
                                    Codigo = char.Parse(reader["Codigo"].ToString()),
                                    Descricao = reader["Descricao"].ToString()
                                };
                                listModel.Add(model);

                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível recuperar a lista de " +
                        "Tipos de Lançamento de Valores de Equalização (V047)", e.HelpLink, e.ErrorCode, e.StackTrace);
                    throw new DataAccessException(e.Message, e.InnerException, dataAccessStatus);
                }
                finally
                {
                    connection.Close();
                }
            }
            return listModel;
        }
    }
}
