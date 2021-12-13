using DomainLayer.Enderecos;
using DomainLayer.Fabrica;

using InfraStructure;
using InfraStructure.Repository.Bairros;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.EnderecosFabrica;
using InfraStructure.Repository.Estados;
using InfraStructure.Repository.TiposEnderecos;

using ServiceLayer.CommonServices;

using ServicesLayer.Bairros;
using ServicesLayer.Cidades;
using ServicesLayer.EnderecosFabricaServices;
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

namespace MLicencas.FormViews.Fabrica.Endereco
{
    public partial class EnderecoFabricaAddFormView : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private TiposEnderecosServices _tiposServices;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;
        private BairrosServices _bairrosServices;
        private EnderecosFabricaServices _enderecosServices;

        //MODELS
        private IEnumerable<ITipoEnderecoModel> tipoEnderecoListModel = new List<ITipoEnderecoModel>();
        private IEnumerable<IEstadoModel> estadoListModel = new List<IEstadoModel>();
        private IEnumerable<ICidadeModel> cidadeListModel = new List<ICidadeModel>();
        private IEnumerable<IBairroModel> bairroListModel = new List<IBairroModel>();
        private IEnderecoFabricaModel enderecoModel = new EnderecoFabricaModel();

        //PROPERTIES
        private int enderecoId;
        private int fabricaId;
        public EnderecoFabricaAddFormView(int enderecoId, int fabricaId)
        {
            LoadServices();
            InitializeComponent();
            this.enderecoId = enderecoId;
            this.fabricaId = fabricaId;
            LoadModels();
            LoadComboBoxTiposEnderecos();
            LoadComboBoxUf();
            LoadFields();


        }

        private void LoadComboBoxUf()
        {

            cbUf.DisplayMember = "Uf";
            cbUf.Items.Clear();
            foreach (EstadoModel model in estadoListModel)
            {
                cbUf.Items.Add(model);
            }
            cbUf.SelectedIndex = -1;

        }

        private void LoadComboBoxTiposEnderecos()
        {
            cbTipoEndereco.DataSource = this.tipoEnderecoListModel;
            cbTipoEndereco.ValueMember = "Tipo";
            cbTipoEndereco.SelectedItem = tipoEnderecoListModel.Where(id => id.Id == enderecoModel.TipoEnderecoId).FirstOrDefault();
        }

        private void LoadModels()
        {
            if (enderecoId != 0)
            {

                this.enderecoModel = _enderecosServices.GetById(enderecoId);

            }
            this.tipoEnderecoListModel = _tiposServices.GetAll();
            this.estadoListModel = _estadosServices.GetAll().OrderBy(uf => uf.Uf);
            //this.cidadeListModel = _cidadesServices.GetAll().OrderBy(nome => nome.Nome);
            //this.bairroListModel = _bairrosServices.GetAll().OrderBy(nome => nome.Nome);
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _tiposServices = new TiposEnderecosServices(new TipoEnderecoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairrosServices = new BairrosServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _enderecosServices = new EnderecosFabricaServices(new EnderecoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbUf_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void LoadComBoxCidade(IEstadoModel estadoModel)
        {
            this.cidadeListModel = _cidadesServices.GetAllByUfId(estadoModel.Id);

            cbCidade.DisplayMember = "Nome";
            cbCidade.Items.Clear();
            foreach (ICidadeModel model in cidadeListModel)
            {
                cbCidade.Items.Add(model);
            }
        }

        private void cbCidade_ValueMemberChanged(object sender, EventArgs e)
        {
            LoadComboBoxBairro(cbCidade.SelectedItem as ICidadeModel);
        }

        private void LoadComboBoxBairro(ICidadeModel cidadeModel)
        {
            this.bairroListModel = _bairrosServices.GetAllByCidadeId(cidadeModel.Id);

            if (this.bairroListModel != null)
            {
                cbBairro.DisplayMember = "Nome";
                cbBairro.Items.Clear();
                foreach (IBairroModel model in bairroListModel)
                {
                    cbBairro.Items.Add(model);
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            enderecoModel = new EnderecoFabricaModel();
            enderecoModel.Logradouro = txbLogradouro.Text;
            enderecoModel.Complemento = txbComplemento.Text;
            enderecoModel.Numero = txbNumero.Text;
            enderecoModel.Cep = mtxbCep.Text;
            enderecoModel.UfId = (cbUf.SelectedItem as IEstadoModel).Id;
            enderecoModel.CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
            enderecoModel.BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
            enderecoModel.TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
            enderecoModel.FabricaId = this.fabricaId;

            if (enderecoId != 0)
            {
                //UPDATE
                enderecoModel.Id = int.Parse(txbId.Text);
                try
                {
                    _enderecosServices.Edit(enderecoModel);
                    MessageBox.Show("Endereço atualizado com sucesso.", this.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível alterar o endereço.\n{ex.Message}\n{ex.InnerException}", this.Text);
                }
            }
            else
            {
                //ADD
                try
                {
                    this.enderecoModel = _enderecosServices.Add(this.enderecoModel);
                    MessageBox.Show("Endereço salvo com sucesso.", this.Text);
                    this.enderecoId = enderecoModel.Id;

                    LoadFields();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível salvar o endereço.\n{ex.Message}\n{ex.InnerException}", this.Text);

                }
            }

        }

        private void LoadFields()
        {

            if (this.enderecoId != 0)
            {
                txbId.Text = enderecoModel.Id.ToString();
                txbLogradouro.Text = enderecoModel.Logradouro;
                txbComplemento.Text = enderecoModel.Complemento;
                txbNumero.Text = enderecoModel.Numero;
                mtxbCep.Text = enderecoModel.Cep;
                cbUf.Text = estadoListModel.Where(id => id.Id == enderecoModel.UfId).FirstOrDefault().Uf;
                cbCidade.Text = cidadeListModel.Where(id => id.Id == enderecoModel.CidadeId).FirstOrDefault().Nome;
                cbBairro.Text = bairroListModel.Where(id => id.Id == enderecoModel.BairroId).FirstOrDefault().Nome;
                cbTipoEndereco.Text = tipoEnderecoListModel.Where(id => id.Id == enderecoModel.TipoEnderecoId).FirstOrDefault().Tipo;
            }
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCidade.Text = string.Empty;
            cbBairro.Text = string.Empty;
            if (cbUf.SelectedIndex != -1)
            {
                LoadComBoxCidade(cbUf.SelectedItem as IEstadoModel);
                //SetMaskInscricaoEstadual(cbUf.Text);
            }
        }

        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbBairro.Text = string.Empty;
            if (cbCidade.SelectedIndex != -1)
            {
                LoadComboBoxBairro(cbCidade.SelectedItem as ICidadeModel);
            }
        }
    }
}
