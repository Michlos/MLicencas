using DomainLayer.Clientes.Contatos;
using DomainLayer.Clientes.Telefones;
using DomainLayer.Fabrica;

using InfraStructure;
using InfraStructure.Repository.ContatosClientes;
using InfraStructure.Repository.ContatosFabrica;
using InfraStructure.Repository.TelefonesContatosClientes;
using InfraStructure.Repository.TelefonesContatosFabrica;

using ServiceLayer.CommonServices;

using ServicesLayer.ContatosClientes;
using ServicesLayer.ContatosFabricaServices;
using ServicesLayer.TelefonesContatosClientes;
using ServicesLayer.TelefonesContatosFabricaServices;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Contatos
{
    public partial class ContatoAddForm : Form
    {
        ///ContatoFabrica ou ContatoCliente
        private object TModel;

        //PROPERTIES
        private int fabricaId, clienteId, contatoId;

        //SERVICES
        private QueryStringServices _queryString;

        private ContatosFabricaServices _contatoFabServices;
        private TelefonesContatosFabricaServices _telFabServices;

        private ContatosClientesServices _contatoCliServices;
        private TelefonesContatosClientesServices _telCliServices;



        //MODELS
        private IContatoFabricaModel contFabModel = new ContatoFabricaModel();
        private ITelefoneContatoFabricaModel telFabModel = new TelefoneContatoFabricaModel();
        private IEnumerable<ITelefoneContatoFabricaModel> telFabListModel = new List<ITelefoneContatoFabricaModel>();

        private IContatoClienteModel contCliModel = new ContatoClienteModel();
        private ITelefoneContatoClienteModel telCliModel = new TelefoneContatoClienteModel();
        private IEnumerable<ITelefoneContatoClienteModel> telCliListModel = new List<ITelefoneContatoClienteModel>();


        public ContatoAddForm(int contatoId, object TModel)
        {
            LoadServices();

            InitializeComponent();

            this.TModel = TModel;
            this.contatoId = contatoId;
            LoadFields();

        }

        private void LoadFields()
        {
            if (contatoId != 0)
            {
                if (TModel.GetType() == contFabModel.GetType())
                {
                    //CONTATO FÁBRICA
                    txbId.Text = (TModel as IContatoFabricaModel).Id.ToString();
                    txbNome.Text = (TModel as IContatoFabricaModel).Nome;
                    txbCargo.Text = (TModel as IContatoFabricaModel).Cargo;
                    txbEmail.Text = (TModel as IContatoFabricaModel).Email;

                    telFabListModel = _telFabServices.GetAllByContatoId(contatoId);
                }
                else
                {
                    //CONTATO CLIENTE
                    txbId.Text = (TModel as IContatoClienteModel).Id.ToString();
                    txbNome.Text = (TModel as IContatoClienteModel).Nome;
                    txbCargo.Text = (TModel as IContatoClienteModel).Cargo;
                    txbEmail.Text = (TModel as IContatoClienteModel).Email;

                    telCliListModel = _telCliServices.GetAllByContatoId(contatoId);
                }
            }
        }

        private void ContatoAddForm_Load(object sender, EventArgs e)
        {
            LoadLocalPoperties();
            LoadDGVTelefones();

        }

        private void LoadLocalPoperties()
        {
            if (TModel.GetType() == contFabModel.GetType())
            {
                this.fabricaId = (TModel as IContatoFabricaModel).FabricaId;
            }
            else
            {
                this.contatoId = (TModel as IContatoClienteModel).ClienteId;
            }
        }

        private void LoadDGVTelefones()
        {
            if (contatoId != 0)
            {
                grbTelefones.Enabled = true;
            }
            IEnumerable<object> TListModelTel;
            if (TModel.GetType() == contFabModel.GetType())
            {
                TListModelTel = telFabListModel;
            }
            else
            {
                TListModelTel = telCliListModel;
            }
            

            DataTable tableContatos = ModelaTableTelefones();
            DataRow row = ModelaRowTelefones(tableContatos, TListModelTel);
            dgvTelefonesContato.DataSource = tableContatos;
            ConfigDGVTelefones();

        }

        private void ConfigDGVTelefones()
        {
            dgvTelefonesContato.Columns["Id"].Visible = false;
            dgvTelefonesContato.Columns["Operadora"].Width = 40;
            dgvTelefonesContato.Columns["Operadora"].HeaderText = "Op.";
            dgvTelefonesContato.Columns["Numero"].Width = 80;
        }

        private DataRow ModelaRowTelefones(DataTable tableContatos, IEnumerable<object> listModelTel)
        {
            DataRow row = null;
            if (listModelTel.Any())
            {

                foreach (var contato in listModelTel)
                {
                    row = tableContatos.NewRow();
                    
                    if (contato.GetType() == telFabModel.GetType())
                    {
                        row["Id"] = (contato as ITelefoneContatoFabricaModel).Id;
                        row["Operadora"] = (contato as ITelefoneContatoFabricaModel).Operadora;
                        row["Numero"] = (contato as ITelefoneContatoFabricaModel).Numero;
                    }
                    else
                    {
                        row["Id"] = (contato as ITelefoneContatoClienteModel).Id;
                        row["Operadora"] = (contato as ITelefoneContatoClienteModel).Operadora;
                        row["Numero"] = (contato as ITelefoneContatoClienteModel).Numero;
                    }
                    tableContatos.Rows.Add(row);
                }
            }
            return row;
        }

        private DataTable ModelaTableTelefones()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Operadora", typeof(string));
            table.Columns.Add("Numero", typeof(string));

            return table;
        }

        private void dgvTelefonesContato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != dgvTelefonesContato.NewRowIndex)
            {
                e.Value = string.Format(@"{0:\(00\) 00000\-0000", Int64.Parse(e.Value.ToString()));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TModel.GetType() == contFabModel.GetType())
            {
                //CONTATO FABRICA
                TModel = new ContatoFabricaModel();
                
                (TModel as IContatoFabricaModel).Nome = txbNome.Text;
                (TModel as IContatoFabricaModel).Cargo = txbCargo.Text;
                (TModel as IContatoFabricaModel).Email = txbEmail.Text;
                (TModel as IContatoFabricaModel).FabricaId = this.fabricaId;
                try
                {
                    TModel = _contatoFabServices.Add(TModel as IContatoFabricaModel);
                    this.contatoId = (TModel as IContatoFabricaModel).Id;
                    MessageBox.Show("Contato salvo com sucesso.", this.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível salvar os dados do contato.\nMessageError: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException} ", this.Text);
                    
                }
            }
            else
            {
                //CONTATO CLIENTE
                TModel = new ContatoClienteModel();
                (TModel as IContatoClienteModel).Nome = txbNome.Text;
                (TModel as IContatoClienteModel).Cargo = txbCargo.Text;
                (TModel as IContatoClienteModel).Email = txbEmail.Text;
                (TModel as IContatoClienteModel).ClienteId = this.clienteId;

                try
                {
                    TModel = _contatoCliServices.Add(TModel as IContatoClienteModel);
                    this.contatoId = (TModel as IContatoClienteModel).Id;
                    MessageBox.Show("Contato salvo com sucesso.", this.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível salvar os dados do contato.\nMessageError: {ex.Message}\nStackTrace: {ex.StackTrace}\nInnerException: {ex.InnerException} ", this.Text);

                }
            }
            LoadFields();
            LoadDGVTelefones();

        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());

            _contatoFabServices = new ContatosFabricaServices(new ContatoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telFabServices = new TelefonesContatosFabricaServices(new TelefoneContatoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            _contatoCliServices = new ContatosClientesServices(new ContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telCliServices = new TelefonesContatosClientesServices(new TelefoneContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
