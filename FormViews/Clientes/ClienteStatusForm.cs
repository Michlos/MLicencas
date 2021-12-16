using DomainLayer.Clientes;
using DomainLayer.Situacao;

using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Situacoes;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;
using ServicesLayer.SituacoesServices;

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
    public partial class ClienteStatusForm : Form
    {
        private int clienteId;

        //SERVICES
        private QueryStringServices _queryString;
        private ClientesServices _clientesServices;
        private SituacoesServices _statusServices;


        //MODELS AND LISTMODELS
        private IEnumerable<ISituacaoModel> statusListModel = new List<ISituacaoModel>();
        private IClienteModel clienteModel = new ClienteModel();
        private ISituacaoModel statusAtual = new SituacaoModel();

        public ClienteStatusForm(int clienteId)
        {
            LoadServices();
            InitializeComponent();
            this.clienteId = clienteId;
            LoadModels();
            LoadCBStatus();
            LoadFormFields();
        }

        private void LoadCBStatus()
        {
            cbStatus.DisplayMember = "Descricao";
            cbStatus.DataSource = statusListModel;
            cbStatus.SelectedIndex = -1;
        }

        private void LoadFormFields()
        {
            txbId.Text = this.clienteModel.Id.ToString();
            txbRazaoSocial.Text = this.clienteModel.RazaoSocial;
            mtxbCnpj.Text = this.clienteModel.Cnpj;
            cbStatus.SelectedItem = statusListModel.Where(id => id.Id == this.clienteModel.SituacaoId).FirstOrDefault();
            statusAtual = cbStatus.SelectedItem as ISituacaoModel;
        }

        private void LoadModels()
        {
            statusListModel = _statusServices.GetAll();
            clienteModel = _clientesServices.GetById(clienteId);
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _statusServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (!statusAtual.Equals(cbStatus.SelectedItem as ISituacaoModel))
            {
                var result = MessageBox.Show("Você alterou o status do cliente e não salvou.\nQuer fechar sem salvar?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (statusAtual.Id != (cbStatus.SelectedItem as ISituacaoModel).Id)
            {
                clienteModel.SituacaoId = (cbStatus.SelectedItem as ISituacaoModel).Id;

                try
                {

                    _clientesServices.Edit(clienteModel);
                    MessageBox.Show("Status Alterado com sucesso", this.Text);
                    statusAtual = cbStatus.SelectedItem as ISituacaoModel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível alterar o status do Cliente.\n\n{ex.Message}\n\n{ex.InnerException}\n\n{ex.StackTrace}", this.Text);
                }
            }

        }
    }
}
