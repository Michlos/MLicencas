using DomainLayer.Clientes;
using DomainLayer.Situacao;

using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Situacoes;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;
using ServicesLayer.SituacoesServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Clientes
{
    public partial class ClientesListForm : Form
    {
        private int clienteId;

        //SERVICES
        private QueryStringServices _queryString;
        private ClientesServices _clientesServices;
        private SituacoesServices _statusServices;

        //MODELS AND LISTMODELS
        private IEnumerable<IClienteModel> clientListModel = new List<IClienteModel>();
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();

        public ClientesListForm()
        {
            LoadServices();
            InitializeComponent();

            LoadModels();
        }

        private void LoadModels()
        {
            clientListModel = _clientesServices.GetAll();
            statusListModel = _statusServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }

        private void ClientesListForm_Load(object sender, EventArgs e)
        {
            CheckPermissoes();
            LoadDGVClientes();
        }

        private void LoadDGVClientes()
        {
            //RAZAO SOCIAL / CNPJ/ EMAIL / SITUAÇÃO
            DataTable tableClientes = ModelaTableClientes();
            DataRow row = ModelaRowClientes(tableClientes, clientListModel);
            dgvClientes.DataSource = tableClientes;
            ConfigDGVClientes();

        }

        private DataTable ModelaTableClientes()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("RazaoSocial", typeof(string));
            table.Columns.Add("Cnpj", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Status", typeof(string));

            return table;
        }

        private DataRow ModelaRowClientes(DataTable tableClientes, IEnumerable<IClienteModel> clientListModel)
        {
            DataRow row = null;
            if (clientListModel.Any())
            {
                foreach (var item in clientListModel)
                {
                    row = tableClientes.NewRow();

                    row["Id"] = item.Id;
                    row["RazaoSocial"] = item.RazaoSocial;
                    row["Cnpj"] = item.Cnpj;
                    row["Email"] = item.Email;
                    row["Status"] = statusListModel.Where(id => id.Id == item.SituacaoId).FirstOrDefault().Descricao;

                    tableClientes.Rows.Add(row);
                }
            }
            return row;
        }

        private void ConfigDGVClientes()
        {
            dgvClientes.Columns["Id"].Visible = false;
            dgvClientes.Columns["RazaoSocial"].HeaderText = "Empresa";
            dgvClientes.Columns["RazaoSocial"].Width = 200;
            dgvClientes.Columns["Cnpj"].HeaderText = "CNPJ";
            dgvClientes.Columns["Cnpj"].Width = 150;
            dgvClientes.Columns["Email"].HeaderText = "E-mail";
            dgvClientes.Columns["Email"].Width = 200;
            dgvClientes.Columns["Status"].Width = 50;

        }

        private void CheckPermissoes()
        {
            btnNew.Enabled = MainView.CheckPermissoes(btnNew.Tag);
            btnEdit.Enabled = MainView.CheckPermissoes(btnEdit.Tag);
            novoToolStripMenuItem.Enabled = MainView.CheckPermissoes(novoToolStripMenuItem.Tag);
            editarToolStripMenuItem.Enabled = MainView.CheckPermissoes(editarToolStripMenuItem.Tag);
            alterarStatusToolStripMenuItem.Enabled = MainView.CheckPermissoes(alterarStatusToolStripMenuItem.Tag);
        }

        private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (e.RowIndex != dgvClientes.NewRowIndex))
            {

                e.Value = string.Format(@"{0:00\.000\.000\/0000\-00}", Int64.Parse(e.Value.ToString()));

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clienteId = 0;
            ShowFormEditCli();

        }

        private void ShowFormEditCli()
        {
            ClienteAddForm addForm = new ClienteAddForm(clienteId);
            addForm.ShowDialog();
            LoadModels();
            LoadDGVClientes();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //dgvContatosFabrica.CurrentRow.Cells[0].Value.ToString()
            clienteId = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
            ShowFormEditCli();
        }

        private void dgvClientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuClientes.Show(MousePosition);
            }
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowFormEditCli();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteId = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
            ShowFormEditCli();
        }

        private void alterarStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clienteId = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
            ClienteStatusForm cliAlterStatus = new ClienteStatusForm(clienteId);
            cliAlterStatus.ShowDialog();
            LoadModels();
            LoadDGVClientes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
