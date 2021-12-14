using DomainLayer.Enderecos;
using DomainLayer.Fabrica;

using InfraStructure;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.ContatosFabrica;
using InfraStructure.Repository.EnderecosFabrica;
using InfraStructure.Repository.Estados;
using InfraStructure.Repository.Fabrica;
using InfraStructure.Repository.TelefonesContatosFabrica;

using MLicencas.FormViews.Contatos;
using MLicencas.FormViews.Enderecos;

using ServiceLayer.CommonServices;

using ServicesLayer.Cidades;
using ServicesLayer.ContatosFabricaServices;
using ServicesLayer.EnderecosFabricaServices;
using ServicesLayer.Estados;
using ServicesLayer.Fabrica;
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

namespace MLicencas.FormViews.Fabrica
{
    public partial class FabricaFormView : Form
    {
        private int indexDgvContatos;
        private int indexDgvEnderecos;
        private MainView MainView;

        //SERVICES
        private QueryStringServices _querysString;
        private FabricaServices _fabricaServices;
        private EnderecosFabricaServices _enderecoServices;
        private ContatosFabricaServices _contatosServices;
        private TelefonesContatosFabricaServices _telefoneContatos;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;


        //MODELS
        private IFabricaModel fabricaModel;
        private IEnderecoFabricaModel endFabModel = new EnderecoFabricaModel();
        private IContatoFabricaModel contFabModel = new ContatoFabricaModel();
        private IEnumerable<IEnderecoFabricaModel> enderecosListModel;
        private IEnumerable<IContatoFabricaModel> contatosListModel = new List<IContatoFabricaModel>();

        public FabricaFormView()
        {
            LoadServices();
            InitializeComponent();
            this.MainView = this.Parent as MainView;
            LoadModels();
            LoadDgvEnderecos();
            LoadDgvContatos();

        }


        #region CONTATOS

