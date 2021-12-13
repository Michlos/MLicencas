using DomainLayer.Enderecos;

using InfraStructure;
using InfraStructure.Repository.Bairros;
using InfraStructure.Repository.Cidades;
using InfraStructure.Repository.Estados;

using ServiceLayer.CommonServices;

using ServicesLayer.Bairros;
using ServicesLayer.Cidades;
using ServicesLayer.Estados;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Enderecos
{
    public partial class BairroAddForm : Form
    {
        private int ufId, cidadeId;

        //SERVICES
        private QueryStringServices _queryString;
        private EstadosServices _estadosServices;
        private CidadesServices _cidadesServices;
        private BairrosServices _bairrosServices;


        //MODELS
        private IBairroModel bairroModel = new BairroModel();
        private IEstadoModel estadoModel = new EstadoModel();
        private ICidadeModel cidadeModel = new CidadeModel();
        public BairroAddForm(int ufId, int cidadeId)
        {
            LoadServices();

            InitializeComponent();
            
            this.ufId = ufId;
            this.cidadeId = cidadeId;

            LoadModels();
        }

        private void LoadModels()
        {
            this.estadoModel = _estadosServices.GetById(this.ufId);
            this.cidadeModel = _cidadesServices.GetById(this.cidadeId);
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _estadosServices = new EstadosServices(new EstadoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _cidadesServices = new CidadesServices(new CidadeRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _bairrosServices = new BairrosServices(new BairroRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbBairro.Text.Trim()))
            {
                this.bairroModel.Nome = txbBairro.Text;
                this.bairroModel.CidadeId = this.cidadeId;
                try
                {
                    this.bairroModel = _bairrosServices.Add(this.bairroModel);
                    MessageBox.Show("Bairro adicionado com sucesso", this.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível adicionar o Bairro.\nMessageErro: {ex.Message}\nInnerException: {ex.InnerException}\nStackTrace: {ex.StackTrace}", this.Text );
                }
            }
        }

        private void BairroAddForm_Load(object sender, EventArgs e)
        {
            txbUf.Text = this.estadoModel.Uf;
            txbCidade.Text = this.cidadeModel.Nome;
        }
    }
}
