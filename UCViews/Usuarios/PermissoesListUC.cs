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
        private int idUsuario;
        private IGrupoModel grupo;
        //private List<IGrupoModel> grupoListModel;
        private List<IModuloModel> moduloListModel;
        private List<IPermissaoModel> permissaoListModel;

        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;
        private GruposServices _gruposServices;
        private ModulosServices _modulosServices;
        private PermissoesServices _persmissoesServices;


        public PermissoesListUC(int idUsuario)
        {
            this.idUsuario = idUsuario;
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
            dgvPermissoes.Columns[0].Visible = false;
            dgvPermissoes.Columns[0].HeaderText = "Id";
            dgvPermissoes.Columns[1].Visible = false;
            dgvPermissoes.Columns[1].HeaderText = "ModuloId";
            dgvPermissoes.Columns[2].Visible = false;
            dgvPermissoes.Columns[2].HeaderText = "GrupoId";

            dgvPermissoes.Columns[3].Width = 150;
            dgvPermissoes.Columns[3].HeaderText = "Descrição";
            dgvPermissoes.Columns[4].Width = 40;
            dgvPermissoes.Columns[4].HeaderText = "Nível";
            dgvPermissoes.Columns[5].Width = 50;
            dgvPermissoes.Columns[5].HeaderText = "Permite";
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
                    row["GrupoId"] = item.GrupId;
                    row["ModuloId"] = item.ModuloId;
                    row["Descricao"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(desc => desc.Nome).FirstOrDefault();
                    row["Nivel"] = moduloListModel.Where(modId => modId.Id == item.ModuloId).Select(niv => niv.Nivel).FirstOrDefault();
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
            usuario = _usuariosServices.GetById(idUsuario);
            grupo = _gruposServices.GetById(usuario.GrupoId);
            moduloListModel = (List<IModuloModel>)_modulosServices.GetAll();
            permissaoListModel = (List<IPermissaoModel>)_persmissoesServices.GetAllByGrupo(grupo.Id);
            
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _modulosServices = new ModulosServices(new ModuloRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _persmissoesServices = new PermissoesServices(new PermissaoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
    }
}
