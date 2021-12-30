using DomainLayer.Financeiro;

using Financeiro.Banco.ContaBancaria;

using InfraStructure;
using InfraStructure.Repository.ContaBancaria;
using InfraStructure.Repository.TiposContasBancarias;

using ServiceLayer.CommonServices;

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

namespace Financeiro.UCViews.Bancos
{
    public partial class ContasListUC : UserControl
    {
        private readonly int bancoId;

        //SERVICES
        private QueryStringServices _queryString;
        private ContasBancariasServices _contasServices;
        private TiposContasBancariasServices _tiposServices;

        //MODELS LISTMODELS
        private IEnumerable<IContaBancariaModel> contaListModel;
        private IEnumerable<ITipoContaBancariaModel> tipoListModel;

        public ContasListUC(int bancoId)
        {
            LoadServices();
            InitializeComponent();
            this.bancoId = bancoId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposServices = new TiposContasBancariasServices(new TipoContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void ContasListUC_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadDGVContas();
        }

        private void LoadModels()
        {
            tipoListModel = _tiposServices.GetAll();
            contaListModel = _contasServices.GetAllByBancoId(bancoId);
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
            dgvContas.Columns["Agencia"].HeaderText = "Agência";
            dgvContas.Columns["Agencia"].Width = 50;
            dgvContas.Columns["Conta"].Width = 130;
            dgvContas.Columns["Tipo"].Width = 100;
        }

        private void ModelaRowContas(DataTable tableContas)
        {
            if (contaListModel.Any())
            {
                foreach (var item in contaListModel)
                {
                    DataRow row = tableContas.NewRow();

                    row["Id"] = item.Id;
                    row["Agencia"] = string.IsNullOrEmpty(item.AgenciaDV.ToString().Trim()) ? item.Agencia : item.Agencia + "-" + item.AgenciaDV;
                    row["Conta"] = item.Conta + "-" + item.ContaDV;
                    row["Tipo"] = tipoListModel.FirstOrDefault(id => id.Id == item.TipoContaId).Tipo;

                    tableContas.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableContas()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Agencia", typeof(string));
            table.Columns.Add("Conta", typeof(string));
            table.Columns.Add("Tipo", typeof(string));
            return table;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            
            ContaAddForm contaAddForm = new ContaAddForm(bancoId, 0);
            contaAddForm.WindowState = FormWindowState.Normal;
            contaAddForm.ShowDialog();
            LoadModels();
            LoadDGVContas();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvContas.CurrentRow != null)
            {
                int contaId = int.Parse(dgvContas.CurrentRow.Cells["Id"].Value.ToString());
                ContaAddForm contaEditForm = new ContaAddForm(bancoId, contaId);
                contaEditForm.WindowState = FormWindowState.Normal;
                contaEditForm.ShowDialog();
                LoadModels();
                LoadDGVContas();
            }
            else
            {
                MessageBox.Show("Selecione uma conta");
            }
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContas.CurrentRow != null)
                {
                    int contaId = int.Parse(dgvContas.CurrentRow.Cells["Id"].Value.ToString());
                    var result = MessageBox.Show($"Deseja realmente apagar o \nregistro da conta \"{dgvContas.CurrentRow.Cells["Conta"]}\"?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        _contasServices.Remove(contaId);
                        MessageBox.Show("Conta Removida com sucesso");
                        LoadModels();
                        LoadDGVContas();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        private void dgvContas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripContas.Show(MousePosition);
            }
        }
    }
}
