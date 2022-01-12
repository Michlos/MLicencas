using DomainLayer.Modulos;
using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Modulos;
using InfraStructure.Repository.Usuarios;

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
    public partial class PermissoesGruposListUC : UserControl
    {
        //MODELS AND LISTMODELS
        private IGrupoModel grupoModel;
        private readonly int grupoId;
        private List<IModuloModel> moduloListModel;
        private List<IPermissaoModel> permissaoListModel;
        public List<IPermissaoModel> permissoesAlteradas = new List<IPermissaoModel>();

        //SERVICES
        private QueryStringServices _queryString;
        private GruposServices _gruposServices;
        private ModulosServices _modulosServices;
        private PermissoesServices _permissoesServices;

        public PermissoesGruposListUC(int grupoId)
        {
            this.grupoId = grupoId;
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDGVPermissoes();
        }

        private void LoadDGVPermissoes()
        {
            DataTable tablePermissoes = ModelaTableGrid();
            ModelaRowTable(tablePermissoes, permissaoListModel);
            dgvPermissoes.DataSource = tablePermissoes;
            ConfiguraDataGridView();
        }

        private void ConfiguraDataGridView()
        {
            dgvPermissoes.Columns["Id"].Visible = false;
            dgvPermissoes.Columns["ModuloId"].Visible = false;
            dgvPermissoes.Columns["GrupoId"].Visible = false;

            dgvPermissoes.Columns["Descricao"].Width = 150;
            dgvPermissoes.Columns["Descricao"].HeaderText = "Descrição";
            dgvPermissoes.Columns["Descricao"].ReadOnly = true;
            dgvPermissoes.Columns["Nivel"].Width = 40;
            dgvPermissoes.Columns["Nivel"].HeaderText = "Nível";
            dgvPermissoes.Columns["Nivel"].ReadOnly = true;
            dgvPermissoes.Columns["Permite"].Width = 50;
            dgvPermissoes.Columns["Permite"].HeaderText = "Permite";
            dgvPermissoes.Columns["Permite"].ReadOnly = !MainView.CheckPermissoes("6.3");
        }

        private void ModelaRowTable(DataTable tablePermissoes, List<IPermissaoModel> permissaoListModel)
        {
            DataRow row = null;
            if (permissaoListModel.Any())
            {
                foreach (var item in permissaoListModel)
                {
                    row = tablePermissoes.NewRow();
                    row["Id"] = item.Id;
                    row["GrupoId"] = item.GrupId;
                    row["ModuloId"] = item.ModuloId;
                    row["Descricao"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(desc => desc.Nome).FirstOrDefault();
                    row["Nivel"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(niv => niv.Nivel).FirstOrDefault();
                    row["Permite"] = item.Ativo;

                    tablePermissoes.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableGrid()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("GrupoId", typeof(int));
            table.Columns.Add("ModuloId", typeof(int));
            table.Columns.Add("Descricao", typeof(string));
            table.Columns.Add("Nivel", typeof(string));
            table.Columns.Add("Permite", typeof(bool));

            return table;
        }

        private void LoadModels()
        {
            grupoModel = _gruposServices.GetById(grupoId);
            moduloListModel = (List<IModuloModel>)_modulosServices.GetAll();
            permissaoListModel = (List<IPermissaoModel>)_permissoesServices.GetAllByGrupo(grupoId);
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _permissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void dgvPermissoes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPermissoes.Columns["Permite"].Index)
            {
                int id = int.Parse(dgvPermissoes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                IPermissaoModel permissao = new PermissaoModel();
                permissao = _permissoesServices.GetById(id);
                permissao.Ativo = bool.Parse(dgvPermissoes.Rows[e.RowIndex].Cells["Permite"].Value.ToString());
                permissoesAlteradas.Add(permissao);
            }
        }
    }
}
