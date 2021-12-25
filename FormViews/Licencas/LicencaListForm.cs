using DomainLayer.Clientes;
using DomainLayer.Clientes.Contratos;
using DomainLayer.Clientes.Contratos.Seriais;
using DomainLayer.Softwares;

using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.Seriais;
using InfraStructure.Repository.Softwares;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;
using ServicesLayer.Contratos;
using ServicesLayer.Seriais;
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

namespace MLicencas.FormViews.Licencas
{
    public partial class LicencaListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private SeriaisServices _seriaisServices;
        private SoftwaresServices _softwaresServices;
        private ClientesServices _clientesServices;
        private ContratosServices _contratosServices;

        //MODELS LISTMODELS
        private IEnumerable<ISerialModel> serialListModel = new List<ISerialModel>();
        private IEnumerable<IClienteModel> clienteListModel = new List<IClienteModel>();
        private IEnumerable<ISoftwareModel> softwareListModel = new List<ISoftwareModel>();
        private IEnumerable<IContratoModel> contratoListModel = new List<IContratoModel>();
        public LicencaListForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
        }

        private void LoadModels()
        {
            serialListModel = _seriaisServices.GetAll();
            clienteListModel = _clientesServices.GetAll();
            softwareListModel = _softwaresServices.GetAll();
            contratoListModel = _contratosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _seriaisServices = new SeriaisServices(new SerialRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LicencaListForm_Load(object sender, EventArgs e)
        {
            LoadDGVLicencas();
        }

        private void LoadDGVLicencas()
        {
            DataTable tableLicencas = GetTableLicencas();
            GetRowLicencas(tableLicencas);
            dgvSerials.DataSource = tableLicencas;
            ConfigDGVLicencas();
        }

        private void ConfigDGVLicencas()
        {
            dgvSerials.Columns["Id"].Visible = false;
            dgvSerials.Columns["Software"].Width = 180;
            dgvSerials.Columns["Cliente"].Width = 200;
            dgvSerials.Columns["Chave"].Width = 200;
            dgvSerials.Columns["Vencimento"].Width = 100;
        }

        private void GetRowLicencas(DataTable tableLicencas)
        {
            if (serialListModel.Any())
            {
                foreach (var item in serialListModel)
                {
                    DataRow row = tableLicencas.NewRow();

                    row["id"] = item.Id;
                    row["Software"] = softwareListModel.Where(id => id.Id == item.SoftwareId).FirstOrDefault().Nome;
                    row["Cliente"] = clienteListModel.Where(id => id.Id == item.ClienteId).FirstOrDefault().NomeFantasia;
                    row["Chave"] = item.Chave;
                    row["Vencimento"] = contratoListModel.Where(id => id.Id == item.ContratoId).FirstOrDefault().DataVencimento;

                    tableLicencas.Rows.Add(row);
                }
            }
        }

        private DataTable GetTableLicencas()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Software", typeof(string));
            table.Columns.Add("Cliente", typeof(string));
            table.Columns.Add("Chave", typeof(string));
            table.Columns.Add("Vencimento", typeof(DateTime));

            return table;
        }

        private void dgvSerials_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuLicencas.Show(MousePosition);
            }
        }
    }
}
