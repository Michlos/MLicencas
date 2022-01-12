using DomainLayer.Modulos;
using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Modulos;
using InfraStructure.Repository.Usuarios;

using ServiceLayer.CommonServices;

using ServicesLayer.Modulos;
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
        private ModulosServices _modulosServices;
        private PermissoesServices _permissoesServices;

        //MODELS
        private IGrupoModel grupoModel = new GrupoModel();
        private IEnumerable<IGrupoModel> grupoListModel = new List<IGrupoModel>();
        private IEnumerable<IModuloModel> moduloListModel = new List<IModuloModel>();
        private List<IPermissaoModel> permissoesListModel = new List<IPermissaoModel>();

        public GrupoEditForm()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
        }

        private void LoadModels()
        {
            grupoListModel = _gruposServices.GetAll();
            moduloListModel = _modulosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _permissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grupoModel = new GrupoModel()
            {
                Nome = txbNome.Text,
                Ativo = true
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
                    foreach (var item in moduloListModel)
                    {
                        IPermissaoModel permissao = new PermissaoModel()
                        {
                            GrupId = grupoModel.Id,
                            ModuloId = item.Id,
                            Ativo = false
                        };
                        try
                        {
                            _permissoesServices.Add(permissao);
                        }
                        catch (Exception)
                        {

                            throw new Exception("O Grupo foi adicionado, porém ocorreu um erro ao adicionar permissões.");
                        }
                    }

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
