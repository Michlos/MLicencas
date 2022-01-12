using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Usuarios;

using MLicencas.UCViews.Usuarios;

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

namespace MLicencas.FormViews.Usuarios
{
    public partial class GruposListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private PermissoesServices _permissoesServices;
        private GruposServices _gruposServices;

        //USER CONSTROLS
        private PermissoesGruposListUC permissoesGruposListUC;
        private GruposListUC gruposListUC;
        public GruposListForm()
        {
            LoadServices();
            InitializeComponent();
            LoadGruposUserControl();
        }

        private void LoadGruposUserControl()
        {
            gruposListUC = new GruposListUC(this);
            panelGruposList.Controls.Clear();
            panelGruposList.Controls.Add(gruposListUC);
            gruposListUC.Dock = DockStyle.Fill;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _permissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        internal void LoadPermissoesUserControl(int grupoId)
        {
            permissoesGruposListUC = new PermissoesGruposListUC(grupoId);
            panelAccessList.Controls.Clear();
            panelAccessList.Controls.Add(permissoesGruposListUC);
            permissoesGruposListUC.Dock = DockStyle.Fill;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in permissoesGruposListUC.permissoesAlteradas)
                {
                    if (item.Ativo)
                        _permissoesServices.Enable(item.Id);
                    else
                        _permissoesServices.Desable(item.Id);
                }
                MessageBox.Show("Alterações de permissão salvas com sucesso.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            IGrupoModel grupoModel = new GrupoModel();

        }
    }
}
