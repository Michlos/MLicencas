using DomainLayer.Softwares;
using DomainLayer.Softwares.Plataformas;

using InfraStructure;
using InfraStructure.Repository.Plataformas;
using InfraStructure.Repository.Softwares;

using ServiceLayer.CommonServices;

using ServicesLayer.Plataformas;
using ServicesLayer.Softwares;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Softwares
{
    public partial class SoftwareListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private SoftwaresServices _softwaresServices;
        private PlataformasServices _plataformasServices;
        private int indexRow;

        //MODELS LISTMODELS
        private IEnumerable<ISoftwareModel> softListModel = new List<ISoftwareModel>();
        private IEnumerable<IPlataformaModel> plataformaListModel = new List<IPlataformaModel>();

        public SoftwareListForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
        }

        private void LoadModels()
        {
            softListModel = _softwaresServices.GetAll();
            plataformaListModel = _plataformasServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _plataformasServices = new PlataformasServices(new PlataformaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void SoftwareListForm_Load(object sender, EventArgs e)
        {
            LoadDGVSofwares();
            CheckPermissions();
        }

        private void CheckPermissions()
        {
            btnNew.Enabled = MainView.CheckPermissoes(btnNew.Tag);
            editarToolStripMenuItem.Enabled = MainView.CheckPermissoes(editarToolStripMenuItem.Tag);
            novoToolStripMenuItem.Enabled = MainView.CheckPermissoes(novoToolStripMenuItem.Tag);
        }

        private void LoadDGVSofwares()
        {
            DataTable tableSofwares = ModelaTableSoftware();
            ModelaRowSoftware(tableSofwares);
            dgvSoftwares.DataSource = tableSofwares;
            ConfigDGVSoftware();
        }

        private void ConfigDGVSoftware()
        {
            dgvSoftwares.Columns["Id"].Visible = false;
            dgvSoftwares.Columns["Nome"].Width = 135;
            dgvSoftwares.Columns["Versao"].Width = 70;
            dgvSoftwares.Columns["Plataforma"].Width = 100;
        }

        private void ModelaRowSoftware(DataTable tableSofwares)
        {
            if (softListModel.Any())
            {

                foreach (var item in softListModel)
                {
                    DataRow row = tableSofwares.NewRow();

                    row["Id"] = item.Id;
                    row["Nome"] = item.Nome;
                    row["Versao"] = item.Versao;
                    row["Plataforma"] = plataformaListModel.Where(id => id.Id == item.PlataformaId).FirstOrDefault().Nome;

                    tableSofwares.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableSoftware()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Versao", typeof(string));
            table.Columns.Add("Plataforma", typeof(string));


            return table;
        }

        private void dgvSoftwares_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (dgvSoftwares.CurrentRow == null)
                {
                    indexRow = e.RowIndex;
                }
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SoftwareAddform softwareAddform = new SoftwareAddform(0);
            softwareAddform.ShowDialog();
            LoadModels();
            LoadDGVSofwares();
        }


        private void dgvSoftwares_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSoftwares.CurrentRow != null)
            {
                int softId = int.Parse(dgvSoftwares.CurrentRow.Cells[0].Value.ToString());
                SoftwareAddform softwareAddform = new SoftwareAddform(softId);
                softwareAddform.ShowDialog();
                LoadModels();
                LoadDGVSofwares();
            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvSoftwares.CurrentRow != null)
            {
                int softwareId = int.Parse(dgvSoftwares.CurrentRow.Cells[0].Value.ToString());
                SoftwareAddform softwareAddform = new SoftwareAddform(softwareId);
                softwareAddform.ShowDialog();
                LoadModels();
                LoadDGVSofwares();
            }

        }
    }
}
