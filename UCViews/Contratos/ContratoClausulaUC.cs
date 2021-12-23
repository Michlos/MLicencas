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
        private readonly int contratoId, clausulaId;
        private QueryStringServices _queryString;
        private ClausulasServices _clausulasServices;

        private IClausulaModel clauModel;
        private IEnumerable<IClausulaModel> clausulaListModel = new List<IClausulaModel>();

        public ContratoClausulaUC()
        {

        }

        public ContratoClausulaUC(int contratoId, int clausulaId)
        {
            LoadServices();
            InitializeComponent();
            this.contratoId = contratoId;
            this.clausulaId = clausulaId;
            LoadModels();
        }

        private void LoadModels()
        {
            clausulaListModel = _clausulasServices.GetAllByContratoId(contratoId);
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
            clauModel.Numero = int.Parse(txbNumero.Text);
            clauModel.Titulo = txbTitulo.Text;
            clauModel.ContratoId = contratoId;

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
                MessageBox.Show("Cláusula Adicionada com sucesso.");
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
                MessageBox.Show("Cláusula Atualizada com sucesso.");
                
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

        private void txbNumero_Enter(object sender, EventArgs e)
        {
            MessageBox.Show($"O Número \"{txbNumero.Text}\" foi sugerido conforme\n a lista de clausulas existentes.\nTenha cautela ao alterá-lo.");
        }

        private void LoadFormFields()
        {
            if (clausulaId != 0)
            {
                this.clauModel = new ClausulaModel();
                clauModel = _clausulasServices.GetById(clausulaId);
                txbTitulo.Text = this.clauModel.Titulo;
                txbNumero.Text = this.clauModel.Numero.ToString();
            }
            else
            {
                if (clausulaListModel.Any())
                {
                    txbNumero.Text = (clausulaListModel.Last().Numero + 1).ToString();
                }
                else
                {
                    txbNumero.Text = "1";
                }
            }

        }
    }
}
