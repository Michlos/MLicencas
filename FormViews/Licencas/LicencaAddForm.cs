using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.Seriais;
using InfraStructure.Repository.Softwares;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;
using ServicesLayer.Contratos;
using ServicesLayer.Seriais;
using ServicesLayer.Softwares;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Licencas
{
    public partial class LicencaAddForm : Form
    {
        private int licencaId;

        //SERVICES
        private QueryStringServices _queryString;
        private ContratosServices _contratosServices;
        private ClientesServices _clientesServices;
        private SoftwaresServices _softwaresServices;
        private SeriaisServices _licencasServices;


        public LicencaAddForm(int licencaId)
        {
            LoadServices();
            InitializeComponent();
            this.licencaId = licencaId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _licencasServices = new SeriaisServices(new SerialRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
    }
}
