using CommonComponents;

using DomainLayer.Clientes;
using DomainLayer.Clientes.Contratos;
using DomainLayer.Clientes.Contratos.Clausulas;
using DomainLayer.Clientes.Contratos.Incisos;
using DomainLayer.Situacao;
using DomainLayer.Softwares;

using InfraStructure;
using InfraStructure.Repository.Clausulas;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.Incisos;
using InfraStructure.Repository.Situacoes;
using InfraStructure.Repository.Softwares;


using ServiceLayer.CommonServices;

using ServicesLayer.Clausulas;
using ServicesLayer.ClientesServices;
using ServicesLayer.Contratos;
using ServicesLayer.Contratos.Incisos;
using ServicesLayer.SituacoesServices;
using ServicesLayer.Softwares;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MLicencas.FormViews.Contratos
{
    public partial class ContratoAddForm : Form
    {
        private int contratoId;
        public int clienteId;

        //SERVICES
        private QueryStringServices _queryString;
        private ContratosServices _contratosServices;
        private ClientesServices _clientesServices;
        private SituacoesServices _statusServices;
        private SoftwaresServices _softwaresServices;
        private ClausulasServices _clausulasServices;
        private IncisosServices _incisosServices;

        //MODELS LISTMODELS
        private IContratoModel contratoModel;
        private IClausulaModel clausulaModel;
        private IEnumerable<IIncisoModel> incisoListModel = new List<IIncisoModel>();
        private IEnumerable<IClausulaModel> clausulaListModel = new List<IClausulaModel>();
        private IEnumerable<IClienteModel> cliListModel = new List<IClienteModel>();
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();
        private IEnumerable<ISoftwareModel> softListModel = new List<ISoftwareModel>();


        /// <summary>
        /// Pode receber como parâmetro o número d contrato para edição.
        /// Se <paramref name="contratoId"/> == 0 Novo Contrato.
        /// Se Não Edição de Contrato.
        /// </summary>
        /// <param name="contratoId"></param>
        public ContratoAddForm(int contratoId)
        {

            LoadServices();
            InitializeComponent();
            this.contratoId = contratoId;
            AplyCurrency(txbValor);
            AplyCurrency(txbValorParcela);
        }

        /// <summary>
        /// Parâmetro para leitura implementar todos os serviços necessários à classe.
        /// </summary>
        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clausulasServices = new ClausulasServices(new ClausulaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _incisosServices = new IncisosServices(new IncisoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void AplyCurrency(TextBox txt)
        {
            txt.Enter += AplyFloatCurrency.TirarMascara;
            txt.Leave += AplyFloatCurrency.RetornarMarcarca;
            txt.KeyPress += AplyFloatCurrency.AenpasValorNumerico;
        }
       

        private void ContratoAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            if (contratoId == 0)
                clienteId = LoadFormSelectCli();
            LoadCbCliente();
            LoadCBStatus();
            LoadCBSoftware();
            LoadFormFields();
            LoadDGVClausulas();
            dtVencimento.Value = DateTime.Now + TimeSpan.FromDays(30);
        }

        private void LoadModels()
        {
            cliListModel = _clientesServices.GetAll();
            statusListModel = _statusServices.GetAll();
            softListModel = _softwaresServices.GetAll();
        }
        private int LoadFormSelectCli()
        {
            SelectClientForm selectClient = new SelectClientForm();
            selectClient.ShowDialog();
            return selectClient.clienteId;
        }
        private void LoadCbCliente()
        {
            cbCliente.DataSource = cliListModel;
            cbCliente.DisplayMember = "NomeFantasia";
            cbCliente.SelectedItem = cliListModel.Where(id => id.Id == clienteId).FirstOrDefault();
        }
        private void LoadCBStatus()
        {
            cbStatus.DataSource = statusListModel;
            cbStatus.DisplayMember = "Descricao";
            cbStatus.SelectedIndex = 0;
        }
        private void LoadCBSoftware()
        {
            cbSoftware.DataSource = softListModel;
            cbSoftware.DisplayMember = "Nome";
            cbSoftware.SelectedIndex = -1;
        }




        private void txbParcelas_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbValor.Text) && !string.IsNullOrEmpty(txbParcelas.Text))
            {

                double valor = double.Parse(txbValor.Text.Replace("R$", "").Trim());
                int parcelas = int.Parse(txbParcelas.Text);
                double valorParcela = valor / parcelas;
                txbValorParcela.Text = valorParcela.ToString("C2");
            }
        }


        private void btnSaveContrato_Click(object sender, EventArgs e)
        {
            contratoModel = new ContratoModel();
            contratoModel.Id = contratoId;
            contratoModel.Nome = txbNome.Text;
            contratoModel.Termo = txbTermo.Text;
            contratoModel.DataRegistro = DateTime.Parse(dtRegistro.Text);
            contratoModel.DataVencimento = DateTime.Parse(dtVencimento.Text);
            contratoModel.Valor = double.Parse(txbValor.Text.Replace("R$", "").Trim());
            contratoModel.Parcelas = int.Parse(txbParcelas.Text);
            contratoModel.ValorParcela = double.Parse(txbValorParcela.Text.Replace("R$", "").Trim());
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
                contratoModel = _contratosServices.Add(contratoModel);
                contratoId = contratoModel.Id;
                MessageBox.Show("Contrato salvo com sucesso", this.Text);
                LoadFormFields();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
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

        
        private void LoadFormFields()
        {
            if (contratoId != 0)
            {
                contratoModel = _contratosServices.GetById(contratoId);
                txbId.Text = contratoModel.Id.ToString();
                txbNome.Text = contratoModel.Nome;
                txbTermo.Text = contratoModel.Termo;
                dtRegistro.Text = contratoModel.DataRegistro.ToString();
                dtVencimento.Text = contratoModel.DataVencimento.ToString();
                cbCliente.SelectedItem = cliListModel.FirstOrDefault(id => id.Id == contratoModel.ClienteId);
                cbSoftware.SelectedItem = softListModel.FirstOrDefault(id => id.Id == contratoModel.SoftwareId);
                cbStatus.SelectedItem = statusListModel.Where(id => id.Id == contratoModel.SituacaoId);
                txbValor.Text = contratoModel.Valor.ToString("C2");
                txbParcelas.Text = contratoModel.Parcelas.ToString();
                txbValorParcela.Text = contratoModel.ValorParcela.ToString("C2");

            }


        }

        private void LoadDGVIncisos(int clausulaId)
        {
            incisoListModel = _incisosServices.GetAllByClausula(clausulaId);

            DataTable tableIncisos = GetTableIncisos();
            GetRowIncisos(tableIncisos);
            dgvIncisos.DataSource = tableIncisos;
            ConfigDGVIncicos();

        }

        private DataTable GetTableIncisos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Numero", typeof(string));
            table.Columns.Add("Termo", typeof(string));

            return table;
        }

        private void GetRowIncisos(DataTable tableIncisos)
        {
            if (incisoListModel.Any())
            {
                //int indexInciso = 1;
                foreach (var item in incisoListModel)
                {
                    DataRow row = tableIncisos.NewRow();

                    row["Id"] = item.Id;
                    row["Numero"] = clausulaModel.Numero + "." + item.Numero;
                    row["Termo"] = item.Termo;



                    tableIncisos.Rows.Add(row);
                }
            }
        }

        private void ConfigDGVIncicos()
        {
            dgvIncisos.RowTemplate.Height = 100;
            dgvIncisos.Columns["Id"].Visible = false;
            dgvIncisos.Columns["Numero"].Width = 60;
            dgvIncisos.Columns["Numero"].HeaderText = "Num.";
            dgvIncisos.Columns["Termo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvIncisos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvIncisos.RowTemplate.Height = 60;

        }

        private void LoadDGVClausulas()
        {
            clausulaListModel = _clausulasServices.GetAllByContratoId(contratoId);
            DataTable tableClausulas = GetTableClausulas();
            GetRowClausulas(tableClausulas);
            dgvClausulas.DataSource = tableClausulas;
            ConfigDGVClausulas();


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
                //int indexClausula = 1;
                foreach (var item in clausulaListModel)
                {

                    DataRow row = tableClausulas.NewRow();

                    row["Id"] = item.Id;
                    row["Clausula"] = GetOrdinal.GetOrd(item.Numero).ToUpper();
                    row["Titulo"] = item.Titulo;

                    tableClausulas.Rows.Add(row);


                }
            }
        }

        private void ConfigDGVClausulas()
        {
            dgvClausulas.Columns["Id"].Visible = false;
            dgvClausulas.Columns["Clausula"].Width = 250; //CLÁUSULA PRIMEIRA... DADA PELO INDEX
            dgvClausulas.Columns["Clausula"].HeaderText = "Cláusula";
            dgvClausulas.Columns["Titulo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //DO OBJETO... OBIRGAÇÕES DO CONTRATANTE...
            dgvClausulas.Columns["Titulo"].HeaderText = "Título";


        }


        private void dgvClausulas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClausulas.CurrentRow != null)
            {
                clausulaModel = _clausulasServices.GetById(int.Parse(dgvClausulas.CurrentRow.Cells[0].Value.ToString()));
                LoadDGVIncisos(clausulaModel.Id);
                //btnAddInciso.Enabled = true;
            }

        }


        private void dgvClausulas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clausulaContextMenu.Show(MousePosition);
            }
        }
        private void btnAddClausula_Click(object sender, EventArgs e)
        {
            ClausulaAddForm clausulaAddForm = new ClausulaAddForm(contratoId, 0);
            clausulaAddForm.ShowDialog();
            LoadFormFields();
            LoadDGVClausulas();
        }
        private void editarClausulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int clausulaId = int.Parse(dgvClausulas.CurrentRow.Cells[0].Value.ToString());
            ClausulaAddForm clausulaAddForm = new ClausulaAddForm(contratoId, clausulaId);
            clausulaAddForm.ShowDialog();
            LoadFormFields();
            LoadDGVClausulas();
        }
        private void removerClausulaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int clausulaId = int.Parse(dgvClausulas.CurrentRow.Cells[0].Value.ToString());
            incisoListModel = _incisosServices.GetAllByClausula(clausulaId);
            if (incisoListModel.Any())
            {
                MessageBox.Show("Não é possível remover esta cláusula.\n Ela possui termos anexos.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation); ;
            }
            else
            {
                var result = MessageBox.Show($"Deseja remover a cláusula \"{dgvClausulas.CurrentRow.Cells[1].Value.ToString().ToUpper()}\"?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {

                        _clausulasServices.Delete(clausulaId);
                        MessageBox.Show("Clausula removida com sucesso");
                        LoadDGVClausulas();
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message, ex.InnerException);
                    }
                }
            }
        }


        private void dgvIncisos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                incisoContextMenu.Show(MousePosition);
            }
        }
        private void btnAddInciso_Click(object sender, EventArgs e)
        {
            IncisoAddForm incisoAddForm = new IncisoAddForm(clausulaModel.Id, 0);
            incisoAddForm.ShowDialog();
            LoadFormFields();
            LoadDGVIncisos(clausulaModel.Id);
        }
        private void editarIncisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int incisoId = int.Parse(dgvIncisos.CurrentRow.Cells[0].Value.ToString());
            IncisoAddForm incisoAddForm = new IncisoAddForm(clausulaModel.Id, incisoId);
            incisoAddForm.ShowDialog();
            LoadFormFields();
            LoadDGVIncisos(clausulaModel.Id);
        }
        private void removerIncisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int incisoId = int.Parse(dgvIncisos.CurrentRow.Cells[0].Value.ToString());
            var result = MessageBox.Show($"Deseja remover o termo \"{dgvIncisos.CurrentRow.Cells[1].Value.ToString()}\"?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {

                    _incisosServices.Delete(incisoId);
                    MessageBox.Show("Termo removido com sucesso");
                    LoadDGVIncisos(clausulaModel.Id);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
