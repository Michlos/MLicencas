
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
using ServicesLayer.EnderecosClientes;
using DomainLayer.Clientes.Enderecos;
using InfraStructure.Repository.EnderecosClientes;

namespace MLicencas.FormViews.Enderecos
{
    public partial class EnderecoAddForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private TiposEnderecosServices _tiposServices;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;
        private BairrosServices _bairrosServices;
        private EnderecosFabricaServices _endFabServices;
        private EnderecosClientesServices _endCliServces;

        //MODELS
        private IEnumerable<ITipoEnderecoModel> tipoEnderecoListModel = new List<ITipoEnderecoModel>();
        private IEnumerable<IEstadoModel> estadoListModel = new List<IEstadoModel>();
        private IEnumerable<ICidadeModel> cidadeListModel = new List<ICidadeModel>();
        private IEnumerable<IBairroModel> bairroListModel = new List<IBairroModel>();
        private IEnderecoFabricaModel endFabModel = new EnderecoFabricaModel();
        private IEnderecoClienteModel endCliModel = new EnderecoClienteModel();

        //PROPERTIES
        private int enderecoId;
        //private int fabricaId;
        private object TModel;
        public EnderecoAddForm(int enderecoId, object TModel)
        {
            LoadServices();
            InitializeComponent();
            this.enderecoId = enderecoId;
            this.TModel = TModel;
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
            cbTipoEndereco.SelectedItem = tipoEnderecoListModel.Where(id => id.Id == endFabModel.TipoEnderecoId).FirstOrDefault();
        }

