using DomainLayer.Clientes;
using DomainLayer.Clientes.Contatos;
using DomainLayer.Clientes.Enderecos;
using DomainLayer.Enderecos;
using DomainLayer.Situacao;

using InfraStructure;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.ContatosClientes;
using InfraStructure.Repository.EnderecosClientes;
using InfraStructure.Repository.Estados;
using InfraStructure.Repository.Situacoes;
using InfraStructure.Repository.TelefonesContatosClientes;

using MLicencas.FormViews.Clientes.Endereco;

using ServiceLayer.CommonServices;

using ServicesLayer.Cidades;
using ServicesLayer.ClientesServices;
using ServicesLayer.ContatosClientes;
using ServicesLayer.EnderecosClientes;
using ServicesLayer.Estados;
using ServicesLayer.SituacoesServices;
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

namespace MLicencas.FormViews.Clientes
{
    public partial class ClienteAddForm : Form
    {
        private int clienteId;

        //SERVICES
        QueryStringServices _queryString;
        ClientesServices _clientesServices;
        EnderecosClientesServices _enderecosServices;
        CidadesServices _cidadesServices;
        EstadosServices _estadosServices;
        ContatosClientesServices _contatoServices;
        TelefonesContatosClientesServices _telefoneServices;
        SituacoesServices _statusServices;

        //MODELS LISTMODELS
        private IClienteModel clienteModel = new ClienteModel();
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();
        private IEnumerable<IEnderecoClienteModel> endListModel = new List<IEnderecoClienteModel>();
        private IEnumerable<IContatoClienteModel> contListModel = new List<IContatoClienteModel>();


        public ClienteAddForm(int clienteId)
        {
            LoadServices();
            InitializeComponent();
            this.clienteId = clienteId;
            LoadModels();
        }

