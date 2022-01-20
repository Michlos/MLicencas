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
    public partial class SelectClienteForm : Form
    {
        public int clienteId;
        //SERVICES
        private QueryStringServices _queryString;
        private ClientesServices _clientesServices;
        private SituacoesServices _situacoesServices;

        //MODELS
        private IEnumerable<ISituacaoModel> situacaoListModel;
        private IClienteModel clienteModel;
        private IEnumerable<IClienteModel> clienteListModel;

        public SelectClienteForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadCBClientes();
        }

        private void LoadCBClientes()
        {
            cbCliente.DataSource = clienteListModel;
            cbCliente.DisplayMember = "RazaoSocial";
            cbCliente.SelectedIndex = -1;
        }

        private void LoadModels()
        {
            situacaoListModel = _situacoesServices.GetAll();
            clienteListModel = _clientesServices.GetAllBySituacaoId(situacaoListModel.FirstOrDefault(situ => situ.Descricao != "Desativado").Id);

        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _situacoesServices = new SituacoesServices(new SituacaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex > -1)
            {
                clienteId = (cbCliente.SelectedItem as IClienteModel).Id;
                dgvClientes.SelectedRows.Clear();
                foreach (DataGridViewRow row in dgvClientes.Rows)
                {
                    if (int.Parse(row.Cells[0].Value.ToString()) == clienteId)
                        row.Selected = true;
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                clienteId = int.Parse(dgvClientes.CurrentRow.Cells[0].Value.ToString());
                this.Close();
            }
        }
    }
}
