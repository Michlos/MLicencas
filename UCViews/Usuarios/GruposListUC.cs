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
    public partial class GruposListUC : UserControl
    {
        //MODEL
        private IEnumerable<IGrupoModel> grupoListModel;

        //SERVICES
        private QueryStringServices _queryString;
        private GruposServices _gruposServices;
        
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
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            
        }

        private void dgvGrupos_SelectionChanged(object sender, EventArgs e)
        {
            grupoId = int.Parse(dgvGrupos.CurrentRow.Cells[0].Value.ToString());

            if (grupoId != 0)
            {
                grupoListForm.LoadPermissoesUserControl(grupoId);
            }
        }
    }
}
