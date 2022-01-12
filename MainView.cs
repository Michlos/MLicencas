using DomainLayer.Modulos;
using DomainLayer.Usuarios;

using Financeiro.Banco;

using MLicencas.FormViews.Clientes;
using MLicencas.FormViews.Contratos;
using MLicencas.FormViews.Fabrica;
using MLicencas.FormViews.Licencas;
using MLicencas.FormViews.Login;
using MLicencas.FormViews.Softwares;
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
            novoClienteToolStripMenuItem.Enabled = CheckPermissoes(novoClienteToolStripMenuItem.Tag);
            gestaoDeClientesToolStripMenuItem.Enabled = CheckPermissoes(gestaoDeClientesToolStripMenuItem.Tag);
            novoSoftwareToolStripMenuItem.Enabled = CheckPermissoes(novoSoftwareToolStripMenuItem.Tag);
            gestaoSoftwareToolStripMenuItem.Enabled = CheckPermissoes(gestaoSoftwareToolStripMenuItem.Tag);

        }

        private void cadastroDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FabricaFormView fab = new FabricaFormView();
            fab.WindowState = FormWindowState.Normal;
            fab.MdiParent = this;
            fab.Show();
        }

        private void gestaoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientesListForm cliForm = new ClientesListForm();
            cliForm.WindowState = FormWindowState.Normal;
            cliForm.MdiParent = this;
            cliForm.Show();
        }

        private void novoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteAddForm cliAddForm = new ClienteAddForm(0);
            cliAddForm.WindowState = FormWindowState.Normal;
            cliAddForm.MdiParent = this;
            cliAddForm.Show();
        }

        private void novoSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareAddform softwareAddform = new SoftwareAddform(0);
            softwareAddform.WindowState = FormWindowState.Normal;
            softwareAddform.MdiParent = this;
            softwareAddform.Show();
        }

        private void gestaoSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SoftwareListForm softwareListForm = new SoftwareListForm();
            softwareListForm.WindowState = FormWindowState.Normal;
            softwareListForm.MdiParent = this;
            softwareListForm.Show();
        }

        private void gestaoDeContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratosListForm contratosForm = new ContratosListForm(this);
            contratosForm.WindowState = FormWindowState.Normal;
            contratosForm.MdiParent = this;
            contratosForm.Show();
        }

        private void novoContratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContratoAddForm contratoAddForm = new ContratoAddForm(0);
            contratoAddForm.WindowState = FormWindowState.Normal;
            contratoAddForm.MdiParent = this;
            contratoAddForm.Show();
        }

        private void gestaoDeLicencasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicencaListForm licencaList = new LicencaListForm();
            licencaList.WindowState = FormWindowState.Normal;
            licencaList.MdiParent = this;
            licencaList.Show();
        }

        private void gestaoDeBancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BancoListForm bancoListForm = new BancoListForm();
            bancoListForm.WindowState = FormWindowState.Normal;
            bancoListForm.MdiParent = this;
            bancoListForm.Show();
        }

        private void gruposToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GruposListForm grupoListForm = new GruposListForm();
            grupoListForm.WindowState = FormWindowState.Normal;
            grupoListForm.MdiParent = this;
            grupoListForm.Show();
        }
    }
}
