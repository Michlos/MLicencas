using DomainLayer.Financeiro;

using InfraStructure;
using InfraStructure.Repository.Bancos;
using InfraStructure.Repository.ContaBancaria;

using ServiceLayer.CommonServices;

using ServicesLayer.Bancos;
using ServicesLayer.ContasBancarias;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Banco.LancamentoBancario
{
    public partial class SelectContaForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private ContasBancariasServices _contasServices;
        private BancosServices _bancosServices;


        //MODELS LISTMODELS
        private IEnumerable<IContaBancariaModel> contasListModel;
        private IEnumerable<IBancoModel> bancoListModel;
        public IContaBancariaModel contaModel;

        //PROPERTIES
        private readonly LancamentoBancarioForm lancamentoBancarioForm;
        public SelectContaForm(LancamentoBancarioForm lancamentoBancarioForm)
        {
            this.lancamentoBancarioForm = lancamentoBancarioForm;
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDGVContas();
        }

        private void LoadDGVContas()
        {
            DataTable tableContas = ModelaDataTable();
            ModelaRowTable(tableContas);
            dgvContas.DataSource = tableContas;
            ConfigDatGridView();
        }

        private void ConfigDatGridView()
        {
            dgvContas.Columns["Id"].Visible = false;
            dgvContas.Columns["Banco"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvContas.Columns["Agencia"].HeaderText = "Agência";
            dgvContas.Columns["Agencia"].Width = 50;
            dgvContas.Columns["Conta"].Width = 100;
        }

        private void ModelaRowTable(DataTable tableContas)
        {
            DataRow row = null;
            if (contasListModel.Any())
            {
                foreach (var item in contasListModel)
                {
                    row = tableContas.NewRow();

                    row["Id"] = item.Id;
                    row["Banco"] = bancoListModel.FirstOrDefault(id => id.Id == item.BancoId).Nome;
                    row["Agencia"] = item.Agencia + (!string.IsNullOrEmpty(item.AgenciaDV.Trim()) ? "-" + item.AgenciaDV : "");
                    row["Conta"] = item.Conta + (!string.IsNullOrEmpty(item.ContaDV) ? "-" + item.ContaDV : "");
                    
                    tableContas.Rows.Add(row);

                }
            }
        }

        private DataTable ModelaDataTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Banco", typeof(string));
            table.Columns.Add("Agencia", typeof(string));
            table.Columns.Add("Conta", typeof(string));

            return table;
        }

        private void LoadModels()
        {
            contasListModel = _contasServices.GetAll();
            bancoListModel = _bancosServices.GetAll();
            bancoListModel = bancoListModel.Where(ativo => ativo.Ativo);
            if (contasListModel == null)
            {
                MessageBox.Show("O sistema não possui nenhuma conta cadastrada.\nCadastre uma conta para gerenciar os lançamentos.");
                this.Close();
            }
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void dgvContas_SelectionChanged(object sender, EventArgs e)
        {
            contaModel = _contasServices.GetById(int.Parse(dgvContas.CurrentRow.Cells[0].Value.ToString()));
        }

        private void dgvContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lancamentoBancarioForm.contaModel = this.contaModel;
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            lancamentoBancarioForm.contaModel = this.contaModel;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