        private void LoadModels()
        {
            statusListModel = _statusServices.GetAll();

            if (clienteId != 0){
                clienteModel = _clientesServices.GetById(clienteId);
                contListModel = _contatoServices.GetAllByClienteId(clienteId);
                endListModel = _enderecosServices.GetAllByClienteId(clienteId);
            }
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _enderecosServices = new EnderecosClientesServices(new EnderecoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contatoServices = new ContatosClientesServices(new ContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _telefoneServices = new TelefonesContatosClientesServices(new TelefoneContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            

        }

        private void ClienteAddForm_Load(object sender, EventArgs e)
        {
            LoadPermitions();
            LoadCBStatus();
            LoadFormFields();
            LoadDGVEndereco();
            LoadDGVContato();
        }

        //DADOS CONTATOS
        private void LoadDGVContato()
        {
            DataTable tableContatos = GetTableContatos();
            GetRowContatos(tableContatos);
            dgvContato.DataSource = tableContatos;
            ConfigDGVContatos();

        }
        private DataTable GetTableContatos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Telefone", typeof(string));

            return table;
        }
        private void GetRowContatos(DataTable tableContatos)
        {
            if (contListModel.Any())
            {
                foreach (var item in contListModel)
                {
                    DataRow row = tableContatos.NewRow();

                    row["Id"] = item.Id;
                    row["Nome"] = item.Nome;
                    row["Telefone"] = _telefoneServices.GetAllByContatoId(item.Id).FirstOrDefault().Numero;

                    tableContatos.Rows.Add(row);
                }
            }
        }
        private void ConfigDGVContatos()
        {
            dgvContato.Columns["Id"].Visible = false;
            dgvContato.Columns["Nome"].Width = 150;
            dgvContato.Columns["Telefone"].Width = 100;

        }


        //DADOS ENDEREÇOS
        private void LoadDGVEndereco()
        {
            DataTable tableEnderecos = GetTableEnderecos();
            DataRow row = GetRowEnderecos(tableEnderecos);
            dgvEndereco.DataSource = tableEnderecos;
            ConfigDGVEnderecos();
        }
        private DataTable GetTableEnderecos()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Logradouro", typeof(string));
            table.Columns.Add("Numero", typeof(string));
            table.Columns.Add("Cep", typeof(string));
            table.Columns.Add("Cidade", typeof(string));
            table.Columns.Add("Uf", typeof(string));
            return table;
        }
        private DataRow GetRowEnderecos(DataTable tableEnderecos)
        {
            
            DataRow row = null;
            if (endListModel.Any())
            {
                foreach (var item in endListModel)
                {
                    row = tableEnderecos.NewRow();

                    row["Id"] = item.Id;
                    row["Logradouro"] = item.Logradouro;
                    row["Numero"] = item.Numero;
                    row["Cep"] = item.Cep;
                    row["Cidade"] = _cidadesServices.GetById(item.CidadeId).Nome;
                    row["Uf"] = _estadosServices.GetById(item.UfId).Uf;

                    tableEnderecos.Rows.Add(row);
                }
            }
            return row;
        }
        private void ConfigDGVEnderecos()
        {
            dgvEndereco.Columns["Id"].Visible = false;
            dgvEndereco.Columns["Logradouro"].Width = 130;
            dgvEndereco.Columns["Numero"].Width = 40;
            dgvEndereco.Columns["Numero"].HeaderText = "Nº.";
            dgvEndereco.Columns["Cep"].Width = 80;
            dgvEndereco.Columns["Cidade"].Width = 100;
            dgvEndereco.Columns["Uf"].Width = 30;

        }




        private void LoadPermitions()
        {
            btnNovoCont.Enabled = MainView.CheckPermissoes(btnNovoCont.Tag);
            btnNovoEnd.Enabled = MainView.CheckPermissoes(btnNovoEnd.Tag);
            btnSave.Enabled = MainView.CheckPermissoes(btnSave.Tag);
            btnRemoveCont.Enabled = MainView.CheckPermissoes(btnRemoveCont.Tag);
            btnRemoveEnd.Enabled = MainView.CheckPermissoes(btnRemoveEnd.Tag);
        }

        private void LoadFormFields()
        {
            if (clienteId !=0)
            {
                gbEndereco.Enabled = true;
                gbContato.Enabled = true;

                txbId.Text = clienteModel.Id.ToString();
                txbNomeFantasia.Text = clienteModel.NomeFantasia;
                txbRazaoSocial.Text = clienteModel.RazaoSocial;
                mtxbCnpj.Text = clienteModel.Cnpj;
                mtxbIe.Text = clienteModel.Ie;
                txbEmail.Text = clienteModel.Email;
                txbSite.Text = clienteModel.WebSite;
                cbStatus.Text = statusListModel.Where(id => id.Id == clienteModel.SituacaoId).FirstOrDefault().Descricao;
            }
            else
            {
                cbStatus.Text = statusListModel.Where(status => status.Descricao == "Ativo").FirstOrDefault().Descricao;
                gbEndereco.Enabled = false;
                gbContato.Enabled = false;
            }
        }

        private void LoadCBStatus()
        {
            cbStatus.DataSource = statusListModel;
            cbStatus.DisplayMember = "Descricao";
            cbStatus.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clienteModel = new ClienteModel();
            clienteModel.NomeFantasia = txbNomeFantasia.Text;
            clienteModel.RazaoSocial = txbRazaoSocial.Text;
            clienteModel.Cnpj = mtxbCnpj.Text;
            clienteModel.Ie = mtxbIe.Text;
            clienteModel.Email = txbEmail.Text;
            clienteModel.WebSite = txbSite.Text;
            clienteModel.SituacaoId = (cbStatus.SelectedItem as ISituacaoModel).Id;
            clienteModel.Id = !string.IsNullOrEmpty(txbId.Text) ? int.Parse(txbId.Text) : 0;

            if (clienteId != 0)
            {
                UpdateCliente();
            }
            else
            {
                AddCliente();
            }
        }

        private void AddCliente()
        {
            try
            {
                clienteModel = _clientesServices.Add(clienteModel);
                MessageBox.Show("Cliente Adicionado com sucesso", this.Text);
                clienteId = clienteModel.Id;
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível adicionar cliente.\n\nErrorMessage: {e.Message}.\n\nStackTrace: {e.StackTrace}.\n\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void UpdateCliente()
        {
            try
            {
                _clientesServices.Edid(clienteModel);
                MessageBox.Show("Cliente Atualizado com sucesso", this.Text);

            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível atualizar os dados do cliente.\n\nErrorMessage: {e.Message}.\n\nStackTrace: {e.StackTrace}.\n\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void btnNovoEnd_Click(object sender, EventArgs e)
        {
            EndCliAddForm endForm = new EndCliAddForm(0, clienteId);
            endForm.ShowDialog();
            LoadModels();
            LoadDGVEndereco();
        }

        private void btnRemoveEnd_Click(object sender, EventArgs e)
        {
            int enderecoId = int.Parse(dgvEndereco.CurrentRow.Cells[0].Value.ToString());
            IEnderecoClienteModel endModel = _enderecosServices.GetById(enderecoId);

            var result = MessageBox.Show($"Tem certeza que deseja apagar o registro do logradouro {endModel.Logradouro}?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question );
            if (result == DialogResult.Yes)
            {
                DeleteEndereco(enderecoId);
            }


        }

        private void DeleteEndereco(int enderecoId)
        {
            try
            {
                _enderecosServices.Delete(enderecoId);
                MessageBox.Show("Registro apagado com sucesso.", this.Text);
                LoadModels();
                LoadDGVEndereco();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível apagar o registro de endereço selecionado.\n\nMessage Error: {e.Message}\n\n Inner Exception: {e.InnerException} \n\n StackTrace: {e.StackTrace}", this.Text);
            }
        }
    }
}
