using CommonComponents;

using DomainLayer.Usuarios;

using InfraStructure;
using InfraStructure.Repository.Usuarios;

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
    public partial class UsuarioEditFormView : Form
    {

        //MODELS LISTMODELS
        private IUsuarioModel usuario;
        private RequestType.Type requestType;

        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;

        public UsuarioEditFormView(IUsuarioModel usuario, RequestType.Type requestType)
        {
            LoadServices();
            InitializeComponent();
            this.usuario = usuario;
            this.requestType = requestType;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
    }
}
