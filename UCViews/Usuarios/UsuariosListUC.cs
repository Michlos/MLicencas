using CommonComponents;

using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Usuarios;

using MLicencas.FormViews.Usuarios;

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

namespace MLicencas.UCViews.Usuarios
{
    public partial class UsuariosListUC : UserControl
    {
        //MODELS AND LISTMODELS
        private IEnumerable<IUsuarioModel> usuarioListModel;



        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;

        private UsuariosFormView UsuariosFormView;
        private int indexDgv;
        public int idUsuario;

        public UsuariosListUC(UsuariosFormView usuariosFormView)
        {
            this.UsuariosFormView = usuariosFormView;
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDGVUsuarios();
        }

        private void LoadDGVUsuarios()
        {


            DataTable tableUsuarios = ModelaTableGrid();
            DataRow row = ModelaRowTable(tableUsuarios, usuarioListModel);
            dgvUsuarios.DataSource = tableUsuarios;
            ConfiguraDataGridView();

        }


        private DataTable ModelaTableGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Login", typeof(string));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Cargo", typeof(string));
            table.Columns.Add("Ativo", typeof(bool));

            return table;

        }

        private DataRow ModelaRowTable(DataTable tableUsuarios, IEnumerable<IUsuarioModel> usuarioListModel)
        {
            DataRow row = null;
            if (usuarioListModel.Any())
            {
                foreach (var usuario in usuarioListModel)
                {
                    row = tableUsuarios.NewRow();
                    row["Id"] = usuario.Id;
                    row["Login"] = usuario.Login;
                    row["Nome"] = usuario.Nome;
                    row["Cargo"] = usuario.Cargo;
                    row["Ativo"] = bool.Parse(usuario.Ativo.ToString());

                    tableUsuarios.Rows.Add(row);
                }
            }
            return row;
        }
        private void ConfiguraDataGridView()
        {
            dgvUsuarios.Columns["Id"].Width = 30;
            dgvUsuarios.Columns["Ativo"].Width = 40;
            dgvUsuarios.Columns["Nome"].Width = 225;


        }

        private void LoadModels()
        {
            usuarioListModel = new List<IUsuarioModel>();
            usuarioListModel = (List<IUsuarioModel>)_usuariosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void dgvUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            indexDgv = e.RowIndex;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripUsuarioDGV.Show(MousePosition);
            }

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idUsuario = int.Parse(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());
            if (idUsuario != 0)
            {
                IUsuarioModel usuario = new UsuarioModel();
                usuario = usuarioListModel.Where(usuId => usuId.Id == idUsuario).FirstOrDefault();
                UsuarioEditFormView usuarioEdit = new UsuarioEditFormView(usuario, RequestType.Type.Edit);
                usuarioEdit.ShowDialog();
                LoadDGVUsuarios();
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            idUsuario = int.Parse(dgvUsuarios.CurrentRow.Cells[0].Value.ToString());

            if (idUsuario != 0)
            {
                this.UsuariosFormView.LoadPermissoesUserControl(idUsuario);
                //PermissoesListUC permissoes = new PermissoesListUC(idUsuario);
                //permissoes.usuario = usuarioListModel.Where(usuId => usuId.Id == idUsuario).FirstOrDefault();

            }
        }

        private void UsuariosListUC_Load(object sender, EventArgs e)
        {
            tsmiEditarUsuario.Enabled = MainView.CheckPermissoes(tsmiEditarUsuario.Tag);
            desativarToolStripMenuItem.Enabled = MainView.CheckPermissoes(desativarToolStripMenuItem.Tag);
            atviarToolStripMenuItem.Enabled = MainView.CheckPermissoes(atviarToolStripMenuItem.Tag);
            
        }

        private void atviarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente ativar a conta do usuário?", "Gestão de Usuários", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _usuariosServices.Enable(idUsuario);
                    MessageBox.Show("Conta Ativada com sucesso.", "Gestão de Usuários");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    LoadModels();
                    LoadDGVUsuarios();
                }
            }
        }

        private void desativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente Destaviar a conta do usuário?", "Gestão de Usuários", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _usuariosServices.Desable(idUsuario);
                    MessageBox.Show("Conta Desativada com sucesso.", "Gestão de Usuários");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    LoadModels();
                    LoadDGVUsuarios();
                }
            }
        }
    }
}
