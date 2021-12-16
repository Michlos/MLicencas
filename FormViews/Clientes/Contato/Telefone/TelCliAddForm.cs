using DomainLayer.Clientes.Telefones;
using DomainLayer.Telefones;

using InfraStructure;
using InfraStructure.Repository.TelefonesContatosClientes;
using InfraStructure.Repository.TiposTelefones;

using ServiceLayer.CommonServices;

using ServicesLayer.TelefonesContatosClientes;
using ServicesLayer.TiposTelefones;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Clientes.Contato.Telefone
{
    public partial class TelCliAddForm : Form
    {
        private int contatoId, telefoneId;

        //SERVICES;
        private QueryStringServices _queryString;
        private TelefonesContatosClientesServices _telefonesServices;
        private TiposTelefonesServices _tiposServices;

        //MODELS AND LISTMODELS
        private IEnumerable<ITipoTelefoneModel> tipoListModel;
        private ITelefoneContatoClienteModel telefoneModel;

        public TelCliAddForm( int telefoneId, int contatoId)
        {

            LoadServices();
            InitializeComponent();
            this.contatoId = contatoId;
            this.telefoneId = telefoneId;
            LoadModels();
        }

        private void LoadModels()
        {
            tipoListModel = _tiposServices.GetAll();
        }

        private void TelCliAddForm_Load(object sender, EventArgs e)
        {
            LoadCBTipos();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (telefoneId != 0)
            {
                telefoneModel = new TelefoneContatoClienteModel();
                telefoneModel = _telefonesServices.GetById(telefoneId);
                txbId.Text = telefoneModel.Id.ToString();
                mtxbNumero.Text = telefoneModel.Numero;
                txbOperadora.Text = !string.IsNullOrEmpty(telefoneModel.Operadora) ? telefoneModel.Operadora : string.Empty;
                txbRamal.Text = !string.IsNullOrEmpty(telefoneModel.Ramal) ? telefoneModel.Ramal : string.Empty;
                cbTipo.Text = tipoListModel.Where(id => id.Id == telefoneModel.TipoTelefoneId).FirstOrDefault().Tipo;
            }
        }

        private void LoadCBTipos()
        {
            cbTipo.DisplayMember = "Tipo";
            cbTipo.DataSource = tipoListModel;
            cbTipo.SelectedIndex = 0;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tipoid = (cbTipo.SelectedItem as ITipoTelefoneModel).Id;
            mtxbNumero.Mask = (cbTipo.SelectedItem as ITipoTelefoneModel).Mascara.ToString();
            if (tipoid == 1)
            {
                txbOperadora.Enabled = true;
                txbRamal.Enabled = false;
            }
            else
            {
                txbOperadora.Enabled = false;
                txbRamal.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            telefoneModel = new TelefoneContatoClienteModel();
            telefoneModel.Id = telefoneId;
            telefoneModel.ContatoId = contatoId;
            telefoneModel.Numero = mtxbNumero.Text;
            telefoneModel.Operadora = txbOperadora.Text;
            telefoneModel.Ramal = txbRamal.Text;
            telefoneModel.TipoTelefoneId = (cbTipo.SelectedItem as ITipoTelefoneModel).Id;

            if (telefoneId != 0)
            {
                UpdateTelefone();
            }
            else
            {
                AddTelefone();
            }
        }

        private void AddTelefone()
        {
            try
            {
                telefoneModel = _telefonesServices.Add(telefoneModel);
                MessageBox.Show("Telefone Adicionado com sucesso", this.Text);
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível Adicionar telefone.\n\nMessage Error: {e.Message}. \n\nInner Exception: {e.InnerException}\n\nStack Trace:{e.StackTrace}", this.Text );
            }
        }

        private void UpdateTelefone()
        {
            try
            {
                _telefonesServices.Edit(telefoneModel);
                MessageBox.Show("Telefone Alterado com sucesso", this.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível Atlerar dados do telefone.\n\nMessage Error: {e.Message}. \n\nInner Exception: {e.InnerException}\n\nStack Trace:{e.StackTrace}", this.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _telefonesServices = new TelefonesContatosClientesServices(new TelefoneContatoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposServices = new TiposTelefonesServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
    }
}
