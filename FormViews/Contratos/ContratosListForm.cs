using DomainLayer.Clientes.Contratos;
using DomainLayer.Situacao;

using InfraStructure;
using InfraStructure.Repository.Contratos;

using ServiceLayer.CommonServices;

using ServicesLayer.Clausulas;
using ServicesLayer.ClientesServices;
using ServicesLayer.Contratos;
using ServicesLayer.SituacoesServices;
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

namespace MLicencas.FormViews.Contratos
{
    public partial class ContratosListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private ContratosServices _contratosServices;
        private ClientesServices _clientesServices;
        private SoftwaresServices _softwaresServices;
        private SituacoesServices _statusServices;

        //MODELS LISTMODELS
        private IEnumerable<IContratoModel> contratoListModel;

        public ContratosListForm()
        {
            LoaServices();
            InitializeComponent();
            LoadDGVContratos();
        }


        private void LoadDGVContratos()
        {

            contratoListModel = _contratosServices.GetAll();
            DataTable tableContratos = ModelaTableContratos();
            ModelaRowContratos(tableContratos);
            dgvContratos.DataSource = tableContratos;
            ConfigDGVContratos();
        }

        private void ConfigDGVContratos()
        {
            dgvContratos.Columns["Id"].Visible = false;
            dgvContratos.Columns["Cliente"].Width = 200;
            dgvContratos.Columns["Software"].Width = 200;
            dgvContratos.Columns["Vencimento"].Width = 80;
            dgvContratos.Columns["Status"].Width = 80;
        }

        private void ModelaRowContratos(DataTable tableContratos)
        {
            if (contratoListModel.Any())
            {
                foreach (var item in contratoListModel)
                {
                    DataRow row = tableContratos.NewRow();

                    row["Id"] = item.Id;
                    row["Cliente"] = _clientesServices.GetById(item.ClienteId).NomeFantasia;
                    row["Software"] = _softwaresServices.GetById(item.SoftwareId).Nome;
                    row["Vencimento"] = item.DataVencimento;
                    row["Status"] = _statusServices.GetById(item.SituacaoId).Descricao;

                    tableContratos.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableContratos()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Cliente", typeof(string));
            table.Columns.Add("Software", typeof(string));
            table.Columns.Add("Vencimento", typeof(DateTime));
            table.Columns.Add("Status", typeof(string));
            return table;
        }

        private void LoaServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvContratos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != dgvContratos.NewRowIndex)
            {
                e.Value = string.Format("{0:MM/dd/yyyy}", DateTime.Parse(e.Value.ToString()));
            }
        }
    }
}
