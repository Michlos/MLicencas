using DomainLayer.Clientes;

using InfraStructure;
using InfraStructure.Repository.Clientes;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;

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
    public partial class SelectClientForm : Form
    {
        public int clienteId;
        private QueryStringServices _queryString;
        private ClientesServices _clientesServices;
        private IEnumerable<IClienteModel> cliListModel = new List<IClienteModel>();
        private IClienteModel cliModel = new ClienteModel();
        public SelectClientForm()
        {
            _queryString = new QueryStringServices(new QueryString());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

            InitializeComponent();
            cliListModel = _clientesServices.GetAll();
        }

        private void mtxbCpf_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(mtxbCpf.Text.Trim()))
            {
                cliModel = cliListModel.Where(cpf => cpf.Cnpj == mtxbCpf.Text).FirstOrDefault();
                if (cliModel != null)
                {
                    cbNome.SelectedItem = cliModel;
                }
            }
        }

        private void SelectClientForm_Load(object sender, EventArgs e)
        {
            LoadCBCliente();

        }

        private void LoadCBCliente()
        {
            cbNome.DataSource = cliListModel;
            cbNome.DisplayMember = "NomeFantasia";
            cbNome.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clienteId = (cbNome.SelectedItem as ClienteModel).Id;
            this.Close();
        }
    }
}
