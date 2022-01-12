using DomainLayer.Modulos;
using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Modulos;
using InfraStructure.Repository.Usuarios;

using MLicencas.FormViews.Usuarios;

using ServiceLayer.CommonServices;

using ServicesLayer.Modulos;
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
    public partial class GruposListUC : UserControl
    {
        //MODEL
        private IEnumerable<IGrupoModel> grupoListModel;
        private IEnumerable<IModuloModel> moduloListModel;
        private IEnumerable<IPermissaoModel> permissaoListModel;

        //SERVICES
        private QueryStringServices _queryString;
        private GruposServices _gruposServices;
        private ModulosServices _modulosServices;
        private PermissoesServices _permissoesServices;
        
        private readonly GruposListForm grupoListForm;
        public int grupoId;

        public GruposListUC(GruposListForm grupoListForm)
        {
            this.grupoListForm = grupoListForm;
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDGVGrupos();
        }

        private void LoadDGVGrupos()
        {
            DataTable tableGrupos = MoelaTableGrid();
            ModelaRowTable(tableGrupos, grupoListModel);
            dgvGrupos.DataSource = tableGrupos;
            ConfigDataGridView();
        }

        private void ConfigDataGridView()
        {
            dgvGrupos.Columns["Id"].Width = 30;
            dgvGrupos.Columns["Ativo"].Width = 40;
            dgvGrupos.Columns["Nome"].Width = 225;
        }

        private void ModelaRowTable(DataTable tableGrupos, IEnumerable<IGrupoModel> grupoListModel)
        {
            DataRow row = null;
            if (grupoListModel.Any())
            {
                foreach (var grupo in grupoListModel)
                {
                    row = tableGrupos.NewRow();
                    
                    row["Id"] = grupo.Id;
                    row["Nome"] = grupo.Nome;
                    row["Ativo"] = bool.Parse(grupo.Ativo.ToString());
                    
                    tableGrupos.Rows.Add(row);
                }
            }
        }

        private DataTable MoelaTableGrid()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Nome", typeof(string));
            table.Columns.Add("Ativo", typeof(bool));
            return table;
        }

        private void LoadModels()
        {
            grupoListModel = new List<IGrupoModel>();
            grupoListModel = (List<IGrupoModel>)_gruposServices.GetAll();

            moduloListModel = new List<IModuloModel>();
            moduloListModel = (List<IModuloModel>)_modulosServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _permissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            
        }

        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            grupoId = int.Parse(dgvGrupos.CurrentRow.Cells[0].Value.ToString());

            if (grupoId != 0)
            {
                grupoListForm.LoadPermissoesUserControl(grupoId);
            }
        }

        private void dgvGrupos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void desativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Deseja realmente desativar esse grupo?", "Gestão de Usuários", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    IGrupoModel grupoModel = new GrupoModel();
                    grupoModel = _gruposServices.GetById(grupoId);
                    grupoModel.Ativo = false;
                    _gruposServices.Edit(grupoModel);
                    MessageBox.Show("Grupo desativado com sucesso.");
                    
                    permissaoListModel = _permissoesServices.GetAllByGrupo(grupoId);

                    //DESATIVANDO PERMISSÕES DO GRUPO
                    foreach (var item in permissaoListModel)
                    {
                        _permissoesServices.Desable(item.Id);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
                finally
                {
                    LoadModels();
                    LoadDGVGrupos();
                }
            }
        }

        private void ativarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IGrupoModel grupoModel = new GrupoModel();
                grupoModel = _gruposServices.GetById(grupoId);
                grupoModel.Ativo = true;
                _gruposServices.Edit(grupoModel);
                MessageBox.Show("Grupo Ativado com sucesso.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex.InnerException);
            }
            finally
            {
                LoadModels();
                LoadDGVGrupos();
            }
        }
    }
}