        private void LoadModels()
        {
            if (enderecoId != 0)
            {
                if (TModel.GetType() == endFabModel.GetType())
                {
                    TModel = _endFabServices.GetById(enderecoId);

                }
                else
                {
                    TModel = _endCliServces.GetById(enderecoId);
                }


            }
            this.tipoEnderecoListModel = _tiposServices.GetAll();
            this.estadoListModel = _estadosServices.GetAll().OrderBy(uf => uf.Uf);

        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _tiposServices = new TiposEnderecosServices(new TipoEnderecoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairrosServices = new BairrosServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _endFabServices = new EnderecosFabricaServices(new EnderecoFabricaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _endCliServces = new EnderecosClientesServices(new EnderecoClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (TModel.GetType() == endFabModel.GetType())
            {

                (TModel as IEnderecoFabricaModel).Logradouro = txbLogradouro.Text;
                (TModel as IEnderecoFabricaModel).Complemento = txbComplemento.Text;
                (TModel as IEnderecoFabricaModel).Numero = txbNumero.Text;
                (TModel as IEnderecoFabricaModel).Cep = mtxbCep.Text;
                (TModel as IEnderecoFabricaModel).UfId = (cbUf.SelectedItem as IEstadoModel).Id;
                (TModel as IEnderecoFabricaModel).CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
                (TModel as IEnderecoFabricaModel).BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
                (TModel as IEnderecoFabricaModel).TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
                (TModel as IEnderecoFabricaModel).Id = string.IsNullOrEmpty(txbId.Text) ? 0 : int.Parse(txbId.Text);

            }
            else
            {
                TModel = new EnderecoClienteModel();
                (TModel as IEnderecoClienteModel).Logradouro = txbLogradouro.Text;
                (TModel as IEnderecoClienteModel).Complemento = txbComplemento.Text;
                (TModel as IEnderecoClienteModel).Numero = txbNumero.Text;
                (TModel as IEnderecoClienteModel).Cep = mtxbCep.Text;
                (TModel as IEnderecoClienteModel).UfId = (cbBairro.SelectedItem as IEstadoModel).Id;
                (TModel as IEnderecoClienteModel).CidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
                (TModel as IEnderecoClienteModel).BairroId = (cbBairro.SelectedItem as IBairroModel).Id;
                (TModel as IEnderecoClienteModel).TipoEnderecoId = (cbTipoEndereco.SelectedItem as ITipoEnderecoModel).Id;
                (TModel as IEnderecoClienteModel).Id = string.IsNullOrEmpty(txbId.Text) ? 0 : int.Parse(txbId.Text);
            }


            if (enderecoId != 0)
            {
                //UPDATE
                try
                {
                    if (TModel.GetType() == endFabModel.GetType())
                    {
                        _endFabServices.Edit(TModel as IEnderecoFabricaModel);
                    }
                    else
                    {
                        _endCliServces.Edit(TModel as IEnderecoClienteModel);
                    }
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
                    if (TModel.GetType() == endFabModel.GetType())
                    {
                        this.TModel = _endFabServices.Add(TModel as IEnderecoFabricaModel);
                        this.enderecoId = (TModel as IEnderecoFabricaModel).Id;

                    }
                    else
                    {
                        this.TModel = _endCliServces.Add(TModel as IEnderecoClienteModel);
                        this.enderecoId = (TModel as IEnderecoClienteModel).Id;
                    }
                    MessageBox.Show("Endereço salvo com sucesso.", this.Text);

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
                if (TModel.GetType() == endFabModel.GetType())
                {
                    txbId.Text = (TModel as IEnderecoFabricaModel).Id.ToString();
                    txbLogradouro.Text = (TModel as IEnderecoFabricaModel).Logradouro;
                    txbComplemento.Text = (TModel as IEnderecoFabricaModel).Complemento;
                    txbNumero.Text = (TModel as IEnderecoFabricaModel).Numero;
                    mtxbCep.Text = (TModel as IEnderecoFabricaModel).Cep;
                    cbUf.Text = estadoListModel.Where(id => id.Id == (TModel as IEnderecoFabricaModel).UfId).FirstOrDefault().Uf;
                    cbCidade.Text = cidadeListModel.Where(id => id.Id == (TModel as IEnderecoFabricaModel).CidadeId).FirstOrDefault().Nome;
                    cbBairro.Text = bairroListModel.Where(id => id.Id == (TModel as IEnderecoFabricaModel).BairroId).FirstOrDefault().Nome;
                    cbTipoEndereco.Text = tipoEnderecoListModel.Where(id => id.Id == (TModel as IEnderecoFabricaModel).TipoEnderecoId).FirstOrDefault().Tipo;
                }
                else
                {
                    txbId.Text = (TModel as IEnderecoClienteModel).Id.ToString();
                    txbLogradouro.Text = (TModel as IEnderecoClienteModel).Logradouro;
                    txbComplemento.Text = (TModel as IEnderecoClienteModel).Complemento;
                    txbNumero.Text = (TModel as IEnderecoClienteModel).Numero;
                    mtxbCep.Text = (TModel as IEnderecoClienteModel).Cep;
                    cbUf.Text = estadoListModel.Where(id => id.Id == (TModel as IEnderecoClienteModel).UfId).FirstOrDefault().Uf;
                    cbCidade.Text = cidadeListModel.Where(id => id.Id == (TModel as IEnderecoClienteModel).CidadeId).FirstOrDefault().Nome;
                    cbBairro.Text = bairroListModel.Where(id => id.Id == (TModel as IEnderecoClienteModel).BairroId).FirstOrDefault().Nome;
                    cbTipoEndereco.Text = tipoEnderecoListModel.Where(id => id.Id == (TModel as IEnderecoClienteModel).TipoEnderecoId).FirstOrDefault().Tipo;
                }
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

        private void lblAddBairro_Click(object sender, EventArgs e)
        {
            int ufId = (cbUf.SelectedItem as IEstadoModel).Id;
            int cidadeId = (cbCidade.SelectedItem as ICidadeModel).Id;
            
            BairroAddForm bairroAdd = new BairroAddForm(ufId, cidadeId);
            bairroAdd.ShowDialog();
            LoadModels();
            LoadComboBoxBairro(cbCidade.SelectedItem as ICidadeModel);            
            
        }
    }
}
