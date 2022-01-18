using DomainLayer.Clientes.Contratos;
using DomainLayer.Financeiro.Recebiveis;

using InfraStructure;
using InfraStructure.Repository.Clientes;
using InfraStructure.Repository.Contratos;
using InfraStructure.Repository.IntegracaoBancaria;
using InfraStructure.Repository.TitulosRecebiveis;

using ServiceLayer.CommonServices;

using ServicesLayer.ClientesServices;
using ServicesLayer.Contratos;
using ServicesLayer.Integracao.Bancaria;
using ServicesLayer.TitulosRecebiveis;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Titulos.Recebiveis
{
    public partial class TitulosRecebiveisListForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private TitulosRecebiveisServices _titulosRecebiveisServices;
        private ClientesServices _clientesServices;
        private ContratosServices _contratosServices;
        private IntegracaoBancariaServices _integracaoBancariaServices;


        //MODELS AND LISTMODELS
        private IEnumerable<ITituloRecebivelModel> titulosListModel;
        private readonly List<string> monthList = new List<string>();


        public TitulosRecebiveisListForm()
        {
            LoadServices();
            InitializeComponent();
            LoadComboBoxMonths();
            LoadModels();
            LoadDGVTitulos();
        }

        private void LoadDGVTitulos()
        {
            DataTable tableTitulos = ModelaTableTitulos();
            ModelaRowTableTitulos(tableTitulos);
            dgvRecebiveis.DataSource = tableTitulos;
            ConfigDGVTitulos();
        }

        private void ConfigDGVTitulos()
        {
            dgvRecebiveis.Columns["Id"].Visible = false;
            dgvRecebiveis.Columns["ClienteId"].Visible = false;
            dgvRecebiveis.Columns["Cliente"].Width = 200;
            dgvRecebiveis.Columns["Vencimento"].Width = 80;
            dgvRecebiveis.Columns["Parcela"].Width = 50;
            dgvRecebiveis.Columns["Valor"].Width = 100;

        }

        private void ModelaRowTableTitulos(DataTable tableTitulos)
        {
            if (titulosListModel.Any())
            {
                foreach (var item in titulosListModel)
                {
                    DataRow row = tableTitulos.NewRow();

                    row["Id"] = item.Id;
                    row["ClienteId"] = item.ClienteId;
                    row["Cliente"] = _clientesServices.GetById(item.ClienteId).RazaoSocial;
                    row["Vencimento"] = item.DataVencimento;
                    row["Parcela"] = item.Parcela + "/" + item.TotalParcelas;
                    row["Valor"] = item.ValorParcela.ToString("C2");

                    tableTitulos.Rows.Add(row);

                }
            }
        }

        private DataTable ModelaTableTitulos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("ClienteId", typeof(int));
            table.Columns.Add("Cliente", typeof(string));
            table.Columns.Add("Vencimento", typeof(DateTime));
            table.Columns.Add("Parcela", typeof(string));
            table.Columns.Add("Valor", typeof(string));

            return table;
        }

        private void LoadComboBoxMonths()
        {
            for (int i = 1; i <= 13; i++)
            {
                monthList.Add(DateTimeFormatInfo.CurrentInfo.GetMonthName(i).ToUpper());
            }

            cbMesFiltro.DataSource = monthList;
            cbMesFiltro.SelectedItem = DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month).ToUpper();
        }

        private void LoadModels()
        {
            titulosListModel = _titulosRecebiveisServices.GetAll();
            //TRAZ APENAS TÍTULOS EM ABERTO
            titulosListModel = titulosListModel.Where(quitado => !quitado.Quitado);
            //APLICA FILTRO DE DATA
            titulosListModel = titulosListModel.Where(dataVenc => dataVenc.DataVencimento.Month <= cbMesFiltro.SelectedIndex + 1); //checar o mes que vem
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _titulosRecebiveisServices = new TitulosRecebiveisServices(new TituloRecebivelRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _clientesServices = new ClientesServices(new ClienteRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contratosServices = new ContratosServices(new ContratoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _integracaoBancariaServices = new IntegracaoBancariaServices(new IntegracaoBancariaRepository(_queryString.GetQueryApp()));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGerarTitulo_Click(object sender, EventArgs e)
        {
            IEnumerable<IContratoModel> contratoListModel = _contratosServices.GetAll();
            List<ITituloRecebivelModel> titulosNaoGeradosListModel = new List<ITituloRecebivelModel>();
            IEnumerable<ITituloRecebivelModel> titulosNaoFiltrados = _titulosRecebiveisServices.GetAll();
            foreach (var item in contratoListModel)
            {
                if (!titulosNaoFiltrados.Any(contrato => contrato.ContratoId == item.Id))
                {
                    for (int i = 0; i < item.Parcelas; i++)
                    {

                        ITituloRecebivelModel model = new TituloRecebivelModel()
                        {
                            ClienteId = item.ClienteId,
                            ContratoId = item.Id,
                            CodigoJurosMoraId = _integracaoBancariaServices.GetC018_CodigoJuro().FirstOrDefault(codigo => codigo.Codigo == 1).Id,
                            CodigoProtestoId = _integracaoBancariaServices.GetC026_CodigoProtesto().FirstOrDefault(codigo => codigo.Codigo == 3).Id,
                            Parcela = i + 1,
                            TotalParcelas = item.Parcelas,
                            DataVencimento = DateTime.Parse(item.DataVencimento.Day.ToString() + "/" + (item.DataVencimento.Month + i).ToString() + "/" + item.DataVencimento.Year.ToString()),
                            DataJurosMora = DateTime.Parse((item.DataVencimento.Day + 1).ToString() + "/" + (item.DataVencimento.Month).ToString() + "/" + (item.DataVencimento.Year).ToString()),
                            TaxaJurosMora = 2.0,

                        };
                    }

                }
            }
            LoadModels();
            LoadDGVTitulos();
        }

        private void cbMesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadModels();
            LoadDGVTitulos();
        }

        private void btnBoleto_Click(object sender, EventArgs e)
        {
            //CHAMAR OPÇÃO DE SELECIONAR TODOS DO MÊS OU SÓ UM.
            var result = MessageBox.Show("Gera boleto para Todos os Títulos?", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //GERA PARA TODOS OS REGISTROS LISTADOS QUE AINDA NÃO FORAM GERADOS BOLETOS
                try
                {

                    foreach (var item in titulosListModel)
                    {
                        if (!item.BoletoBancario)
                        {
                            item.BoletoBancario = true;
                            _titulosRecebiveisServices.Edit(item);
                            //TODO: INTEGRAÇÃO BANCÁRIA GERAR ARQUIVO E ENVIAR PARA O BANCO.

                        }
                    }
                    MessageBox.Show("Boletos Registrados com Sucesso", this.Text);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message, ex.InnerException);
                }

            }
            else if (result == DialogResult.No)
            {
                //GERA APENAS PARA O ITEM SELECIONADO
                if (dgvRecebiveis.CurrentRow != null)
                {
                    int idTitulo = int.Parse(dgvRecebiveis.CurrentRow.Cells["Id"].Value.ToString());
                    ITituloRecebivelModel model = _titulosRecebiveisServices.GetById(idTitulo);
                    if (!model.BoletoBancario)
                    {
                        model.BoletoBancario = true;
                        try
                        {
                            _titulosRecebiveisServices.Edit(model);
                            MessageBox.Show("Boleto Registrado com Sucesso", this.Text);
                            //TODO: Gerar arquivo bancário e enviar para o banco.

                        }
                        catch (Exception ex)
                        {

                            throw new Exception(ex.Message, ex.InnerException);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Boleto já gerado anteriormente", this.Text);
                    }
                }
            }
            else
            {
                MessageBox.Show("Geração de Boleto Abortada", this.Text);
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {

        }
    }
}
