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

namespace MLicencas.FormViews.Login
{
    public partial class Login : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;
        
        //MODELS LISTMODELS
        public IUsuarioModel usuarioModel;
        private IEnumerable<IUsuarioModel> usuarioListModel;

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
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
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
