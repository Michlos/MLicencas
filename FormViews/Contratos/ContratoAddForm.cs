using CommonComponents;

using DomainLayer.Clientes;
using DomainLayer.Clientes.Contratos;
using DomainLayer.Clientes.Contratos.Clausulas;
using DomainLayer.Situacao;
using DomainLayer.Softwares;

using InfraStructure;
using InfraStructure.Repository.Clausulas;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.Situacoes;
using InfraStructure.Repository.Softwares;

using MLicencas.UCViews.Contratos;

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
    public partial class ContratoAddForm : Form
    {
        private int contratoId;
        //private int ordemClausula;
        public int clienteId;
        readonly List<ContratoClausulaUC> clausulasListUC = new List<ContratoClausulaUC>();

        //SERVICES
        private QueryStringServices _queryString;
        private ContratosServices _contratosServices;
        private ClientesServices _clientesServices;
        private SituacoesServices _statusServices;
        private SoftwaresServices _softwaresServices;
        private ClausulasServices _clausulasServices;

        //MODELS LISTMODELS
        private IContratoModel contratoModel;
        private IEnumerable<IClausulaModel> clausulaListModel = new List<IClausulaModel>();
        private IEnumerable<IClienteModel> cliListModel = new List<IClienteModel>();
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();
        private IEnumerable<ISoftwareModel> softListModel = new List<ISoftwareModel>();


        public ContratoAddForm(int contratoId)
        {

            LoadServices();
            InitializeComponent();
            this.contratoId = contratoId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clausulasServices = new ClausulasServices(new ClausulaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }


        private void btnAddClausula_Click(object sender, EventArgs e)
        {
            ContratoClausulaUC Uc = new ContratoClausulaUC(contratoId, 0);
            IncludeItemContratoForm itemContratoForm = new IncludeItemContratoForm(Uc);
            itemContratoForm.ShowDialog();
            LoadFormFields();
            LoadDGVClausulas();


        }


        private void ContratoAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            if (contratoId == 0)
                this.clienteId = LoadFormSelectCli();
            LoadCbCliente();
            LoadCBStatus();
            LoadCBSoftware();
            LoadFormFields();
            LoadDGVClausulas();
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
            contratoModel = new ContratoModel();
            contratoModel.Id = contratoId;
            contratoModel.Nome = txbNome.Text;
            contratoModel.Termo = txbTermo.Text;
            contratoModel.DataRegistro = DateTime.Parse(dtRegistro.Text);
            contratoModel.DataVencimento = DateTime.Parse(dtVencimento.Text);
            contratoModel.Prorrogacoes = 0;
            contratoModel.ClienteId = (cbCliente.SelectedItem as IClienteModel).Id;
            contratoModel.SoftwareId = (cbSoftware.SelectedItem as ISoftwareModel).Id;
            contratoModel.SituacaoId = (cbStatus.SelectedItem as ISituacaoModel).Id;

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
            try
            {
                this.contratoModel = _contratosServices.Add(contratoModel);
                this.contratoId = this.contratoModel.Id;
                MessageBox.Show("Contrato salvo com sucesso", this.Text);
                LoadFormFields();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void LoadFormFields()
        {
            if (contratoId != 0)
            {
                btnAddClausula.Enabled = true;
                this.contratoModel = _contratosServices.GetById(contratoId);
                txbId.Text = this.contratoModel.Id.ToString();
                txbNome.Text = this.contratoModel.Nome;
                txbTermo.Text = this.contratoModel.Termo;
                dtRegistro.Text = this.contratoModel.DataRegistro.ToString();
                dtVencimento.Text = this.contratoModel.DataVencimento.ToString();
                cbCliente.SelectedItem = cliListModel.Where(id => id.Id == this.contratoModel.ClienteId).FirstOrDefault();
                cbSoftware.SelectedItem = softListModel.Where(id => id.Id == this.contratoModel.SoftwareId).FirstOrDefault();
                cbStatus.SelectedItem = statusListModel.Where(id => id.Id == this.contratoModel.SituacaoId);

            }
            else
            {

                btnAddClausula.Enabled = false;
            }

        }

        private void LoadDGVClausulas()
        {
            clausulaListModel = _clausulasServices.GetAllByContratoId(contratoId);
            if (clausulaListModel.Any())
            {
                DataTable tableClausulas = GetTableClausulas();
                GetRowClausulas(tableClausulas);
                dgvClausulas.DataSource = tableClausulas;
                ConfigDGVClausulas();
            }


        }

        private DataTable GetTableClausulas()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Clausula", typeof(string));
            table.Columns.Add("Titulo", typeof(string));
            return table;
        }

        private void GetRowClausulas(DataTable tableClausulas)
        {
            if (clausulaListModel.Any())
            {
                int indexClausula = 1;
                foreach (var item in clausulaListModel)
                {

                    DataRow row = tableClausulas.NewRow();

                    row["Id"] = item.Id;
                    row["Clausula"] = GetOrdinal.GetNum(indexClausula);
                    row["Titulo"] = item.Titulo;

                    tableClausulas.Rows.Add(row);
                    indexClausula++;

                }
            }
        }

        private void ConfigDGVClausulas()
        {
            dgvClausulas.Columns["Id"].Width = 30;
            dgvClausulas.Columns["Clausula"].Width = 250; //CLÁUSULA PRIMEIRA... DADA PELO INDEX
            dgvClausulas.Columns["Clausula"].HeaderText = "Cláusula";
            dgvClausulas.Columns["Titulo"].Width = 450; //DO OBJETO... OBIRGAÇÕES DO CONTRATANTE...
            dgvClausulas.Columns["Titulo"].HeaderText = "Título";
        }

        private void UpdateContrato()
        {
            try
            {
                _contratosServices.Edit(contratoModel);
                MessageBox.Show("Contrato atualizado com sucesso", this.Text);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);
            }
        }
    }
}
