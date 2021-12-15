using DomainLayer.Enderecos;
using DomainLayer.Fabrica;

using InfraStructure;
using InfraStructure.Repository.Bairros;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.EnderecosFabrica;
using InfraStructure.Repository.Estados;
using InfraStructure.Repository.TiposEnderecos;

using MLicencas.FormViews.Enderecos;

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
    public partial class EndFabAddForm : Form
    {
        private int enderecoId, fabricaId;

        //SERVICES
        private QueryStringServices _queryString;
        private EnderecosFabricaServices _enderecosServices;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;
        private BairrosServices _bairrosServices;
        private TiposEnderecosServices _tiposServices;

        //MODELS
        private IEnderecoFabricaModel enderecoModel = new EnderecoFabricaModel();
        private IEnumerable<ITipoEnderecoModel> tipoEndListModel = new List<ITipoEnderecoModel>();
        private IEnumerable<IEstadoModel> ufListModel = new List<IEstadoModel>();
        private IEnumerable<ICidadeModel> ciddadeListModel = new List<ICidadeModel>();
        private IEnumerable<IBairroModel> bairroListModel = new List<IBairroModel>();

        public EndFabAddForm(int enderecoId, int fabricaId)
        {
            LoadServices();
            InitializeComponent();

            this.enderecoId = enderecoId;
            this.fabricaId = fabricaId;
            LoadPermitions();
            LoadModels();

        }

        private void LoadModels()
        {
            tipoEndListModel = _tiposServices.GetAll();
            ufListModel = _estadosServices.GetAll().OrderBy(uf => uf.Uf);

        }

        private void LoadPermitions()
        {
            btnSave.Enabled = MainView.CheckPermissoes(btnSave.Tag);
            lblAddBairro.Enabled = MainView.CheckPermissoes(lblAddBairro.Tag);
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _enderecosServices = new EnderecosFabricaServices(new EnderecoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairrosServices = new BairrosServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposServices = new TiposEnderecosServices(new TipoEnderecoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void EndFabAddForm_Load(object sender, EventArgs e)
        {
            LoadCBTipos();
            LoadCBUf();
            LoadFormFields();
        }

        private void LoadCBUf()
        {
            //cbUf.DataSource = ufListModel;
            //cbUf.DisplayMember = "Uf";

            cbUf.DisplayMember = "Uf";
            cbUf.Items.Clear();
            foreach (EstadoModel model in ufListModel)
            {
                cbUf.Items.Add(model);
            }
            cbUf.SelectedIndex = -1;
        }

        private void LoadCBTipos()
        {
            cbTipoEndereco.DataSource = tipoEndListModel;
            cbTipoEndereco.DisplayMember = "Tipo";
        }

        private void LoadFormFields()
        {
            if (enderecoId != 0)
            {
                //EDITANDO
                enderecoModel = _enderecosServices.GetById(enderecoId);

                txbId.Text = enderecoModel.Id.ToString();
                txbLogradouro.Text = enderecoModel.Logradouro;
                txbComplemento.Text = enderecoModel.Complemento;
                txbNumero.Text = enderecoModel.Numero;
                mtxbCep.Text = enderecoModel.Cep;
                cbTipoEndereco.Text = tipoEndListModel.Where(id => id.Id == enderecoModel.TipoEnderecoId).FirstOrDefault().Tipo;
                cbUf.Text = ufListModel.Where(id => id.Id == enderecoModel.UfId).FirstOrDefault().Uf;
                cbCidade.Text = ciddadeListModel.Where(id => id.Id == enderecoModel.CidadeId).FirstOrDefault().Nome;
                cbBairro.Text = bairroListModel.Any() ? bairroListModel.Where(id => id.Id == enderecoModel.BairroId).FirstOrDefault().Nome : string.Empty;

            }
        }

        private void cbUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUf.SelectedIndex != -1)
            {
                ciddadeListModel = _cidadesServices.GetAllByUfId((cbUf.SelectedItem as IEstadoModel).Id);
                LoadCbCidades();
            }
        }

        private void LoadCbCidades()
        {
            cbCidade.DisplayMember = "Nome";
            cbCidade.Items.Clear();
            foreach (ICidadeModel model in ciddadeListModel)
            {
                cbCidade.Items.Add(model);
            }
            cbCidade.SelectedIndex = -1;
        }

        private void cbCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCidade.SelectedIndex != -1)
            {
                bairroListModel = _bairrosServices.GetAllByCidadeId((cbCidade.SelectedItem as ICidadeModel).Id);
                LoadCBBairros();
            }
        }

        private void LoadCBBairros()
        {
            cbBairro.DisplayMember = "Nome";
            cbBairro.Items.Clear();
            if (bairroListModel.Any())
            {
                foreach (IBairroModel model in bairroListModel)
                {
                    cbBairro.Items.Add(model);
                }
            }
            cbBairro.SelectedIndex = -1;
        }

        private void lblAddBairro_Click(object sender, EventArgs e)
        {
            int ufId = (cbUf.SelectedItem as IEstadoModel).Id;
            int cidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;

            BairroAddForm bairroAdd = new BairroAddForm(ufId, cidadeId);
            bairroAdd.ShowDialog();
            LoadCBBairros();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (enderecoId != 0)
            {
                EditEndereco();
            }
            else
            {

                SaveEndereco();
            }
        }

        private void SaveEndereco()
        {
           
                //ADD
                enderecoModel.Logradouro = txbLogradouro.Text;
                enderecoModel.Complemento = txbComplemento.Text;
                enderecoModel.Numero = txbNumero.Text;
                enderecoModel.Cep = mtxbCep.Text;
                enderecoModel.TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
                enderecoModel.UfId = (cbUf.SelectedItem as IEstadoModel).Id;
                enderecoModel.CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
                enderecoModel.BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
                enderecoModel.FabricaId = fabricaId;
                try
                {
                    this.enderecoModel = _enderecosServices.Add(enderecoModel);
                    MessageBox.Show("Endereço Adicionado com sucesso.", this.Text);
                    enderecoId = enderecoModel.Id;
                    LoadFormFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o endereço.\nMessageError: {ex.Message}\nInnerException: {ex.InnerException}\nStackTrace: {ex.StackTrace}", this.Text);
                }
     

        }

        private void EditEndereco()
        {
           
                //UPDATE
                enderecoModel.Logradouro = txbLogradouro.Text;
                enderecoModel.Complemento = txbComplemento.Text;
                enderecoModel.Numero = txbNumero.Text;
                enderecoModel.Cep = mtxbCep.Text;
                enderecoModel.TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
                enderecoModel.UfId = (cbUf.SelectedItem as IEstadoModel).Id;
                enderecoModel.CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
                enderecoModel.BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
                enderecoModel.FabricaId = fabricaId;
                enderecoModel.Id = enderecoId;
                try
                {
                    _enderecosServices.Edit(enderecoModel);
                    MessageBox.Show("Endereço Atualizado com sucesso.", this.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível atualizar os dados do endereço.\nMessageError: {ex.Message}\nInnerException: {ex.InnerException}\nStackTrace: {ex.StackTrace}", this.Text);
                }
          

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
