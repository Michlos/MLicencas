using MLicencas.UCViews.Contratos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Contratos
{
    public partial class IncludeItemContratoForm : Form
    {
        private readonly Control Control;
        private readonly ContratoClausulaUC clausulaUC = new ContratoClausulaUC();
        public IncludeItemContratoForm(Control control)
        {
            InitializeComponent();
            this.Control = control;
            LoadUserControl();
        }

        private void LoadUserControl()
        {
            pnlContainer.Controls.Clear();
            if (Control.GetType() == clausulaUC.GetType())
            {
                pnlContainer.Controls.Add(Control);
                this.Width = 500;
                this.Height = 100;
                this.Text = "Cláusulas - Inclusão";
            }
            else
            {
                pnlContainer.Controls.Add(Control);
                this.Width = 500;
                this.Height = 250;
                this.Text = "Termos - Inclusão";
            }
        }
    }
}
