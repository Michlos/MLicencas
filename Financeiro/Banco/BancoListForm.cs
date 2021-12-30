using DomainLayer.Financeiro;

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
    public partial class BancoListForm : Form
    {
        //SERVICES
        QueryStringServices _queryString;
        BancosServices _bancosServices;

        //MODELS AND LISTMODELS
        private IEnumerable<IBancoModel> bancoListModel = new List<IBancoModel>();
        
        public BancoListForm()
        {
            LoadServices();
            InitializeComponent();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BancoListForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadDGVBancos();
        }

        private void LoadDGVBancos()
        {
            DataTable tableBancos = ModelaTableBancos();
            ModelaRowBancos(tableBancos);
            dgvBancos.DataSource = tableBancos;
            ConfigDGVBancos();
        }

        private void ConfigDGVBancos()
        {
            dgvBancos.Columns["Id"].Visible = false;
            dgvBancos.Columns["CodigoBC"].Width = 50;
            dgvBancos.Columns["CodigoBC"].HeaderText = "Código";
            dgvBancos.Columns["Nome"].Width = 200;


        }

        private void ModelaRowBancos(DataTable tableBancos)
        {
            if (bancoListModel.Any())
            {
                foreach (var item in bancoListModel)
                {
                    DataRow row = tableBancos.NewRow();

                    row["Id"] = item.Id;
                    row["CodigoBC"] = item.CodigoBc;
                    row["Nome"] = item.Nome;

                    tableBancos.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableBancos()
        {
            DataTable table = new DataTable();
            
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("CodigoBC", typeof(string));
            table.Columns.Add("Nome", typeof(string));

            return table;
        }

        private void LoadModels()
        {
            bancoListModel = _bancosServices.GetAll();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            BancoAddForm bancoAddForm = new BancoAddForm(0);
            bancoAddForm.WindowState = FormWindowState.Normal;
            bancoAddForm.ShowDialog();
            LoadModels();
            LoadDGVBancos();
        }

        private void dgvBancos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBancos.CurrentRow != null)
            {
                int bancoId = int.Parse(dgvBancos.CurrentRow.Cells["Id"].Value.ToString());
                BancoAddForm bancoAddForm = new BancoAddForm(bancoId);
                bancoAddForm.WindowState = FormWindowState.Normal;
                bancoAddForm.ShowDialog();
                LoadModels();
                LoadDGVBancos();
            }
        }
    }
}
