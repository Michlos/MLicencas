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
    public partial class ContaListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private ContasBancariasServices _contasBancariasServices;
        private BancosServices _bancosServices;
        private TiposContasBancariasServices _tiposContasServices;


        //MODELS AND LISTMODELS
        private IEnumerable<IContaBancariaModel> contaListModel;
        private IEnumerable<IBancoModel> bancoListModel;
        private IEnumerable<ITipoContaBancariaModel> tipoContaListModel;

        //PROPERTIES
        private int contaId;

        public ContaListForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDGVContas();
        }

        private void LoadDGVContas()
        {
            DataTable tableContas = ModelaTableContas();
            ModelaRowContas(tableContas);
            dgvContas.DataSource = tableContas;
            ConfigDGVContas();
        }

        private void ConfigDGVContas()
        {

            dgvContas.Columns["Id"].Visible = false;
            dgvContas.Columns["Banco"].Width = 150;
            dgvContas.Columns["Agencia"].Width = 70;
            dgvContas.Columns["Agencia"].HeaderText = "Agência";
            dgvContas.Columns["Conta"].Width = 100;
            dgvContas.Columns["Tipo"].Width = 150;
            dgvContas.Columns["Saldo"].Width = 100;


        }

        private void ModelaRowContas(DataTable tableContas)
        {
            if (contaListModel.Any())
            {
                foreach (var item in contaListModel)
                {
                    DataRow row = tableContas.NewRow();

                    row["Id"] = item.Id;
                    row["Banco"] = bancoListModel.Where(id => id.Id == item.BancoId).FirstOrDefault().Nome;
                    row["Agencia"] = string.IsNullOrEmpty(item.AgenciaDV.Trim()) ? item.Agencia : item.Agencia + "-" + item.AgenciaDV;
                    row["Conta"] = item.Conta + "-" + item.ContaDV;
                    row["Tipo"] = tipoContaListModel.Where(id => id.Id == item.TipoContaId).FirstOrDefault().Tipo;
                    row["Saldo"] = item.SaldoAtual.ToString("C2");

                    tableContas.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableContas()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Banco", typeof(string));
            table.Columns.Add("Agencia", typeof(string));
            table.Columns.Add("Conta", typeof(string));
            table.Columns.Add("Tipo", typeof(string));
            table.Columns.Add("Saldo", typeof(string));

            return table;
        }

        private void LoadModels()
        {
            contaListModel = _contasBancariasServices.GetAll();
            bancoListModel = _bancosServices.GetAll();
            tipoContaListModel = _tiposContasServices.GetAll();

        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contasBancariasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposContasServices = new TiposContasBancariasServices(new TipoContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContas_SelectionChanged(object sender, EventArgs e)
        {
            contaId = int.Parse(dgvContas.CurrentRow.Cells[0].Value.ToString());
        }

        private void dgvContas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void adicionarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContaAddForm contaForm = new ContaAddForm(0, 0);
            contaForm.WindowState = FormWindowState.Normal;
            contaForm.cbNomeBanco.Enabled = true;
            contaForm.ShowDialog();
            LoadModels();
            LoadDGVContas();
        }

        private void editarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contaId != 0)
            {
                IContaBancariaModel contaModel = _contasBancariasServices.GetById(contaId);
                ContaAddForm contaForm = new ContaAddForm(contaModel.BancoId, contaModel.Id);
                contaForm.WindowState = FormWindowState.Normal;
                contaForm.ShowDialog();
                LoadModels();
                LoadDGVContas();
            }
        }
    }
}
