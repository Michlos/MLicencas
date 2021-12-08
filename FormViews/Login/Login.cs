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

namespace MLicencas.FormViews.Login
{
    public partial class Login : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;
        private ModulosServices _modulosServices;
        private GruposServices _gruposServices;
        private PersmissoesServices _persmissoesServices;

        //MODELS LISTMODELS
        public IUsuarioModel usuarioModel;
        private IGrupoModel grupoModel;
        
        private IEnumerable<IUsuarioModel> usuarioListModel;
        private IEnumerable<IModuloModel> modulosListModel;
        private IEnumerable<IPermissaoModel> permissaoListModel;

        public Login()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
        }

        private void LoadModels()
        {
            usuarioListModel = new List<IUsuarioModel>();
            usuarioListModel = _usuariosServices.GetAll();
            modulosListModel = _modulosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _persmissoesServices = new PersmissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string senhaAtual = "";
            
            if (_usuariosServices.CheckLogin(txbUsuario.Text, txbSenha.Text))
            {
                MainView._UsuarioModel = _usuariosServices.GetByLogin(txbUsuario.Text);
                MainView._ModulosListModel = modulosListModel;
                MainView._PermissaoListModel = _persmissoesServices.GetAllByGrupo(MainView._UsuarioModel.GrupoId);

                if (MainView._UsuarioModel.AlteraSenha)
                {
                    senhaAtual = MainView._UsuarioModel.Senha;
                    AlteraSenhaForm alteraSenha = new AlteraSenhaForm();
                    alteraSenha.ShowDialog();
                    if (senhaAtual != MainView._UsuarioModel.Senha)
                    {
                        this.Close();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou Senha Inválidos");
            }
        }
    }
}
