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
            bancoModel.Id = bancoId;
            bancoModel.Nome = txbNomeBanco.Text;
            bancoModel.CodigoBc = txbCodigoBc.Text;

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
                bancoModel = _bancosServices.Add(bancoModel);
                MessageBox.Show("Banco Adicionado com sucesso");
                bancoId = bancoModel.Id;
                LoadFormFields();
                
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
            LoadUserControlContas();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (bancoId != 0)
            {
                groupBoxContas.Enabled = true;
                bancoModel = _bancosServices.GetById(bancoId);

                txbId.Text = bancoModel.Id.ToString();
                txbNomeBanco.Text = bancoModel.Nome;
                txbCodigoBc.Text = bancoModel.CodigoBc;

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
    }
}
