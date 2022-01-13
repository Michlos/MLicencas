using CommonComponents;

using DomainLayer.Financeiro;

using InfraStructure;
using InfraStructure.Repository.Bancos;
using InfraStructure.Repository.ContaBancaria;
using InfraStructure.Repository.TiposContasBancarias;

using ServiceLayer.CommonServices;

using ServicesLayer.Bancos;
using ServicesLayer.ContasBancarias;
using ServicesLayer.TiposContasBancarias;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Banco.ContaBancaria
{
    public partial class ContaAddForm : Form
    {
        private int contaId;
        private readonly int bancoId;

        //SERVICES
        QueryStringServices _queryString;
        TiposContasBancariasServices _tiposServices;
        ContasBancariasServices _contasServices;
        BancosServices _bancosServices;


        //MODELS LISTMODELS
        private IContaBancariaModel contaModel;
        private IEnumerable<ITipoContaBancariaModel> tipoListModel = new List<ITipoContaBancariaModel>();
        private IEnumerable<IBancoModel> bancoListModel = new List<IBancoModel>();

        public ContaAddForm(int bancoId, int contaId)
        {
            LoadServices();
            InitializeComponent();
            this.bancoId = bancoId;
            this.contaId = contaId;
            AplicarEventoFloat(txbSaldoInicial);
            AplicarEventoFloat(txbSaldoAtual);

        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _tiposServices = new TiposContasBancariasServices(new TipoContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void ContaAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadCBTipos();
            LoadCBBancos();
            LoadFormFields();
        }

        private void LoadCBBancos()
        {
            cbNomeBanco.DataSource = bancoListModel;
            cbNomeBanco.DisplayMember = "Nome";
            cbNomeBanco.SelectedIndex = -1;
        }

        private void LoadFormFields()
        {
            if (contaId != 0)
            {
                contaModel = new ContaBancariaModel();
                contaModel = _contasServices.GetById(contaId);
                txbId.Text = contaModel.Id.ToString();
                cbTipoConta.Text = tipoListModel.FirstOrDefault(id => id.Id == contaModel.TipoContaId).Tipo;
                cbNomeBanco.Text = bancoId != 0 ? bancoListModel.FirstOrDefault(id => id.Id == bancoId).Nome : "";
                txbAgencia.Text = contaModel.Agencia;
                txbAgenciaDV.Text = contaModel.AgenciaDV;
                txbConta.Text = contaModel.Conta;
                txbContaDV.Text = contaModel.ContaDV;
                chbEmiteBoleto.Checked = contaModel.EmiteBoleto;
                txbConvenio.Text = contaModel.EmiteBoleto ? contaModel.Convenio : string.Empty;
                txbSaldoInicial.Text = contaModel.SaldoAnterior.ToString();
                txbSaldoAtual.Text = contaModel.SaldoAtual.ToString();

            }
        }

        private void LoadCBTipos()
        {
            cbTipoConta.DataSource = tipoListModel;
            cbTipoConta.DisplayMember = "Tipo";
            cbTipoConta.SelectedIndex = -1;
        }

        private void LoadModels()
        {
            tipoListModel = _tiposServices.GetAll();
            bancoListModel = _bancosServices.GetAll();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            contaModel = new ContaBancariaModel();

            contaModel.Id = contaId;
            contaModel.Conta = txbConta.Text;
            contaModel.ContaDV = txbContaDV.Text;
            contaModel.Agencia = txbAgencia.Text;
            contaModel.AgenciaDV = txbAgenciaDV.Text;
            contaModel.BancoId = (cbNomeBanco.SelectedItem as IBancoModel).Id;
            contaModel.TipoContaId = (cbTipoConta.SelectedItem as ITipoContaBancariaModel).Id;
            contaModel.EmiteBoleto = chbEmiteBoleto.Checked;
            contaModel.Convenio = chbEmiteBoleto.Checked ? txbConta.Text : null;
            contaModel.SaldoAnterior = double.Parse(txbSaldoInicial.Text.Replace("R$", "").Trim());
            contaModel.SaldoAtual = double.Parse(txbSaldoAtual.Text.Replace("R$", "").Trim());

            if (contaId != 0)
            {
                UpdateConta();
            }
            else
            {
                Addconta();
            }
        }

        private void Addconta()
        {
            try
            {
                contaModel = _contasServices.Add(contaModel);
                MessageBox.Show("Conta Adicionada com sucesso");
                contaId = contaModel.Id;

                if (!bancoListModel.FirstOrDefault(id => id.Id == contaModel.BancoId).Ativo)
                {
                    IBancoModel bancoModel = _bancosServices.GetById(contaModel.BancoId);
                    bancoModel.Ativo = true;
                    try
                    {
                        _bancosServices.Edit(bancoModel);

                    }
                    catch (Exception)
                    {

                        throw new Exception("Não foi possível ativar o banco selecionado.");
                    }
                }
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void UpdateConta()
        {
            try
            {
                _contasServices.Edit(contaModel);
                MessageBox.Show("Conta Alterada com sucesso");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void chbEmiteBoleto_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEmiteBoleto.Checked)
            {
                txbConvenio.Enabled = true;
            }
            else
            {
                txbConvenio.Text = string.Empty;
                txbConvenio.Enabled = false;
            }
        }

        #region TRATAMENTO DE FORMATO DE VALORES DE PONTOS FLUTUANTES
        private void AplicarEventoFloat(TextBox txt)
        {
            txt.Enter += AplyFloatCurrency.TirarMascara;
            txt.Leave += AplyFloatCurrency.RetornarMarcarca;
            txt.KeyPress += AplyFloatCurrency.AenpasValorNumerico;
            txt.TextChanged += AplyFloatCurrency.RetornarMarcarca;
        }

        #endregion
    }
}
