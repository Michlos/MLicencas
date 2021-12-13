using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Enderecos
{
    public partial class BairroAddForm : Form
    {
        private int ufId, cidadeId;

        //SERVICES
        public BairroAddForm(int ufId, int cidadeId)
        {
            InitializeComponent();
            this.ufId = ufId;
            this.cidadeId = cidadeId;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BairroAddForm_Load(object sender, EventArgs e)
        {

        }
    }
}
