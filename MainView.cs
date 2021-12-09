using DomainLayer.Modulos;
using DomainLayer.Usuarios;

using MLicencas.FormViews.Login;
using MLicencas.FormViews.Usuarios;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas
{
    public partial class MainView : Form
    {
        public static IUsuarioModel _UsuarioModel = new UsuarioModel();
        public static IEnumerable<IModuloModel> _ModulosListModel = new List<IModuloModel>();
        public static IEnumerable<IPermissaoModel> _PermissaoListModel = new List<IPermissaoModel>();
        private MainView _obj;

        public MainView()
        {
            LoadLogin();
            InitializeComponent();
            LoadStatusBarr();
        }

        public MainView Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainView();
                }
                return _obj;
            }

        }

        public static bool CheckPermissoes(object tag)
        {
            bool permite = false;
            permite = _PermissaoListModel
                .Where(modPer => modPer.ModuloId == (
                    (_ModulosListModel
                        .Where(niv => niv.Nivel ==
                            tag.ToString()
                        )
                    ).Select(modId => modId.Id).FirstOrDefault())
                ).Select(ena => ena.Ativo).FirstOrDefault();

            return permite;

        }
        private void LoadStatusBarr()
        {
            statusUsuario.Text = _UsuarioModel.Nome;
        }

        private void LoadLogin()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosFormView usu = new UsuariosFormView();
            usu.WindowState = FormWindowState.Normal;
            usu.MdiParent = this;
            usu.Show();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            menuGestaoDeUsuarios.Enabled = CheckPermissoes(menuGestaoDeUsuarios.Tag);
            cadastroDaEmpresaToolStripMenuItem.Enabled = CheckPermissoes(cadastroDaEmpresaToolStripMenuItem.Tag);
        }

        private void cadastroDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
