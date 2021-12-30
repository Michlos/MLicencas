using DomainLayer.Financeiro;

using Financeiro.UCViews.Bancos;

using InfraStructure;
using InfraStructure.Repository.Bancos;

using ServiceLayer.CommonServices;

using ServicesLayer.Bancos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Banco
{
    public partial class BancoAddForm : Form
    {
        
        private int bancoId;
        
        //SERVICES
        QueryStringServices _queryString;
        BancosServices _bancosServices;
        
        //MODELS LISTMODELS
        private IBancoModel bancoModel = new BancoModel();
        private IEnumerable<IBancoModel> bancoListModel = new List<IBancoModel>();

        public BancoAddForm(int bancoId)
        {
            LoadServices();
            InitializeComponent();
            this.bancoId = bancoId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bancoModel = (cbBanco.SelectedItem as IBancoModel);
            bancoModel.Ativo = true;


            if (bancoId != 0)
            {
                UpdateBanco();
            }
            else
            {
                AddBanco();
            }
        }

        private void AddBanco()
        {
            try
            {
                _bancosServices.Edit(bancoModel);
                MessageBox.Show("Banco Adicionado com sucesso");
                bancoId = bancoModel.Id;
                LoadFormFields();
                LoadUserControlContas();
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void UpdateBanco()
        {
            try
            {
                _bancosServices.Edit(bancoModel);
                MessageBox.Show("Banco Atualizado com sucesso.");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void BancoAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadCBCodBanco();
            LoadCBNomeBanco();
            LoadFormFields();
            LoadUserControlContas();
        }

        private void LoadCBNomeBanco()
        {
            cbBanco.DataSource = bancoListModel;
            cbBanco.DisplayMember = "Nome";
            cbBanco.SelectedIndex = -1;
        }

        private void LoadCBCodBanco()
        {
            cbCodigo.DataSource = bancoListModel;
            cbCodigo.DisplayMember = "CodigoBC";
            cbCodigo.SelectedIndex = -1;
        }

        private void LoadModels()
        {
            bancoListModel = _bancosServices.GetAll();
        }

        private void LoadFormFields()
        {
            if (bancoId != 0)
            {
                groupBoxContas.Enabled = true;
                bancoModel = _bancosServices.GetById(bancoId);
                bancoId = bancoModel.Id;

                txbId.Text = bancoModel.Id.ToString();
                cbBanco.Text = bancoModel.Nome;
                cbCodigo.Text = bancoModel.CodigoBc;

            }
            else
            {
                groupBoxContas.Enabled = false;
            }
        }

        private void LoadUserControlContas()
        {
            ContasListUC contas = new ContasListUC(bancoId);
            groupBoxContas.Controls.Clear();
            groupBoxContas.Controls.Add(contas);
            contas.Dock = DockStyle.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCodigo.SelectedIndex != -1)
            {
                cbBanco.Text = (cbCodigo.SelectedItem as IBancoModel).Nome;
            }
        }

        private void cbBanco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBanco.SelectedIndex != -1)
            {
                cbCodigo.Text = (cbBanco.SelectedItem as IBancoModel).CodigoBc;
            }
        }
    }
}