        //EVENTOS DATA GRID
        private void dgvContatosFabrica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex != dgvContatosFabrica.NewRowIndex)
            {

                e.Value = !string.IsNullOrEmpty(e.Value.ToString()) ? string.Format(@"{0:\(00\) 00000\-0000", Int64.Parse(e.Value.ToString())) : "";
            }
        }
        private void dgvContatosFabrica_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexDgvContatos = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                cMenuContatos.Show(MousePosition);
            }

        }
        private void dgvContatosFabrica_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainView.CheckPermissoes(editarTSMIContatos.Tag))
            {

            }
            else
            {
                MessageBox.Show("Usuário sem permissão para editar dados.", this.Text);
            }
        }
        
        //EVENTOS TOOLSTRIPMENU
        private void editarTSMIContatos_Click(object sender, EventArgs e)
        {

        }
        
        //LOADS DATAGRID
        private void LoadDgvContatos()
        {
            DataTable tableContatos = ModelaTableContatos();
            DataRow row = ModelaRowContatos(tableContatos, contatosListModel);
            dgvContatosFabrica.DataSource = tableContatos;
            ConfigDGVContatos();
        }
        private DataTable ModelaTableContatos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Telefone", typeof(string));

            return table;
        }
        private DataRow ModelaRowContatos(DataTable tableContatos, IEnumerable<IContatoFabricaModel> contatosListModel)
        {
            IEnumerable<ITelefoneContatoFabricaModel> telListModel = new List<ITelefoneContatoFabricaModel>();
            
            DataRow row = null;
            if (contatosListModel.Any())
            {
                foreach (var contato in contatosListModel)
                {
                    telListModel = _telefoneContatos.GetAllByContatoId(contato.Id);
                    row = tableContatos.NewRow();
                    row["Id"] = contato.Id;
                    row["Nome"] = contato.Nome;
                    row["Telefone"] = telListModel.Any() ? telListModel.FirstOrDefault().Numero : string.Empty;

                    tableContatos.Rows.Add(row);
                }
            }
            return row;
        }
        private void ConfigDGVContatos()
        {
            dgvContatosFabrica.Columns["Id"].Visible = false;
            dgvContatosFabrica.Columns["Nome"].Width = 120;
            dgvContatosFabrica.Columns["Telefone"].Width = 100;
        }

        private void btnAddCont_Click(object sender, EventArgs e)
        {
            AddContato(fabricaModel.Id);
        }

        private void AddContato(int fabricaId)
        {
            contFabModel.FabricaId = this.fabricaModel.Id;
            ContatoAddForm contatoForm = new ContatoAddForm(0, contFabModel);
            contatoForm.ShowDialog();
            LoadDgvContatos();
        }




        #endregion

        #region ENDEREÇOS

        //EVENTOS DATA GRID
        private void dgvEnderecosFabrica_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexDgvEnderecos = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                cMenuEndereco.Show(MousePosition);
            }
        }
        private void dgvEnderecosFabrica_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MainView.CheckPermissoes(editarTSMIEndereco.Tag))
            {
                EditEndereco(int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString()));
            }
            else
            {
                MessageBox.Show("Usuário sem permissão para editar dados.", this.Text);
            }
        }
        private void dgvEnderecosFabrica_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            if ((e.ColumnIndex == 3) && (e.RowIndex != dgvEnderecosFabrica.NewRowIndex))
            {
                e.Value = string.Format(@"{0:00\.000\-000}", Int64.Parse(e.Value.ToString()));
            }
        }
        
        
        //EVENTOS BUTTONS
        private void btnAddEnd_Click(object sender, EventArgs e)
        {

            AddEndereco(this.fabricaModel.Id);

        }
        private void btnRemEnd_Click(object sender, EventArgs e)
        {
            if (dgvContatosFabrica.CurrentRow != null)
            {
                RemoverEndereco(int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString()));
            }
        }

        
        //EVENTOS TOOLSTRIPMENU
        private void adicionarTSMIEndereco_Click(object sender, EventArgs e)
        {
            AddEndereco(this.fabricaModel.Id);
        }
        private void editarTSMIEndereco_Click(object sender, EventArgs e)
        {
            EditEndereco(int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString()));
        }
        private void removerTSMIEndereco_Click(object sender, EventArgs e)
        {
            RemoverEndereco(int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString()));
        }

        //LOADS DATAGRID
        private void LoadDgvEnderecos()
        {

            DataTable tableEnderecos = ModelaTableEnderecos();
            DataRow row = ModelaRowEnderecos(tableEnderecos, enderecosListModel);
            dgvEnderecosFabrica.DataSource = tableEnderecos;
            ConfigDGVEnderecos();

        }
        private DataTable ModelaTableEnderecos()
        {

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Logradouro", typeof(string));
            table.Columns.Add("Numero", typeof(string));
            table.Columns.Add("Cep", typeof(string));
            table.Columns.Add("CidadeId", typeof(int));
            table.Columns.Add("UfId", typeof(int));

            table.Columns.Add("Cidade", typeof(string));
            table.Columns.Add("Uf", typeof(string));

            return table;
        }
        private DataRow ModelaRowEnderecos(DataTable tableEnderecos, IEnumerable<IEnderecoFabricaModel> enderecosListModel)
        {

            DataRow row = null;
            if (enderecosListModel.Any())
            {
                foreach (var endereco in enderecosListModel)
                {
                    row = tableEnderecos.NewRow();

                    row["Id"] = endereco.Id;
                    row["Logradouro"] = endereco.Logradouro;
                    row["Numero"] = endereco.Numero;
                    row["Cep"] = endereco.Cep;
                    row["CidadeId"] = endereco.CidadeId;
                    row["UfId"] = endereco.UfId;
                    row["Cidade"] = _cidadesServices.GetById(endereco.CidadeId).Nome;
                    row["Uf"] = _estadosServices.GetById(endereco.UfId).Uf;

                    tableEnderecos.Rows.Add(row);
                }
            }
            return row;
        }
        private void ConfigDGVEnderecos()
        {

            dgvEnderecosFabrica.Columns["Id"].Visible = false;
            dgvEnderecosFabrica.Columns["Logradouro"].Width = 150;
            dgvEnderecosFabrica.Columns["Numero"].Width = 30;
            dgvEnderecosFabrica.Columns["Numero"].HeaderText = "Nº.";
            dgvEnderecosFabrica.Columns["Cep"].Width = 80;
            dgvEnderecosFabrica.Columns["Cidade"].Width = 100;
            dgvEnderecosFabrica.Columns["Uf"].Width = 30;
            dgvEnderecosFabrica.Columns["CidadeId"].Visible = false;
            dgvEnderecosFabrica.Columns["UfId"].Visible = false;

        }

        
        //MÉTODOS ENDEREÇOS
        private void AddEndereco(int fabricaId)
        {
            this.endFabModel.FabricaId = fabricaId;
            EnderecoAddForm endForm = new EnderecoAddForm(0, this.endFabModel);
            endForm.MdiParent = MainView;
            endForm.ShowDialog();
            LoadModels();
            LoadDgvEnderecos();
        }
        private void EditEndereco(int enderecoId)
        {
            this.endFabModel = _enderecoServices.GetById(enderecoId);
            EnderecoAddForm endForm = new EnderecoAddForm(endFabModel.Id, endFabModel);
            endForm.MdiParent = MainView;
            endForm.ShowDialog();
            LoadModels();
            LoadDgvEnderecos();
        }
        private void RemoverEndereco(int enderecoId)
        {
            this.endFabModel = _enderecoServices.GetById(int.Parse(dgvEnderecosFabrica.CurrentRow.Cells[0].Value.ToString()));

            var result = MessageBox.Show($"Tem certeza que quer apagar o registro \n{endFabModel.Logradouro}?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
            if (result == DialogResult.Yes)
            {

                try
                {
                    _enderecoServices.Delete(this.endFabModel.Id);
                    MessageBox.Show("Registro apagado com sucesso.", this.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível apagar o registro.\nMessageError: {ex.Message}\nInnerException: {ex.InnerException}\nStackTrace: {ex.StackTrace}", this.Text);
                }
            }
            LoadModels();
            LoadDgvEnderecos();
        }

        #endregion


        private void LoadModels()
        {
            fabricaModel = new FabricaModel();
            fabricaModel = _fabricaServices.GetFabrica();

            enderecosListModel = _enderecoServices.GetAll();
            enderecosListModel = enderecosListModel.Where(fabricaId => fabricaId.FabricaId == fabricaModel.Id);

            contatosListModel = _contatosServices.GetAll();
            contatosListModel = contatosListModel.Where(fabricaId => fabricaId.FabricaId == fabricaModel.Id);

        }

        private void LoadServices()
        {
            _querysString = new QueryStringServices(new QueryString());
            _fabricaServices = new FabricaServices(new FabricaRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());
            _enderecoServices = new EnderecosFabricaServices(new EnderecoFabricaRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contatosServices = new ContatosFabricaServices(new ContatoFabricaRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneContatos = new TelefonesContatosFabricaServices(new TelefoneContatoFabricaRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_querysString.GetQueryApp()), new ModelDataAnnotationCheck());

        }



        private void FabricaFormView_Load(object sender, EventArgs e)
        {

            LoadFields();
            LoadDgvEnderecos();
            LoadDgvContatos();
        }

        private void LoadFields()
        {
            if (this.fabricaModel.Id != 0)
            {
                txbId.Text = fabricaModel.Id.ToString();
                txbNomeFantasia.Text = fabricaModel.NomeFantasia;
                txbRazaoSocial.Text = fabricaModel.RazaoSocial;
                mtxbCnpj.Text = fabricaModel.Cnpj;
                txbIe.Text = fabricaModel.Ie;
                txbEmail.Text = fabricaModel.Email;
                txbWebSite.Text = fabricaModel.WebSite;

                LodButtonsPermitions();

            }
            else
            {
                DeableButtons();
            }
        }

        private void DeableButtons()
        {
            cMenuContatos.Enabled = false;
            cMenuEndereco.Enabled = false;

            btnAddCont.Enabled = false;
            btnRemCont.Enabled = false;

            btnAddEnd.Enabled = false;
            btnRemEnd.Enabled = false;
        }

        private void LodButtonsPermitions()
        {
            adicionarTSMIContatos.Enabled = MainView.CheckPermissoes(adicionarTSMIContatos.Tag);
            btnAddCont.Enabled = MainView.CheckPermissoes(btnAddCont.Tag);

            editarTSMIContatos.Enabled = MainView.CheckPermissoes(editarTSMIContatos.Tag);

            removerTSMIContatos.Enabled = MainView.CheckPermissoes(removerTSMIContatos.Tag);
            btnRemCont.Enabled = MainView.CheckPermissoes(btnRemCont.Tag);

            adicionarTSMIEndereco.Enabled = MainView.CheckPermissoes(adicionarTSMIEndereco.Tag);
            btnAddEnd.Enabled = MainView.CheckPermissoes(btnAddEnd.Tag);

            editarTSMIEndereco.Enabled = MainView.CheckPermissoes(editarTSMIEndereco.Tag);

            removerTSMIContatos.Enabled = MainView.CheckPermissoes(removerTSMIEndereco.Tag);
            btnRemEnd.Enabled = MainView.CheckPermissoes(btnRemEnd.Tag);
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            this.fabricaModel = new FabricaModel();
            fabricaModel.NomeFantasia = txbNomeFantasia.Text;
            fabricaModel.RazaoSocial = txbRazaoSocial.Text;
            fabricaModel.Cnpj = mtxbCnpj.Text;
            fabricaModel.Ie = txbIe.Text;
            fabricaModel.Email = txbEmail.Text;
            fabricaModel.WebSite = txbWebSite.Text;
            fabricaModel.Id = string.IsNullOrEmpty(txbId.Text) ? 0 : int.Parse(txbId.Text);

            if (this.fabricaModel.Id != 0)
            {
                //UPDATE
                try
                {
                    _fabricaServices.Edit(this.fabricaModel);
                    MessageBox.Show("Dados atualizados com sucesso", this.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível atualizar os dados da fábria.\nMessage:{ex.Message}\nInnerException:{ex.InnerException}\nStackTrace:{ex.StackTrace}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                //SAVE
                try
                {

                    this.fabricaModel = _fabricaServices.Add(this.fabricaModel);
                    MessageBox.Show("Dados salvos com suceso", this.Text);
                    LoadFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível salvar os dados da fábria.\n{ex.Message}\n{ex.InnerException}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
