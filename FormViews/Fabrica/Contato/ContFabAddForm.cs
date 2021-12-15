using DomainLayer.Fabrica;

using InfraStructure;
using InfraStructure.Repository.ContatosFabrica;
using InfraStructure.Repository.TelefonesContatosFabrica;

using MLicencas.FormViews.Fabrica.Contato.Telefone;

using ServiceLayer.CommonServices;

using ServicesLayer.ContatosFabricaServices;
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

namespace MLicencas.FormViews.Fabrica.Contato
{
    public partial class ContFabAddForm : Form
    {
        private int contatoId, fabricaId;

        //SERVICES
        private QueryStringServices _queryString;
        private ContatosFabricaServices _contatosServices;
        private TelefonesContatosFabricaServices _telefoneServices;

        //MODELS LIST MODELS
        private IContatoFabricaModel contatoModel = new ContatoFabricaModel();
        private IEnumerable<ITelefoneContatoFabricaModel> telefoneListModel = new List<ITelefoneContatoFabricaModel>();


        public ContFabAddForm(int contatoId, int fabricaId)
        {
            LoadServices();
            InitializeComponent();
            this.contatoId = contatoId;
            this.fabricaId = fabricaId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contatosServices = new ContatosFabricaServices(new ContatoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefonesContatosFabricaServices(new TelefoneContatoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void ContFabAddForm_Load(object sender, EventArgs e)
        {
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (contatoId != 0)
            {
                contatoModel = _contatosServices.GetById(contatoId);

                txbId.Text = contatoModel.Id.ToString();
                txbNome.Text = contatoModel.Nome;
                txbCargo.Text = contatoModel.Cargo;
                txbEmail.Text = contatoModel.Email;

                LoadDGVTelefones();
                gbTelefones.Enabled = true;
            }
            else
            {
                gbTelefones.Enabled = false;
            }
        }

        private void LoadDGVTelefones()
        {
            telefoneListModel = _telefoneServices.GetAllByContatoId(contatoId);
            DataTable tableTelefones = ModelaDataTable();
            DataRow row = ModelaDataRow(tableTelefones);
            dgvTelefonesContato.DataSource = tableTelefones;
            ConfiguraDGVTelefones();
        }

        private void ConfiguraDGVTelefones()
        {
            dgvTelefonesContato.Columns["Id"].Visible = false;
            dgvTelefonesContato.Columns["Operadora"].Width = 35;
            dgvTelefonesContato.Columns["Operadora"].HeaderText = "Op.";
            dgvTelefonesContato.Columns["Numero"].Width = 95;
        }

        private DataRow ModelaDataRow(DataTable tableTelefones)
        {
            DataRow row = null;
            if (telefoneListModel.Any())
            {
                foreach (var telefone in telefoneListModel)
                {
                    row = tableTelefones.NewRow();

                    row["Id"] = telefone.Id;
                    row["Operadora"] = telefone.Operadora;
                    row["Numero"] = telefone.Numero;

                    tableTelefones.Rows.Add(row);
                }
            }

            return row;
        }

        private DataTable ModelaDataTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Operadora", typeof(string));
            table.Columns.Add("Numero", typeof(string));

            return table;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            contatoModel.Nome = txbNome.Text;
            contatoModel.Cargo = txbCargo.Text;
            contatoModel.Email = txbEmail.Text;
            contatoModel.FabricaId = fabricaId;


            if (contatoId != 0)
                UpdateContato();
            else
                AddContato();
        }

        private void AddContato()
        {
            try
            {

                contatoModel = _contatosServices.Add(contatoModel);
                contatoId = contatoModel.Id;
                MessageBox.Show("Contato Adicionado com sucesso.", this.Text);
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível adicionar Contato.\nMessageError: {e.Message}\nStackTrace: {e.StackTrace}\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void UpdateContato()
        {
            try
            {
                _contatosServices.Edit(contatoModel);
                MessageBox.Show("Contato Atualizado com sucesso.", this.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível Editar Contato.\nMessageError: {e.Message}\nStackTrace: {e.StackTrace}\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void btnAddTel_Click(object sender, EventArgs e)
        {
            TelFabAddForm telForm = new TelFabAddForm(0, contatoId);
            telForm.ShowDialog();
            LoadDGVTelefones();
        }

        private void btnRemTel_Click(object sender, EventArgs e)
        {
            DeleteTelefone();
        }

        private void DeleteTelefone()
        {
            ITelefoneContatoFabricaModel telModel = new TelefoneContatoFabricaModel();
            //int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString())
            telModel = _telefoneServices.GetById(int.Parse(dgvTelefonesContato.CurrentRow.Cells[0].Value.ToString()));
            var result = MessageBox.Show($"Tem certeza que quer apagar o número {telModel.Numero}?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _telefoneServices.Delete(telModel.Id);
                    MessageBox.Show("Telefone apagado com sucesso.", this.Text);
                    LoadDGVTelefones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o registro.\n\nErrorMessage: {ex.Message}\n\nInnerException: {ex.InnerException}\n\nStackTrace: {ex.StackTrace}", this.Text);
                }
            }
        }

        private void dgvTelefonesContato_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                telefoneContextMenu.Show(MousePosition);
            }
        }

        private void dgvTelefonesContato_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 2) && (e.RowIndex != dgvTelefonesContato.NewRowIndex))
            {
                if (e.Value.ToString().Length == 11)
                {
                    //CELULAR
                    e.Value = string.Format(@"{0:(00) 0 0000-0000}", Int64.Parse(e.Value.ToString()));
                }
                else
                {
                    e.Value = string.Format(@"{0:(00) 0000-0000}", Int64.Parse(e.Value.ToString()));

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
