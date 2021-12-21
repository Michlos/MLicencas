using DomainLayer.Clientes.Contratos.Clausulas;

using InfraStructure;
using InfraStructure.Repository.Clausulas;

using ServiceLayer.CommonServices;

using ServicesLayer.Clausulas;

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
    public partial class ContratoClausulaUC : UserControl
    {
        private int ordem, contratoId, clausulaId;
        private QueryStringServices _queryString;
        private ClausulasServices _clausulasServices;

        private IClausulaModel clauModel;

        public ContratoClausulaUC(int contratoId, int ordem, int clausulaId)
        {
            LoadServices();
            InitializeComponent();
            this.contratoId = contratoId;
            this.ordem = ordem;
            this.clausulaId = clausulaId;
            txbOrdem.Text = this.ordem.ToString();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _clausulasServices = new ClausulasServices(new ClausulaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void picbSave_Click(object sender, EventArgs e)
        {
            clauModel = new ClausulaModel();
            clauModel.Id = clausulaId;
            clauModel.Titulo = txbTitulo.Text;
            clauModel.Ordem = int.Parse(txbOrdem.Text);

            if (clausulaId != 0)
            {
                UpdateClausula();
            }
            else
            {
                AddClausula();
            }
        }


        private void AddClausula()
        {
            try
            {
                this.clauModel = _clausulasServices.Add(clauModel);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                throw new Exception();
            }
        }

        private void UpdateClausula()
        {
            try
            {
                _clausulasServices.Edit(clauModel);
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
            if (clausulaId != 0)
            {
                this.clauModel = new ClausulaModel();
                clauModel = _clausulasServices.GetById(clausulaId);
                txbId.Text = this.clauModel.Id.ToString();
                txbTitulo.Text = this.clauModel.Titulo;
                txbOrdem.Text = this.clauModel.Ordem.ToString();
            }

        }
    }
}
