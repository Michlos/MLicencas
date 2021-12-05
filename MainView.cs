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
        public MainView()
        {
            LoadLogin();
            InitializeComponent();
            
        }

        private void LoadLogin()
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuariosFormView usu = new UsuariosFormView();
            usu.Show();
        }
    }
}
