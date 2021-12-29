using InfraStructure;

using ServiceLayer.CommonServices;

using ServicesLayer.Bancos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Banco
{
    public partial class BancoListForm : Form
    {
        //SERVICES
        QueryStringServices _queryString;
        BancosServices _bancosServices;
        public BancoListForm()
        {
            LoadServices();
            InitializeComponent();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BancoListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
