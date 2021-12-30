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
            txbNomeBanco.Text = bancoListModel.FirstOrDefault(id => id.Id == bancoId).Nome;
            LoadCBTipos();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (contaId != 0)
            {
                contaModel = new ContaBancariaModel();
                contaModel = _contasServices.GetById(contaId);
                txbId.Text = contaModel.Id.ToString();
                cbTipoConta.Text = tipoListModel.FirstOrDefault(id => id.Id == contaModel.TipoContaId).Tipo;
                txbAgencia.Text = contaModel.Agencia;
                txbAgenciaDV.Text = contaModel.AgenciaDV;
                txbConta.Text = contaModel.Conta;
                txbContaDV.Text = contaModel.ContaDV;
                chbEmiteBoleto.Checked = contaModel.EmiteBoleto;

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
            contaModel.BancoId = bancoId;
            contaModel.TipoContaId = (cbTipoConta.SelectedItem as ITipoContaBancariaModel).Id;
            contaModel.EmiteBoleto = chbEmiteBoleto.Checked;

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
    }
}
