using DomainLayer.Financeiro;
using DomainLayer.Financeiro.Bancos.ContaBancaria;

using InfraStructure;
using InfraStructure.Repository.Bancos;
using InfraStructure.Repository.ContaBancaria;
using InfraStructure.Repository.LancamentosContasBancarias;
using InfraStructure.Repository.TipoLancamento;

using ServiceLayer.CommonServices;

using ServicesLayer.Bancos;
using ServicesLayer.ContasBancarias;
using ServicesLayer.LancamentosContasBancarias;
using ServicesLayer.TiposLancamentos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financeiro.Banco.LancamentoBancario
{
    public partial class LancamentoBancarioForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private BancosServices _bancosServices;
        private ContasBancariasServices _contasServices;
        private LancamentosContasBancariasServices _lancamentosServices;
        private TiposLancamentosServices _tiposLancamentosServices;

        //MODELS LISTMODELS
        public IContaBancariaModel contaModel;
        private IBancoModel bancoModel;
        private IEnumerable<ILancamentoContaBancariaModel> lancamentoListModel;
        private IEnumerable<ILancamentoContaBancariaModel> lancamentoListModelFiltrado;
        private IEnumerable<ITipoLancamentoModel> tipoLancamentoListModel;


        public LancamentoBancarioForm()
        {
            LoadServices();
            InitializeComponent();
            LoadOffHandle();

        }

        private void LoadOffHandle()
        {
            SelectContaForm selectConta = new SelectContaForm(this);
            selectConta.ShowDialog();
            if (contaModel == null)
            {
                this.Close();
            }
            else
            {

                LoadModels();
                LoadFormFields();
                LoadDGVLancamentos();
                CalculaSaldo();
                CalculaTotalExtrato();
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _bancosServices = new BancosServices(new BancoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _contasServices = new ContasBancariasServices(new ContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _lancamentosServices = new LancamentosContasBancariasServices(new LancamentoContaBancariaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _tiposLancamentosServices = new TiposLancamentosServices(new TipoLancamentoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void dgvLancamentos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void LoadFormFields()
        {
            txbBanco.Text = bancoModel.Nome;
            txbAgencia.Text = contaModel.Agencia + (!string.IsNullOrEmpty(contaModel.AgenciaDV.Trim()) ? "-" + contaModel.AgenciaDV : "");
            txbConta.Text = contaModel.Conta + (!string.IsNullOrEmpty(contaModel.ContaDV) ? "-" + contaModel.ContaDV : "");
            dtpDataInicial.Value = DateTime.Parse(("01/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString()));
            dtpDataFinal.Value = DateTime.Now;
        }

        private void LoadDGVLancamentos()
        {
            DataTable tableLancamentos = ModelaTableLancamentos();
            ModelaDataRow(tableLancamentos);
            dgvLancamentos.DataSource = tableLancamentos;
            ConfigDataGridLancamentos();
        }

        private void ConfigDataGridLancamentos()
        {
            dgvLancamentos.Columns["Id"].Visible = false;

            dgvLancamentos.Columns["Data"].Width = 100;
            dgvLancamentos.Columns["Historico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLancamentos.Columns["Historico"].HeaderText = "Histórico";
            dgvLancamentos.Columns["Valor"].Width = 150;
            dgvLancamentos.Columns["Estorno"].Width = 50;
        }

        private void ModelaDataRow(DataTable tableLancamentos)
        {
            if (lancamentoListModelFiltrado.Any())
            {
                foreach (var item in lancamentoListModelFiltrado)
                {
                    DataRow row = tableLancamentos.NewRow();
                    row["Id"] = item.Id;
                    row["Data"] = item.DataLancamento;
                    row["Historico"] = item.Historico;
                    row["Valor"] = item.Valor.ToString("C2");
                    row["Estorno"] = item.Estornado ? "X" : "";

                    tableLancamentos.Rows.Add(row);
                }
            }
        }

        private DataTable ModelaTableLancamentos()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Data", typeof(DateTime));
            table.Columns.Add("Historico", typeof(string));
            table.Columns.Add("Valor", typeof(string));
            table.Columns.Add("Estorno", typeof(string));

            return table;
        }

        private void LoadModels()
        {
            bancoModel = _bancosServices.GetById(contaModel.BancoId);
            lancamentoListModel = _lancamentosServices.GetAllByContaId(contaModel.Id);
            lancamentoListModelFiltrado = lancamentoListModel;
            tipoLancamentoListModel = _tiposLancamentosServices.GetAll();

        }


        private void CalculaSaldo()
        {
            double saldoConta = contaModel.SaldoAtual;
            //saldoConta += lancamentoListModel.Where(tipo => tipo.TipoLancamentoId ==
            //                        tipoLancamentoListModel.FirstOrDefault(t => t.Tipo == 'C').Id)
            //                        .Sum(saldo => saldo.Valor);
            //saldoConta -= lancamentoListModel.Where(tipo => tipo.TipoLancamentoId ==
            //                     tipoLancamentoListModel.FirstOrDefault(t => t.Tipo == 'D').Id)
            //                        .Sum(saldo => saldo.Valor);
            txbSaldo.Text = saldoConta.ToString("C2");
            if (saldoConta < 0)
            {
                txbSaldo.BackColor = Color.Red;
                txbSaldo.ForeColor = Color.White;
            }
            else
            {
                txbSaldo.BackColor = Color.PaleGreen;
                txbSaldo.ForeColor = Color.Black;
            }
        }


        private void FiltraLancamentoPorData()
        {
            if (dtpDataFinal.Value > dtpDataInicial.Value)
            {
                lancamentoListModelFiltrado = lancamentoListModel.Where(data => data.DataLancamento >= dtpDataInicial.Value && data.DataLancamento <= dtpDataFinal.Value);
                CalculaTotalExtrato();
            }
            else
            {
                MessageBox.Show("Data Final não pode ser menor que Data Inicial");
            }
        }

        private void CalculaTotalExtrato()
        {
            double saldoConta = lancamentoListModelFiltrado.Where(tipo => tipo.TipoLancamentoId ==
                                   tipoLancamentoListModel.FirstOrDefault(t => t.Tipo == 'C').Id)
                                   .Sum(saldo => saldo.Valor);
            saldoConta -= lancamentoListModelFiltrado.Where(tipo => tipo.TipoLancamentoId ==
                                 tipoLancamentoListModel.FirstOrDefault(t => t.Tipo == 'D').Id)
                                    .Sum(saldo => saldo.Valor);
            txbTotalExtrato.Text = saldoConta.ToString("C2");
            if (saldoConta < 0)
            {
                txbTotalExtrato.BackColor = Color.Red;
                txbTotalExtrato.ForeColor = Color.White;
            }
            else
            {
                txbTotalExtrato.BackColor = Color.PaleGreen;
                txbTotalExtrato.ForeColor = Color.Black;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangeConta_Click(object sender, EventArgs e)
        {
            LoadOffHandle();
        }

        private void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            FiltraLancamentoPorData();
        }

        private void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            FiltraLancamentoPorData();
        }
    }
}
