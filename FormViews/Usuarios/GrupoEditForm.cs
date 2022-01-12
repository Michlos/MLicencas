using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Usuarios;

using ServiceLayer.CommonServices;

using ServicesLayer.Usuarios;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Usuarios
{
    public partial class GrupoEditForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private GruposServices _gruposServices;

        //MODELS
        private IGrupoModel grupoModel = new GrupoModel();
        private IEnumerable<IGrupoModel> grupoListModel = new List<IGrupoModel>();

        public GrupoEditForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
        }

        private void LoadModels()
        {
            grupoListModel = _gruposServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grupoModel = new GrupoModel()
            {
                Nome = txbNome.Text
            };
            try
            {
                
                if (grupoListModel.Where(nome => nome.Nome == txbNome.Text).Any())
                {
                    throw new Exception("Já existe um grupo com esse nome");
                }
                else if (string.IsNullOrEmpty(txbNome.Text.Trim()))
                {
                    throw new Exception("Informe o nome do grupo");
                }
                else
                {
                    grupoModel = _gruposServices.Add(grupoModel);
                    MessageBox.Show("Grupo Cadastrado com Sucesso.");
                    txbId.Text = grupoModel.Id.ToString();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
