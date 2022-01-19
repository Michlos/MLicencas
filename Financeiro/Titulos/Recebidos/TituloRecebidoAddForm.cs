using CommonComponents;

using DomainLayer.Financeiro;
using DomainLayer.Financeiro.Bancos.ContaBancaria;
using DomainLayer.Financeiro.Caixa;
using DomainLayer.Financeiro.Recebiveis;

using Financeiro.Banco.LancamentoBancario;

using InfraStructure;
using InfraStructure.Repository.Caixas;
using InfraStructure.Repository.ContaBancaria;
using InfraStructure.Repository.DestinosRecebiveis;
using InfraStructure.Repository.LancamentosCaixa;
using InfraStructure.Repository.LancamentosContasBancarias;
using InfraStructure.Repository.TipoLancamento;
using InfraStructure.Repository.TiposRecebimentosTitulos;
using InfraStructure.Repository.TitulosRecebidos;
using InfraStructure.Repository.TitulosRecebiveis;

using ServiceLayer.CommonServices;

using ServicesLayer.Caixa;
using ServicesLayer.ContasBancarias;
using ServicesLayer.DestinosRecebimentos;
using ServicesLayer.LancamentosCaixa;
using ServicesLayer.LancamentosContasBancarias;
using ServicesLayer.TiposLancamentos;
using ServicesLayer.TiposRecebimentosTitulos;
using ServicesLayer.TitulosRecebidos;
using ServicesLayer.TitulosRecebiveis;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Titulos.Recebidos
{
    public partial class TituloRecebidoAddForm : Form
    {
        private readonly int tituloRecebivelId;

        //SERVICES
        private QueryStringServices _queryString;
        private TitulosRecebidosServices _titulosRecebidosServices;
        private TitulosRecebiveisServices _titulosRecebiveisServices;
        private TiposRecebimentosTitulosServices _tiposRecebimentosTitulosServices;
        private DestinosRecebiveisServices _destinosRecebiveisServices;
        private LancamentosCaixaServices _lancamentosCaixaServices;
        private LancamentosContasBancariasServices _lancamentosContasBancariasServices;
        private CaixaServices _caixaServices;
        private TiposLancamentosServices _tiposLancamentosServices;
        private ContasBancariasServices _contasBancariasServices;

        //MODELS LISTMODELS
        private IEnumerable<ITipoRecebimentoTituloModel> tipoRecebimentoListModel;
        private IEnumerable<IDestinoRecebivelModel> destinoRecebimentoListModel;
        private ITituloRecebivelModel tituloRecebivelModel;
        private ITituloRecebidoModel recebidoModel;
        private IDestinoRecebivelModel destino;
        private ILancamentoCaixaModel lancamentoCaixa;
        private ILancamentoContaBancariaModel lancamentoConta;
        private IEnumerable<ICaixaModel> caixaListModel;
        private ICaixaModel caixaModel;
        private IEnumerable<ITipoLancamentoModel> tipoLancamentoListModel;
        private IContaBancariaModel contaBancariaModel;

        public TituloRecebidoAddForm(int tituloRecebivelId)
        {
            LoadServices();
            InitializeComponent();
            this.tituloRecebivelId = tituloRecebivelId;
            LoadModels();
            LoadCBTipos();
            LoadCBDestinos();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            txbTituloId.Text = txbTituloId.ToString();
            txbValorOriginal.Text = tituloRecebivelModel.ValorParcela.ToString("C2");
            dtpDataRecebimento.Value = DateTime.Now;
            txbValorRecebido.Text = tituloRecebivelModel.ValorParcela.ToString("C2");
        }

        private void LoadCBDestinos()
        {
            cbDestino.DataSource = destinoRecebimentoListModel;
            cbDestino.DisplayMember = "Destino";
            cbDestino.SelectedIndex = -1;
        }

        private void LoadCBTipos()
        {

            cbFormaPagamento.DataSource = tipoRecebimentoListModel;
            cbFormaPagamento.DisplayMember = "Tipo";
            cbFormaPagamento.SelectedIndex = -1;
        }

        private void LoadModels()
        {
            tipoRecebimentoListModel = _tiposRecebimentosTitulosServices.GetAll();
            destinoRecebimentoListModel = _destinosRecebiveisServices.GetAll();


            //SERÁ ALTERADO QUANDO CONCLUIR A INCLUSÃO DO REGISTRO
            tituloRecebivelModel = _titulosRecebiveisServices.GetById(tituloRecebivelId);

            tipoLancamentoListModel = _tiposLancamentosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _titulosRecebidosServices = new TitulosRecebidosServices(new TituloRecebidoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _titulosRecebiveisServices = new TitulosRecebiveisServices(new TituloRecebivelRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposRecebimentosTitulosServices = new TiposRecebimentosTitulosServices(new TipoRecebimentoTituloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _destinosRecebiveisServices = new DestinosRecebiveisServices(new DestinoRecebivelRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _lancamentosCaixaServices = new LancamentosCaixaServices(new LancamentoCaixaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _lancamentosContasBancariasServices = new LancamentosContasBancariasServices(new LancamentoContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _caixaServices = new CaixaServices(new CaixaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposLancamentosServices = new TiposLancamentosServices(new TipoLancamentoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contasBancariasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFormaPagamento.SelectedIndex > -1)
            {
                cbDestino.SelectedItem = (destinoRecebimentoListModel.FirstOrDefault(codigo => codigo.Codigo == (cbFormaPagamento.SelectedItem as TipoRecebimentoTituloModel).Destino));
                cbDestino.Text = (cbDestino.SelectedItem as ITipoRecebimentoTituloModel).Tipo;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            recebidoModel = new TituloRecebidoModel()
            {
                DataRecebimento = dtpDataRecebimento.Value,
                TipoRecebimentoId = (cbFormaPagamento.SelectedItem as ITipoRecebimentoTituloModel).Id,
                TituloRecebivelId = tituloRecebivelId,
                ValorTitulo = tituloRecebivelModel.ValorParcela,
                ValorRecebido = double.Parse(txbValorRecebido.Text)
            };
            destino = _destinosRecebiveisServices.GetById((cbDestino.SelectedItem as IDestinoRecebivelModel).Id);
            tituloRecebivelModel.Quitado = true;

            try
            {
                _titulosRecebidosServices.Add(recebidoModel);
                try
                {
                    _titulosRecebiveisServices.Edit(tituloRecebivelModel);
                    if (destino.Codigo == 'C')
                    {
                        //vai pro caixa
                        if (caixaListModel.Any(datafim => datafim.DataFechamento == null))
                        {
                            caixaModel = caixaListModel.LastOrDefault();
                        }
                        else
                        {
                            caixaModel = new CaixaModel()
                            {
                                DataAbertura = DateTime.Now,
                                SaldoAnterior = caixaListModel.Select(saldo => saldo.SaldoFinal).LastOrDefault(),

                            };
                            caixaModel = _caixaServices.Add(caixaModel);
                        }
                        lancamentoCaixa = new LancamentoCaixaModel()
                        {
                            CaixaId = caixaModel.Id,
                            DataLancamento = recebidoModel.DataRecebimento,
                            TipoLancamentoId = tipoLancamentoListModel.FirstOrDefault(tipo => tipo.Tipo == 'C').Id,
                            Valor = recebidoModel.ValorRecebido,
                            Historico = $"RECEBIMENTO DO TÍTULO {recebidoModel.Id} VIA TÍTULOS RECEBÍVEIS. USUÁRIO:{Global.User}"
                        };
                        try
                        {
                            _lancamentosCaixaServices.Add(lancamentoCaixa);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Lançamento em Caixa não foi registrado.");
                        }

                    }
                    else
                    {
                        //vai pro banco
                        //contaBancariaModel = SelectContaBancaria();
                        lancamentoConta = new LancamentoContaBancariaModel()
                        {
                            ContaId = contaBancariaModel.TipoContaId,
                            DataLancamento = DateTime.Now,
                            Historico = $"RECEBIMENTO DO TÍTULO {recebidoModel.Id} VIA TÍTULOS RECEBÍVEIS. USUÁRIO:{Global.User}",
                            TipoLancamentoId = tipoLancamentoListModel.FirstOrDefault(tipo => tipo.Tipo == 'C').Id,
                            Valor = recebidoModel.ValorRecebido,
                        };
                        try
                        {
                            _lancamentosContasBancariasServices.Add(lancamentoConta);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Lançamento não registrado na Conta Bancária.");
                        }
                        

                    }
                    MessageBox.Show("Título recebido com sucesso.");

                }
                catch (Exception)
                {
                    throw new Exception("Recebimento de título foi efetuado porém o título original não foi baixado.");
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }

        }

        private IContaBancariaModel SelectContaBancaria()
        {
            IContaBancariaModel contaModel;
            SelectContaForm selectConta = new SelectContaForm(this);
            selectConta.ShowDialog();
            contaModel = selectConta.contaModel;
            return contaModel;
        }

        private void cbDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbDestino.SelectedIndex > -1)
            {
                IDestinoRecebivelModel destino = (cbDestino.SelectedItem as IDestinoRecebivelModel);
                if (destino.Codigo == 'B')
                {
                    contaBancariaModel =  SelectContaBancaria();
                }
            }
        }
    }
}
