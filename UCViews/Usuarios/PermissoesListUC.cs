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
    public partial class PermissoesListUC : UserControl
    {
        //MODELS AND LISTMODELS
        public IUsuarioModel usuario;
        private IGrupoModel grupo;
        private List<IModuloModel> moduloListModel;
        private List<IPermissaoModel> permissaoListModel;

        //SERVICES
        private QueryStringServices _queryString;
        private GruposServices _gruposServices;
        private ModulosServices _modulosServices;
        private PermissoesServices _persmissoesServices;


        public PermissoesListUC()
        {
            LoadServices();
            InitializeComponent();
            LoadModels();
            LoadDgvPermissoes();
        }

        private void LoadDgvPermissoes()
        {
            DataTable tablePermissoes = ModelaTableGrid();
            DataRow row = ModelaRowTable(tablePermissoes, permissaoListModel);
            dgvPermissoes.DataSource = tablePermissoes;
            ConfiguraDataGridView();
        }

        private void ConfiguraDataGridView()
        {
            dgvPermissoes.Columns["Id"].Visible = false;
            dgvPermissoes.Columns["ModuloId"].Visible = false;
            dgvPermissoes.Columns["GrupoId"].Visible = false;
            dgvPermissoes.Columns["Descrica"].Width = 100;
            dgvPermissoes.Columns["Nivel"].Width = 40;
            dgvPermissoes.Columns["Permite"].Width = 40;
        }

        private DataRow ModelaRowTable(DataTable table, List<IPermissaoModel> lista)
        {
            DataRow row = null;
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    row = table.NewRow();
                    row["Id"] = item.Id;
                    row["GrupId"] = item.GrupId;
                    row["ModuloId"] = item.ModuloId;
                    row["Descricao"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(desc => desc.Nome);
                    row["Nivel"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(niv => niv.Nivel);
                    row["Permite"] = item.Ativo;

                    table.Rows.Add(row);
                }
            }
            return row;
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
            grupo = _gruposServices.GetById(usuario.GrupoId);
            moduloListModel = (List<IModuloModel>)_modulosServices.GetAll();
            permissaoListModel = (List<IPermissaoModel>)_persmissoesServices.GetAllByGrupo(grupo.Id);
            
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _persmissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
    }
}
