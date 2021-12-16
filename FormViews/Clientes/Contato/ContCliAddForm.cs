using DomainLayer.Clientes.Contatos;
using DomainLayer.Clientes.Telefones;

using InfraStructure;
using InfraStructure.Repository.ContatosClientes;
using InfraStructure.Repository.TelefonesContatosClientes;

using MLicencas.FormViews.Clientes.Contato.Telefone;

using ServiceLayer.CommonServices;

using ServicesLayer.ContatosClientes;
using ServicesLayer.TelefonesContatosClientes;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Clientes.Contato
{
    public partial class ContCliAddForm : Form
    {
        private int contatoId, clienteId;

        //SERVICES
        private QueryStringServices _queryString;
        private ContatosClientesServices _contatosServices;
        private TelefonesContatosClientesServices _telefoneServices;

        //MODELS AND LISTMODELS
        private IContatoClienteModel contatoModel;
        private IEnumerable<ITelefoneContatoClienteModel> telListModel = new List<ITelefoneContatoClienteModel>();


        public ContCliAddForm(int contatoId, int clienteId)
        {
            LoadServices();
            InitializeComponent();
            this.contatoId = contatoId;
            this.clienteId = clienteId;
        }



        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contatosServices = new ContatosClientesServices(new ContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefonesContatosClientesServices(new TelefoneContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void ContCliAddForm_Load(object sender, EventArgs e)
        {
            CheckPermissions();
            LoadFormFields();
            LoadDGVTelefones();
        }

        private void CheckPermissions()
        {
            btnAddTel.Enabled = MainView.CheckPermissoes(btnAddTel.Tag);
            btnRemTel.Enabled = MainView.CheckPermissoes(btnRemTel.Tag);
            btnSave.Enabled = MainView.CheckPermissoes(btnSave.Tag);

            adicionarToolStripMenuItem.Enabled = MainView.CheckPermissoes(adicionarToolStripMenuItem.Tag);
            removerToolStripMenuItem.Enabled = MainView.CheckPermissoes(removerToolStripMenuItem.Tag);

        }

        private void LoadFormFields()
        {
            if (contatoId != 0)
            {
                contatoModel = _contatosServices.GetById(contatoId);
                telListModel = _telefoneServices.GetAllByContatoId(contatoId);
                gbTelefones.Enabled = true;

                txbId.Text = contatoModel.Id.ToString();
                txbNome.Text = contatoModel.Nome;
                txbCargo.Text = contatoModel.Cargo;
                txbEmail.Text = contatoModel.Email;

            }
            else
            {
                gbTelefones.Enabled = false;
            }
        }


        #region DGV TELEFONES

        private void LoadDGVTelefones()
        {
            DataTable tableTelefones = GetTableTelefones();
            GetRowTelefoes(tableTelefones);
            dgvTelefonesContato.DataSource = tableTelefones;
            ConfigDGVTelefones();
        }
        private DataTable GetTableTelefones()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Operadora", typeof(string));
            table.Columns.Add("Numero", typeof(string));

            return table;
        }
        private void GetRowTelefoes(DataTable tableTelefones)
        {
            if (telListModel.Any())
            {
                foreach (var item in telListModel)
                {
                    DataRow row = tableTelefones.NewRow();

                    row["Id"] = item.Id;
                    row["Operadora"] = item.Operadora;
                    row["Numero"] = item.Numero;

                    tableTelefones.Rows.Add(row);

                }
            }
        }
        private void ConfigDGVTelefones()
        {
            dgvTelefonesContato.Columns["Id"].Visible = false;
            dgvTelefonesContato.Columns["Operadora"].HeaderText = "Op.";
            dgvTelefonesContato.Columns["Operadora"].Width = 30;
            dgvTelefonesContato.Columns["Numero"].Width = 100;


        }
        private void dgvTelefonesContato_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                telefoneContextMenu.Show(MousePosition);
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            contatoModel = new ContatoClienteModel();

            contatoModel.Nome = txbNome.Text;
            contatoModel.Cargo = txbCargo.Text;
            contatoModel.Email = txbEmail.Text;
            contatoModel.ClienteId = clienteId;
            contatoModel.Id = !string.IsNullOrEmpty(txbId.Text) ? int.Parse(txbId.Text) : 0;

            if (contatoId != 0)
            {
                UpdateContato();
            }
            else
            {
                AddContato();
            }
        }

        private void AddContato()
        {
            try
            {
                contatoModel = _contatosServices.Add(contatoModel);
                contatoId = contatoModel.Id;
                MessageBox.Show("Contato adicionado com sucesso.", this.Text);
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possívle adicionar o contato.\n\nMessage Error: {e.Message}\n\nInner Exception: {e.InnerException}\n\nStack Trace: {e.StackTrace}", this.Text);
            }
        }
        private void UpdateContato()
        {
            try
            {
                _contatosServices.Edit(contatoModel);
                contatoId = contatoModel.Id;
                MessageBox.Show("Contato alterado com sucesso.", this.Text);

            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possívle Alterar os dados do contato.\n\nMessage Error: {e.Message}\n\nInner Exception: {e.InnerException}\n\nStack Trace: {e.StackTrace}", this.Text);
            }
        }



        private void btnAddTel_Click(object sender, EventArgs e)
        {
            AddTelContato(contatoId);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRemTel_Click(object sender, EventArgs e)
        {
            if (dgvTelefonesContato.CurrentRow != null)
            {
                int telefoneId = int.Parse(dgvTelefonesContato.CurrentRow.Cells[0].Value.ToString());
                ITelefoneContatoClienteModel telContato = _telefoneServices.GetById(telefoneId);
                var result = MessageBox.Show($"Tem certeza que desja apagar o número {telContato.Numero}?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    try
                    {

                        _telefoneServices.Delete(telefoneId);
                        MessageBox.Show("Telefone removido com sucesso.", this.Text);
                        LoadFormFields();
                        LoadDGVTelefones();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Não foi possível apagar o telefone do contato.\n\n{ex.Message} \n\n{ex.InnerException}\n\n{ex.StackTrace}", this.Text);
                    }
                }
            }
        }

        private void AddTelContato(int contatoId)
        {
            TelCliAddForm telAddForm = new TelCliAddForm(0, contatoId);
            telAddForm.ShowDialog();
            LoadFormFields();
            LoadDGVTelefones();
        }



    }
}
