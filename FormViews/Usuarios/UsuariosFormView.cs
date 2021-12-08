using MLicencas.UCViews.Usuarios;

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
    public partial class UsuariosFormView : Form
    {
        public UsuariosFormView()
        {
            InitializeComponent();
        }

        private void usuariosListUC_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void UsuariosFormView_Load(object sender, EventArgs e)
        {
            LoadUsuariosUserControl();
            //LoadPermissoesUserControl();
        }

        public void LoadPermissoesUserControl(int usuarioId)
        {
            PermissoesListUC permissoesListUC = new PermissoesListUC(usuarioId);
            panelAccessList.Controls.Clear();
            panelAccessList.Controls.Add(permissoesListUC);
            permissoesListUC.Dock = DockStyle.Fill;
        }

        private void LoadUsuariosUserControl()
        {
            UsuariosListUC usuariosListUC = new UsuariosListUC(this);
            panelUsuariosList.Controls.Clear();
            panelUsuariosList.Controls.Add(usuariosListUC);
            usuariosListUC.Dock = DockStyle.Fill;
            
        }
    }
}
