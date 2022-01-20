using DomainLayer.Clientes.Contratos.Incisos;

using InfraStructure;
using InfraStructure.Repository.Incisos;

using ServiceLayer.CommonServices;

using ServicesLayer.Contratos.Incisos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MLicencas.FormViews.Contratos
{
    public partial class IncisoAddForm : Form
    {
        private readonly int clausulaId, incisoId;
        private QueryStringServices _queryString;
        private IncisosServices _incisosServices;

        private IIncisoModel incisoModel;
        private IEnumerable<IIncisoModel> incisoListModel = new List<IIncisoModel>();

        public IncisoAddForm(int clausulaId, int incisoId)
        {
            LoadServices();
            InitializeComponent();
            this.clausulaId = clausulaId;
            this.incisoId = incisoId;
            LoadModels();
            LoadFormFields();
        }
        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _incisosServices = new IncisosServices(new IncisoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }
        private void LoadModels()
        {
            incisoListModel = _incisosServices.GetAllByClausula(clausulaId);
        }
        private void picbSave_Click(object sender, EventArgs e)
        {
            incisoModel = new IncisoModel();
            incisoModel.Id = incisoId;
            incisoModel.Termo = txbTermo.Text;
            incisoModel.Numero = int.Parse(txbNumero.Text);
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

        private void UpdateInciso()
        {
            try
            {
                _incisosServices.Edit(incisoModel);
                MessageBox.Show("Termo Atualizado com sucesso.");
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                throw new Exception();
            }
        }

        private void AddInciso()
        {
            try
            {
                this.incisoModel = _incisosServices.Add(incisoModel);
                MessageBox.Show("Termo Adicionado com sucesso.");
                this.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Application.ProductName);
                throw new Exception();
            }
        }

        private void LoadFormFields()
        {
            if (incisoId != 0)
            {
                this.incisoModel = new IncisoModel();
                incisoModel = _incisosServices.GetById(incisoId);
                txbTermo.Text = this.incisoModel.Termo;
                txbNumero.Text = this.incisoModel.Numero.ToString();
            }
            else
            {
                if (incisoListModel.Any())
                {
                    txbNumero.Text = (incisoListModel.Last().Numero + 1).ToString();
                }
                else
                {
                    txbNumero.Text = "1";

                }
            }

        }
    }
}
