using DomainLayer.Fabrica;
using DomainLayer.Telefones;

using InfraStructure;
using InfraStructure.Repository.TelefonesContatosFabrica;
using InfraStructure.Repository.TiposTelefones;

using ServiceLayer.CommonServices;

using ServicesLayer.TelefonesContatosFabricaServices;
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

namespace MLicencas.FormViews.Fabrica.Contato.Telefone
{
    public partial class TelFabAddForm : Form
    {
        private int telefoneId, contatoId;

        //SERVICES
        private QueryStringServices _queryString;
        private TelefonesContatosFabricaServices _telefonesServices;
        private TiposTelefonesServices _tiposServices;

        //MODELS
        private ITelefoneContatoFabricaModel telefoneModel = new TelefoneContatoFabricaModel();
        private IEnumerable<ITipoTelefoneModel> tiposListModel = new List<ITipoTelefoneModel>();

        public TelFabAddForm(int telefoneId, int contatoId)
        {
            LoadServices();
            InitializeComponent();
            this.telefoneId = telefoneId;
            this.contatoId = contatoId;
            LoadModels();
        }

        private void LoadModels()
        {
            tiposListModel = _tiposServices.GetAll();
        }

        private void TelFabAddForm_Load(object sender, EventArgs e)
        {
            LoadCBTipos();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (telefoneId != 0)
            {
                telefoneModel = _telefonesServices.GetById(telefoneId);
                txbId.Text = telefoneModel.Id.ToString();
                //cbTipo.Text = tiposListModel.Where(id => id.Id == telefoneModel.Id).FirstOrDefault().Tipo.ToString();
                mtxbNumero.Text = telefoneModel.Numero;
                txbOperadora.Text = telefoneModel.Operadora;
                txbRamal.Text = telefoneModel.Ramal;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            telefoneModel.ContatoId = contatoId;
            telefoneModel.TipoTelefoneId = (cbTipo.SelectedItem as ITipoTelefoneModel).Id;
            telefoneModel.Numero = mtxbNumero.Text;
            telefoneModel.Ramal = txbRamal.Text;
            telefoneModel.Operadora = txbOperadora.Text;

            if (telefoneId != 0)
                UpdateTelefone();
            else
                AddTelefone();
        }
        private void AddTelefone()
        {
            try
            {
                telefoneModel = _telefonesServices.Add(telefoneModel);
                telefoneId = telefoneModel.Id;
                MessageBox.Show("Telefone adicionado com sucesso.", this.Text);
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível Editar o telefone.\nErrorMessage: {e.Message}\nInnerException: {e.InnerException}\nStackTrace: {e.StackTrace}", this.Text);
            }
        }

        private void UpdateTelefone()
        {
            telefoneModel.Id = telefoneId;
            try
            {
                _telefonesServices.Edit(telefoneModel);
                MessageBox.Show("Telefone atualizado com sucesso.", this.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível Editar o telefone.\nErrorMessage: {e.Message}\nInnerException: {e.InnerException}\nStackTrace: {e.StackTrace}", this.Text);
            }
        }

        private void LoadCBTipos()
        {
            cbTipo.DataSource = tiposListModel;
            cbTipo.DisplayMember = "Tipo";
            cbTipo.SelectedIndex = -1;
        }

        private void cbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo.SelectedIndex != -1)
            {
                mtxbNumero.Mask = (cbTipo.SelectedItem as ITipoTelefoneModel).Mascara.ToString();
                string tipo = (cbTipo.SelectedItem as ITipoTelefoneModel).Tipo;
                if (tipo == "Fixo")
                {
                    txbOperadora.Enabled = false;
                    txbRamal.Enabled = true;
                }
                else
                {
                    txbOperadora.Enabled = true;
                    txbRamal.Enabled = false;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _telefonesServices = new TelefonesContatosFabricaServices(new TelefoneContatoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposServices = new TiposTelefonesServices(new TipoTelefoneRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());

        }
    }
}
