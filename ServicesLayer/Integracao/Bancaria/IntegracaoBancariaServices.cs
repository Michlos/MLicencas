using DomainLayer.Financeiro.Integracoes.Bancaria;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Integracao.Bancaria
{
    public class IntegracaoBancariaServices : IIntegracaoBancariaRepository
    {
        private IIntegracaoBancariaRepository _integracaoBancariaRepository;

        public IntegracaoBancariaServices(IIntegracaoBancariaRepository integracaoBancariaRepository)
        {
            _integracaoBancariaRepository = integracaoBancariaRepository;
        }

        public IEnumerable<IA001_AlegacaoPagador> GetA001_AlegacaoPagador()
        {
            return _integracaoBancariaRepository.GetA001_AlegacaoPagador();
        }

        public IEnumerable<IC004_CodigoMovimentacaoRemessa> GetC004_CodigoMOvimentacaoRemessa()
        {
            return _integracaoBancariaRepository.GetC004_CodigoMOvimentacaoRemessa();
        }

        public IEnumerable<IC006_CodigoCarteira> GetC006_CodigoCarteira()
        {
            return _integracaoBancariaRepository.GetC006_CodigoCarteira();
        }

        public IEnumerable<IC007_FormaCadastramentoTitulo> GetC007_FormaCadastramentoTitulo()
        {
            return _integracaoBancariaRepository.GetC007_FormaCadastramentoTitulo();
        }

        public IEnumerable<IC008_TipoDocumento> GetC008_TipoDocumento()
        {
            return _integracaoBancariaRepository.GetC008_TipoDocumento();
        }

        public IEnumerable<IC009_IdentEmissaoBoletoPagamento> GetC009_IdentEmissaoBoletoPagamento()
        {
            return _integracaoBancariaRepository.GetC009_IdentEmissaoBoletoPagamento();
        }

        public IEnumerable<IC010_IdentDistribuicao> GetC010_IdentDistribuicao()
        {
            return _integracaoBancariaRepository.GetC010_IdentDistribuicao();
        }

        public IEnumerable<IC015_EspecieTitulo> GetC015_EspecieTitulo()
        {
            return _integracaoBancariaRepository.GetC015_EspecieTitulo();
        }

        public IEnumerable<IC016_IdentTituloAceito> GetC016_IdentTituloAceito()
        {
            return _integracaoBancariaRepository.GetC016_IdentTituloAceito();
        }

        public IEnumerable<IC018_CodigoJurosMora> GetC018_CodigoJuro()
        {
            return _integracaoBancariaRepository.GetC018_CodigoJuro();
        }

        public IEnumerable<IC021_CodigoDesconto> GetC021_CodigoDesconto()
        {
            return _integracaoBancariaRepository.GetC021_CodigoDesconto();
        }

        public IEnumerable<IC026_CodigoProtesto> GetC026_CodigoProtesto()
        {
            return _integracaoBancariaRepository.GetC026_CodigoProtesto();
        }

        public IEnumerable<IC028_CodigoBaixaDevolucao> GetC028_CodigoBaixaDevolucao()
        {
            return _integracaoBancariaRepository.GetC028_CodigoBaixaDevolucao();
        }

        public IEnumerable<IC039_AvisoDebitoAutomatico> GetC039_AvisoDebitoAutomatico()
        {
            return _integracaoBancariaRepository.GetC039_AvisoDebitoAutomatico();
        }

        public IEnumerable<IC044_CodigoMovimentoRetorno> GetC044_CodigoMovimentoRetorno()
        {
            return _integracaoBancariaRepository.GetC044_CodigoMovimentoRetorno();
        }

        public IEnumerable<IC047A_TipoMotivoOcorrencia> GetC047A_TipoMOtivoOcorrencia()
        {
            return _integracaoBancariaRepository.GetC047A_TipoMOtivoOcorrencia();
        }

        public IEnumerable<IC047_MotivoOcorrencia> GetC047_MotivoOcorrencia()
        {
            return _integracaoBancariaRepository.GetC047_MotivoOcorrencia();
        }

        public IEnumerable<IC066_IdentiRejeicoes> GetC066_IdentiRejeicoe()
        {
            return _integracaoBancariaRepository.GetC066_IdentiRejeicoe();
        }

        public IEnumerable<ID006_ComplTipoServico> GetD006_ComplTipoServico()
        {
            return _integracaoBancariaRepository.GetD006_ComplTipoServico();
        }

        public IEnumerable<ID007_AvisoPagador> GetD007_AvisoPagador()
        {
            return _integracaoBancariaRepository.GetD007_AvisoPagador();
        }

        public IEnumerable<IF001_NaturezaSaldoConta> GetF001_NaturezaSaldoConta()
        {
            return _integracaoBancariaRepository.GetF001_NaturezaSaldoConta();
        }

        public IEnumerable<IF005_NaturezaSituacaoSaldoInicial> GetF005_NaturezaSituacaoSaldoInicial()
        {
            return _integracaoBancariaRepository.GetF005_NaturezaSituacaoSaldoInicial();
        }

        public IEnumerable<IG003_TipoRegistro> GetG003_TipoRegistro()
        {
            return _integracaoBancariaRepository.GetG003_TipoRegistro();
        }

        public IEnumerable<IG005_TipoInscricao> GetG005_TipoInscricao()
        {
            return _integracaoBancariaRepository.GetG005_TipoInscricao();
        }

        public IEnumerable<IG015_CodigoRemessaRetorno> GetG015_CodigoRemessaRetorno()
        {
            return _integracaoBancariaRepository.GetG015_CodigoRemessaRetorno();
        }

        public IEnumerable<IG020_DensidadeArquivo> GetG020_DensidadeArquivo()
        {
            return _integracaoBancariaRepository.GetG020_DensidadeArquivo();
        }

        public IEnumerable<IG025_TipoServico> GetG025_TipoServico()
        {
            return _integracaoBancariaRepository.GetG025_TipoServico();
        }

        public IEnumerable<IG028_TipoOperacao> GetG028_TipoOperacao()
        {
            return _integracaoBancariaRepository.GetG028_TipoOperacao();
        }

        public IEnumerable<IG029_FormaLancamento> GetG029_FormaLancamento()
        {
            return _integracaoBancariaRepository.GetG029_FormaLancamento();
        }

        public IEnumerable<IG040_TipoMoeda> GetG040_TipoMoeda()
        {
            return _integracaoBancariaRepository.GetG040_TipoMoeda();
        }

        public IEnumerable<IG059_CodigoOcorrenciaRetornoRemessa> GetG059_CodigoOcorrenciaRetornoRemessa()
        {
            return _integracaoBancariaRepository.GetG059_CodigoOcorrenciaRetornoRemessa();
        }

        public IEnumerable<IG060_TipoMovimento> GetG060_TipoMovimento()
        {
            return _integracaoBancariaRepository.GetG060_TipoMovimento();
        }

        public IEnumerable<IG061_CodigoInstrucaoMovimento> GetG061_CodigoInstrucaoMovimento()
        {
            return _integracaoBancariaRepository.GetG061_CodigoInstrucaoMovimento();
        }

        public IEnumerable<IG062_CodigoPadraoOcorrenciasPagador> GetG062_CodigoPadraoOcorrencia()
        {
            return _integracaoBancariaRepository.GetG062_CodigoPadraoOcorrencia();
        }

        public IEnumerable<IG065_CodigoMoeda> GetG065_CodigoMoeda()
        {
            return _integracaoBancariaRepository.GetG065_CodigoMoeda();
        }

        public IEnumerable<IG067_IdentRegistroOpcional> GetG067_IOdentRegistroOpcional()
        {
            return _integracaoBancariaRepository.GetG067_IOdentRegistroOpcional();
        }

        public IEnumerable<IG073_CodigoMulta> GetG073_CodigoMulta()
        {
            return _integracaoBancariaRepository.GetG073_CodigoMulta();
        }

        public IEnumerable<IG081_SituacaoSaldoInicial> GetG081_SituacaoSaldoInicial()
        {
            return _integracaoBancariaRepository.GetG081_SituacaoSaldoInicial();
        }

        public IEnumerable<IG082_PosicaoSaldoInicial> GetG082_PosicaoSaldoInicial()
        {
            return _integracaoBancariaRepository.GetG082_PosicaoSaldoInicial();
        }

        public IEnumerable<IG084_NaturezaLancamento> GetG084_NaturezaLancamento()
        {
            return _integracaoBancariaRepository.GetG084_NaturezaLancamento();
        }

        public IEnumerable<IG085_TipoComplementoLancamento> GetG085_TipoComplementoLancamento()
        {
            return _integracaoBancariaRepository.GetG085_TipoComplementoLancamento();
        }

        public IEnumerable<IG087_IdentIsencaoCPMF> GetG087_IdentIsencaoCPMF()
        {
            return _integracaoBancariaRepository.GetG087_IdentIsencaoCPMF();
        }

        public IEnumerable<IG091_TipoLancamento> GetG091_TipoLancamento()
        {
            return _integracaoBancariaRepository.GetG091_TipoLancamento();
        }

        public IEnumerable<IG092_CategoriaLancamento> GetG092_CategoriaLancamento()
        {
            return _integracaoBancariaRepository.GetG092_CategoriaLancamento();
        }

        public IEnumerable<IG098_SituacaoSaldoFinal> GetG098_SituacaoSaldoFinal()
        {
            return _integracaoBancariaRepository.GetG098_SituacaoSaldoFinal();
        }

        public IEnumerable<IG099_PosicaoSaldoFinal> GetG099_PosicaoSaldoFinal()
        {
            return _integracaoBancariaRepository.GetG099_PosicaoSaldoFinal();
        }

        public IEnumerable<IG100_FormaIniciacaoPix> GetG100_FormaIniciacaoPix()
        {
            return _integracaoBancariaRepository.GetG100_FormaIniciacaoPix();
        }

        public IEnumerable<IG103_TipoChaveDICT> GetG103_TipoChaveDICT()
        {
            return _integracaoBancariaRepository.GetG103_TipoChaveDICT();
        }

        public IEnumerable<IH008_StatusMutuario> GetH008_StatusMutuario()
        {
            return _integracaoBancariaRepository.GetH008_StatusMutuario();
        }

        public IEnumerable<IH009_RegimeContratoMutuario> GetH009_RegimeContratoMutuario()
        {
            return _integracaoBancariaRepository.GetH009_RegimeContratoMutuario();
        }

        public IEnumerable<IH010_SituacaoSindicalMutuario> GetH010_SituacaoSindicalMutuario()
        {
            return _integracaoBancariaRepository.GetH010_SituacaoSindicalMutuario();
        }

        public IEnumerable<IH011_ComprometimentoVerbaRescisoria> GetH011_ComprometimentoVerbaRescisoria()
        {
            return _integracaoBancariaRepository.GetH011_ComprometimentoVerbaRescisoria();
        }

        public IEnumerable<IH014_IdentCentralSindical> GetH014_IdentCentralSindical()
        {
            return _integracaoBancariaRepository.GetH014_IdentCentralSindical();
        }

        public IEnumerable<IH015_TipoOperacao> GetH015_TipoOperacao()
        {
            return _integracaoBancariaRepository.GetH015_TipoOperacao();
        }

        public IEnumerable<IH031_TipoResidualGarantido> GetH031_TipoResidualGarantido()
        {
            return _integracaoBancariaRepository.GetH031_TipoResidualGarantido();
        }

        public IEnumerable<II004_RegimeEncargosFinanceiros> GetI004_RegimeEncargo()
        {
            return _integracaoBancariaRepository.GetI004_RegimeEncargo();
        }

        public IEnumerable<II005_ModalidadeEncargosFinanceirosPos> GetI005_ModalidadeEncargo()
        {
            return _integracaoBancariaRepository.GetI005_ModalidadeEncargo();
        }

        public IEnumerable<II007_FormaReposicao> GetI007_FormaReposicao()
        {
            return _integracaoBancariaRepository.GetI007_FormaReposicao();
        }

        public IEnumerable<II008_MetodologiaCalculoEncargos> GetI008_MetodologiaCalculoEncargo()
        {
            return _integracaoBancariaRepository.GetI008_MetodologiaCalculoEncargo();
        }

        public IEnumerable<II011_TipoVencimentoParcelas> GetI011_TipoVencimentoParcela()
        {
            return _integracaoBancariaRepository.GetI011_TipoVencimentoParcela();
        }

        public IEnumerable<II015_FormaPagamento> GetI015_FormaPagamento()
        {
            return _integracaoBancariaRepository.GetI015_FormaPagamento();
        }

        public IEnumerable<II017_FormaPagamentoIOF> GetI017_FormaPagamentoIOF()
        {
            return _integracaoBancariaRepository.GetI017_FormaPagamentoIOF();
        }

        public IEnumerable<IK001_CodigosOcorrencia> GetK001_Codigo()
        {
            return _integracaoBancariaRepository.GetK001_Codigo();
        }

        public IEnumerable<IK002A_CategoriaTipoMovimento> GetK002A_CategoriaTipoMovimento()
        {
            return _integracaoBancariaRepository.GetK002A_CategoriaTipoMovimento();
        }

        public IEnumerable<IK002_TipoMovimento> GetK002_TipoMovimento()
        {
            return _integracaoBancariaRepository.GetK002_TipoMovimento();
        }

        public IEnumerable<IK003_CodigoFinalidadeMovimento> GetK003_CodigoFinalidadeMovimento()
        {
            return _integracaoBancariaRepository.GetK003_CodigoFinalidadeMovimento();
        }

        public IEnumerable<IK004_FormaEntradaDadosCheque> GetK004_FormaEsntradaDado()
        {
            return _integracaoBancariaRepository.GetK004_FormaEsntradaDado();
        }

        public IEnumerable<IK006_TipoInscricaoEmitente> GetK006_TipoInscricaoEmitente()
        {
            return _integracaoBancariaRepository.GetK006_TipoInscricaoEmitente();
        }

        public IEnumerable<IK020_CodigoOcorrencia> GetK020_CodigoOcorrencia()
        {
            return _integracaoBancariaRepository.GetK020_CodigoOcorrencia();
        }

        public IEnumerable<IN003_TipoIdentificacaoContribuinte> GetN003_TipoIdentificacaoContribuinte()
        {
            return _integracaoBancariaRepository.GetN003_TipoIdentificacaoContribuinte();
        }

        public IEnumerable<IN005A_TipoTributo> GetN005A_TipoTributo()
        {
            return _integracaoBancariaRepository.GetN005A_TipoTributo();
        }

        public IEnumerable<IN005_CodigoIdentificacaoTributo> GetN005_CodigoIdentificacaoTributo()
        {
            return _integracaoBancariaRepository.GetN005_CodigoIdentificacaoTributo();
        }

        public IEnumerable<IN019_OpcaoPagamento> GetN019_OpcaoPagamento()
        {
            return _integracaoBancariaRepository.GetN019_OpcaoPagamento();
        }

        public IEnumerable<IN020_OpcaoRetiradaCRVL> GetN020_OpcaoRetiradaCRVL()
        {
            return _integracaoBancariaRepository.GetN020_OpcaoRetiradaCRVL();
        }

        public IEnumerable<IN027_IdentificadorTributo> GetN027_IdentificadorTributo()
        {
            return _integracaoBancariaRepository.GetN027_IdentificadorTributo();
        }

        public IEnumerable<IP001_CodigoCamaraCentralizadora> GetP001_CodigoCamaraCentralizadora()
        {
            return _integracaoBancariaRepository.GetP001_CodigoCamaraCentralizadora();
        }

        public IEnumerable<IP006_AvisoFavorecido> GetP006_AvisoFavorecido()
        {
            return _integracaoBancariaRepository.GetP006_AvisoFavorecido();
        }

        public IEnumerable<IP014_IndicativoFormaPagamento> GetP014_IndicativoFormaPagamento()
        {
            return _integracaoBancariaRepository.GetP014_IndicativoFormaPagamento();
        }

        public IEnumerable<IV002_CodigoMovimentoRemessa> GetV002_CodigoMovimentoRemessa()
        {
            return _integracaoBancariaRepository.GetV002_CodigoMovimentoRemessa();
        }

        public IEnumerable<IV003_CodigoMovimentoRetorno> GetV003_CodigoMovimentoRetorno()
        {
            return _integracaoBancariaRepository.GetV003_CodigoMovimentoRetorno();
        }

        public IEnumerable<IV005_FormaPagamento> GetV005_FormaPagamento()
        {
            return _integracaoBancariaRepository.GetV005_FormaPagamento();
        }

        public IEnumerable<IV009_TipoVencimentoParcelas> GetV009_TipoVencimentoParcela()
        {
            return _integracaoBancariaRepository.GetV009_TipoVencimentoParcela();
        }

        public IEnumerable<IV010A_TipoMotivoOcorrencia> GetV010A_TipoMotivoOcorrencia()
        {
            return _integracaoBancariaRepository.GetV010A_TipoMotivoOcorrencia();
        }

        public IEnumerable<IV010_MotivoOcorrencia> GetV010_MotivoOcorrencia()
        {
            return _integracaoBancariaRepository.GetV010_MotivoOcorrencia();
        }

        public IEnumerable<IV020_FormaPagamentoIOF> GetV020_FormaPagamentoIOF()
        {
            return _integracaoBancariaRepository.GetV020_FormaPagamentoIOF();
        }

        public IEnumerable<IV021_TipoEqualizacao> GetV021_TipoEqualizacao()
        {
            return _integracaoBancariaRepository.GetV021_TipoEqualizacao();
        }

        public IEnumerable<IV022_ModalidadeEqualizacao> GetV022_ModalidadeEqualizacao()
        {
            return _integracaoBancariaRepository.GetV022_ModalidadeEqualizacao();
        }

        public IEnumerable<IV032_CodigoMoedaVendedor> GetV032_CodigoMoedaVendedor()
        {
            return _integracaoBancariaRepository.GetV032_CodigoMoedaVendedor();
        }

        public IEnumerable<IV040_CodigoDesconto> GetV040_CodigoDesconto()
        {
            return _integracaoBancariaRepository.GetV040_CodigoDesconto();
        }

        public IEnumerable<IV042_CodigoProtesto> GetV042_CodigoProtesto()
        {
            return _integracaoBancariaRepository.GetV042_CodigoProtesto();
        }

        public IEnumerable<IV047_TipoLancamentoValorEqualizacao> GetV047_TipoLancamentoValorEqualizacao()
        {
            return _integracaoBancariaRepository.GetV047_TipoLancamentoValorEqualizacao();
        }
    }
}
