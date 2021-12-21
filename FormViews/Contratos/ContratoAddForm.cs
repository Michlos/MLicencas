using DomainLayer.Clientes;
using DomainLayer.Situacao;
using DomainLayer.Softwares;

using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.Situacoes;
using InfraStructure.Repository.Softwares;

using MLicencas.UCViews.Contratos;

using ServiceLayer.CommonServices;

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
    public partial class ContratoAddForm : Form
    {
        private int contratoId;
        private int ordemClausula;
        public int clienteId;
        List<ContratoClausulaUC> clausulasListUC = new List<ContratoClausulaUC>();

        //SERVICES
        private QueryStringServices _queryString;
        private ContratosServices _contratosServices;
        private ClientesServices _clientesServices;
        private SituacoesServices _statusServices;
        private SoftwaresServices _softwaresServices;

        //MODELS LISTMODELS
        private IEnumerable<IClienteModel> cliListModel = new List<IClienteModel>();
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();
        private IEnumerable<ISoftwareModel> softListModel = new List<ISoftwareModel>();


        public ContratoAddForm(int contratoId)
        {

            LoadServices();
            InitializeComponent();
            this.contratoId = contratoId;
            LoadListUC();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void LoadListUC()
        {
            var locationPanel = pnlContainer.Location.Y;
            foreach (var item in clausulasListUC)
            {
                item.Top += 10;
                pnlContainer.Controls.Add(item);


            }
        }

        private void btnAddClausula_Click(object sender, EventArgs e)
        {

            ContratoClausulaUC Uc = new ContratoClausulaUC(contratoId, ordemClausula, 0);
            ordemClausula++;
            clausulasListUC.Add(Uc);
            LoadListUC();

        }


        private void ContratoAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            this.clienteId = LoadFormSelectCli();
            LoadCbCliente();
            LoadCBStatus();
            LoadCBSoftware();
        }

        private void LoadCBSoftware()
        {
            cbSoftware.DataSource = softListModel;
            cbSoftware.DisplayMember = "Nome";
            cbSoftware.SelectedIndex = -1;
        }

        private void LoadModels()
        {
            cliListModel = _clientesServices.GetAll();
            statusListModel = _statusServices.GetAll();
            softListModel = _softwaresServices.GetAll();
        }

        private void LoadCbCliente()
        {
            cbCliente.DataSource = cliListModel;
            cbCliente.DisplayMember = "NomeFantasia";
            cbCliente.SelectedItem = cliListModel.Where(id => id.Id == clienteId).FirstOrDefault();
        }

        private int LoadFormSelectCli()
        {
            SelectClientForm selectClient = new SelectClientForm();
            selectClient.ShowDialog();
            return selectClient.clienteId;
        }

        private void LoadCBStatus()
        {
            cbStatus.DataSource = statusListModel;
            cbStatus.DisplayMember = "Descricao";
            cbStatus.SelectedIndex = 0;
        }

        private void btnSaveContrato_Click(object sender, EventArgs e)
        {
            if (contratoId != 0)
            {
                UpdateContrato();
            }
            else
            {
                Addcontrato();
            }
        }

        private void Addcontrato()
        {
            throw new NotImplementedException();
        }

        private void UpdateContrato()
        {
            throw new NotImplementedException();
        }
    }
}
