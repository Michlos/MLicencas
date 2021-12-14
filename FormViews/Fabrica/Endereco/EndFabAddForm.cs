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

        public EndFabAddForm(int enderecoId, int fabricaId)
        {
            LoadServices();
            InitializeComponent();

            this.enderecoId = enderecoId;
            this.fabricaId = fabricaId;
            LoadPermitions();
            
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
