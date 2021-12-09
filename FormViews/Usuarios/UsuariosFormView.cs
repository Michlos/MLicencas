using CommonComponents;

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
    public partial class UsuariosFormView : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private PermissoesServices _permissoesServices;
        private UsuariosServices _usuariosServices;

        private PermissoesListUC permissoesListUC;
        private UsuariosListUC usuariosListUC;
        public UsuariosFormView()
        {
            LoadServices();
            InitializeComponent();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _permissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }


        private void UsuariosFormView_Load(object sender, EventArgs e)
        {
            LoadUsuariosUserControl();
            btnSave.Enabled = MainView.CheckPermissoes(btnSave.Tag);
            btnNovo.Enabled = MainView.CheckPermissoes(btnNovo.Tag);
            btnEditUsario.Enabled = MainView.CheckPermissoes(btnEditUsario.Tag);
        }

        public void LoadPermissoesUserControl(int usuarioId)
        {
            permissoesListUC = new PermissoesListUC(usuarioId);
            panelAccessList.Controls.Clear();
            panelAccessList.Controls.Add(permissoesListUC);
            permissoesListUC.Dock = DockStyle.Fill;
        }

        private void LoadUsuariosUserControl()
        {
            usuariosListUC = new UsuariosListUC(this);
            panelUsuariosList.Controls.Clear();
            panelUsuariosList.Controls.Add(usuariosListUC);
            usuariosListUC.Dock = DockStyle.Fill;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in permissoesListUC.permissoesAlteradas)
                {
                    if (item.Ativo)
                        _permissoesServices.Enable(item.Id);
                    else
                        _permissoesServices.Desable(item.Id);

                }
                MessageBox.Show("Alterações de permissão salvas com sucesso.", this.Text);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private void btnEditUsario_Click(object sender, EventArgs e)
        {
            IUsuarioModel usuario = new UsuarioModel();
            if (this.usuariosListUC.idUsuario != 0)
            {
                usuario = _usuariosServices.GetById(this.usuariosListUC.idUsuario);
                UsuarioEditFormView usuarioEdit = new UsuarioEditFormView(usuario, RequestType.Type.Edit);
                usuarioEdit.ShowDialog();
                LoadUsuariosUserControl();
            }
            else
            {
                MessageBox.Show("Selecione um usuário.", this.Text);
            }
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            IUsuarioModel usuario = new UsuarioModel();
            UsuarioEditFormView usuarioNovo = new UsuarioEditFormView(usuario, RequestType.Type.Add);
            usuarioNovo.ShowDialog();
            LoadUsuariosUserControl();
        }
    }
}
