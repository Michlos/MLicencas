using DomainLayer.Clientes.Enderecos;
using DomainLayer.Enderecos;

using InfraStructure;
using InfraStructure.Repository.Bairros;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.EnderecosClientes;
using InfraStructure.Repository.Estados;
using InfraStructure.Repository.TiposEnderecos;

using MLicencas.FormViews.Enderecos;

using ServiceLayer.CommonServices;

using ServicesLayer.Bairros;
using ServicesLayer.Cidades;
using ServicesLayer.ClientesServices;
using ServicesLayer.EnderecosClientes;
using ServicesLayer.Estados;
using ServicesLayer.TiposEnderecos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Clientes.Endereco
{
    public partial class EndCliAddForm : Form
    {
        private int enderecoId, clienteId;

        //SERVICES
        private QueryStringServices _queryString;
        private EnderecosClientesServices _enderecosServices;
        private ClientesServices _clientesServices;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;
        private BairrosServices _bairrosServices;
        private TiposEnderecosServices _tiposServices;

        //MODELS LISTMODELS
        private IEnderecoClienteModel enderecoModel;
        private IEnumerable<ITipoEnderecoModel> tipoListModel = new List<ITipoEnderecoModel>();
        private IEnumerable<IBairroModel> bairroListModel = new List<IBairroModel>();
        private IEnumerable<ICidadeModel> cidadeListModel = new List<ICidadeModel>();
        private IEnumerable<IEstadoModel> estadoListModel;




        public EndCliAddForm(int enderecoId, int clienteId)
        {
            LoadServices();
            InitializeComponent();
            this.enderecoId = enderecoId;
            this.clienteId = clienteId;
            LoadModels();
        }

        private void LoadModels()
        {
            tipoListModel = _tiposServices.GetAll();
            estadoListModel = _estadosServices.GetAll().OrderBy(uf => uf.Uf);

        }

        private void EndCliAddForm_Load(object sender, EventArgs e)
        {
            LoadCBTipos();
            LoadCBUf();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (enderecoId != 0)
            {
                enderecoModel = new EnderecoClienteModel();
                enderecoModel = _enderecosServices.GetById(enderecoId);

                txbId.Text = enderecoModel.Id.ToString();
                txbLogradouro.Text = enderecoModel.Logradouro;
                txbComplemento.Text = enderecoModel.Complemento;
                txbNumero.Text = enderecoModel.Numero;
                mtxbCep.Text = enderecoModel.Cep;
                cbTipoEndereco.Text = tipoListModel.Where(id => id.Id == enderecoModel.TipoEnderecoId).FirstOrDefault().Tipo;
                cbUf.Text = estadoListModel.Where(id => id.Id == enderecoModel.UfId).FirstOrDefault().Uf;
                cbCidade.Text = cidadeListModel.Where(id => id.Id == enderecoModel.CidadeId).FirstOrDefault().Nome;
                cbBairro.Text = bairroListModel.Where(id => id.Id == enderecoModel.BairroId).FirstOrDefault().Nome;

            }
        }

        private void LoadCBUf()
        {
            cbUf.DisplayMember = "Uf";
            cbUf.Items.Clear();
            foreach (EstadoModel model in estadoListModel)
            {
                cbUf.Items.Add(model);
            }
            cbUf.SelectedIndex = -1;
        }

        private void LoadCBTipos()
        {
            cbTipoEndereco.DataSource = tipoListModel;
            cbTipoEndereco.DisplayMember = "Tipo";
            cbTipoEndereco.SelectedIndex = -1;
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cidadeListModel = _cidadesServices.GetAllByUfId((cbUf.SelectedItem as IEstadoModel).Id);
            LoadCBCidades();
        }

        private void LoadCBCidades()
        {
            cbCidade.DisplayMember = "Nome";
            cbCidade.Items.Clear();
            if (cidadeListModel.Any())
            {
                foreach (var model in cidadeListModel)
                {
                    cbCidade.Items.Add(model);
                }
            }
            cbCidade.SelectedIndex = -1;
        }

        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            bairroListModel = _bairrosServices.GetAllByCidadeId((cbCidade.SelectedItem as ICidadeModel).Id);
            LoadCBBairros();
        }

        private void LoadCBBairros()
        {
            cbBairro.DisplayMember = "Nome";
            cbBairro.Items.Clear();
            if (bairroListModel.Any())
            {
                foreach (var item in bairroListModel)
                {
                    cbBairro.Items.Add(item);
                }
            }
            cbBairro.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enderecoModel = new EnderecoClienteModel();
            enderecoModel.Id = !string.IsNullOrEmpty(txbId.Text) ? int.Parse(txbId.Text) : 0;
            enderecoModel.BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
            enderecoModel.Cep = mtxbCep.Text;
            enderecoModel.CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
            enderecoModel.ClienteId = clienteId;
            enderecoModel.Complemento = txbComplemento.Text;
            enderecoModel.Logradouro = txbLogradouro.Text;
            enderecoModel.Numero = txbNumero.Text;
            enderecoModel.TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
            enderecoModel.UfId = (cbUf.SelectedItem as IEstadoModel).Id;
            if (enderecoId != 0)
            {
                UpdateEndereco();
            }
            else
            {
                AddEndereco();
            }
        }

        private void AddEndereco()
        {
            try
            {
                enderecoModel = _enderecosServices.Add(enderecoModel);
                enderecoId = enderecoModel.Id;
                MessageBox.Show("Endereço adicionado com sucesso.", this.Text);
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível salvar o endereço. \n\nMessage Error: {e.Message}\n\n StackTrace: {e.StackTrace} \n\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void UpdateEndereco()
        {
            try
            {
                _enderecosServices.Edit(enderecoModel);
                MessageBox.Show("Endereço alterado com sucesso.", this.Text);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Não foi possível alterar dados do endereço. \n\nMessage Error: {e.Message}\n\n StackTrace: {e.StackTrace} \n\nInnerException: {e.InnerException}", this.Text);
            }
        }

        private void lblAddBairro_Click(object sender, EventArgs e)
        {
            int ufId = (cbUf.SelectedItem as IEstadoModel).Id;
            int cidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;

            BairroAddForm bairroAdd = new BairroAddForm(ufId, cidadeId);
            bairroAdd.ShowDialog();
            LoadModels();
            LoadCBBairros();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _enderecosServices = new EnderecosClientesServices(new EnderecoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairrosServices = new BairrosServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposServices = new TiposEnderecosServices(new TipoEnderecoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

    }
}
