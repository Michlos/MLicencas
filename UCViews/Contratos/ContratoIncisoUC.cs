using DomainLayer.Clientes.Contratos.Clausulas;
using DomainLayer.Clientes.Contratos.Incisos;

using InfraStructure;
using InfraStructure.Repository.Clausulas;
using InfraStructure.Repository.Incisos;

using ServiceLayer.CommonServices;

using ServicesLayer.Clausulas;
using ServicesLayer.Contratos.Incisos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.UCViews.Contratos
{
    public partial class ContratoIncisoUC : UserControl
    {
        private int clausulaId, incisoId;
        private QueryStringServices _queryString;
        private IncisosServices _incisosServices;

        private IIncisoModel incisoModel;

        public ContratoIncisoUC()
        {

        }

        public ContratoIncisoUC(int clausulaId, int incisoId)
        {
            LoadServices();
            InitializeComponent();
            this.clausulaId = clausulaId;
            this.incisoId = incisoId;
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _incisosServices = new IncisosServices(new IncisoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void picbSave_Click(object sender, EventArgs e)
        {
            incisoModel = new IncisoModel();
            incisoModel.Id = incisoId;
            incisoModel.Termo = txbTermo.Text;
            incisoModel.ClausulaId = clausulaId;

            if (incisoId != 0)
            {
                UpdateInciso();
            }
            else
            {
                AddInciso();
            }
        }


        private void AddInciso()
        {
            try
            {
                this.incisoModel = _incisosServices.Add(incisoModel);
                MessageBox.Show("Termo Adicionado com sucesso.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                throw new Exception();
            }
        }

        private void UpdateInciso()
        {
            try
            {
                _incisosServices.Edit(incisoModel);
                MessageBox.Show("Termo Atualizado com sucesso.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                throw new Exception();
            }
        }
        private void ContratoClausulaUC_Load(object sender, EventArgs e)
        {
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (incisoId != 0)
            {
                this.incisoModel = new IncisoModel();
                incisoModel = _incisosServices.GetById(incisoId);
                txbTermo.Text = this.incisoModel.Termo;
            }

        }
    }
}
