using DomainLayer.Clientes;
using DomainLayer.Clientes.Contratos;
using DomainLayer.Clientes.Contratos.Seriais;
using DomainLayer.Softwares;

using GeradorHash;

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
using System.Data;
using System.Linq;
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

        //MODELS LISTMODELS
        private ISerialModel licencaModel = new SerialModel();
        private IContratoModel contratoModel = new ContratoModel();
        private IEnumerable<ISerialModel> licencaListModel = new List<ISerialModel>();
        private IEnumerable<IContratoModel> contratoListModel = new List<IContratoModel>();
        private readonly List<IClienteModel> clienteListModel = new List<IClienteModel>();
        private IEnumerable<ISoftwareModel> softwareListModel = new List<ISoftwareModel>();



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

        private void LicencaAddForm_Load(object sender, EventArgs e)
        {
            LoadModels();
            LoadCBCliente();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (licencaId != 0)
            {
                licencaModel = _licencasServices.GetById(licencaId);

                txbId.Text = licencaModel.Id.ToString();
                cbCliente.Text = clienteListModel.Where(id => id.Id == licencaModel.ClienteId).FirstOrDefault().NomeFantasia;
                //cbCliente.SelectedItem = _clientesServices.GetById(licencaModel.ClienteId).NomeFantasia;
                txbIdContrato.Text = licencaModel.ContratoId.ToString();
                mtbDtRegContrato.Text = contratoListModel.Where(id => id.Id == licencaModel.ContratoId).Select(dataReg => dataReg.DataRegistro).FirstOrDefault().ToShortDateString();
                mtbDtVencContrato.Text = contratoListModel.Where(id => id.Id == licencaModel.ContratoId).Select(dataVenc => dataVenc.DataVencimento).FirstOrDefault().ToShortDateString();
                txbNomeSoftware.Text = softwareListModel.Where(id => id.Id == licencaModel.SoftwareId).FirstOrDefault().Nome;
                mtxbChave.Text = licencaModel.Chave;
                mtxbHashChave.Text = licencaModel.HashChave;
                mtxbHashCliente.Text = licencaModel.HashCliente;
            }
        }

        private void LoadCBCliente()
        {
            //EXIBE SOMENTE CLIENTES QUE POSSUEM CONTRATOS ATIVOS




            cbCliente.DisplayMember = "NomeFantasia";
            clienteListModel.Clear();
            foreach (var item in contratoListModel)
            {
                cbCliente.Items.Add(_clientesServices.GetById(item.ClienteId));
                clienteListModel.Add(_clientesServices.GetById(item.ClienteId));
            }
            cbCliente.SelectedIndex = -1;
            //cbCliente.DataSource = clienteListModel;
        }

        private void LoadModels()
        {
            contratoListModel = _contratosServices.GetAll();
            softwareListModel = _softwaresServices.GetAll();
            licencaListModel = _licencasServices.GetAll();

        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            mtxbChave.Text = GetChave();
            mtxbHashChave.Text = GetSerial.GetHash(mtxbChave.Text + (cbCliente.SelectedItem as IClienteModel).Cnpj.Substring(0, 8) + (cbCliente.SelectedItem as IClienteModel).Cnpj.Substring(12, 2));
            mtxbHashCliente.Text = GetSerial.GetHash((cbCliente.SelectedItem as IClienteModel).Cnpj.Substring(0, 8) + (cbCliente.SelectedItem as IClienteModel).Cnpj.Substring(12, 2));
        }

        private string GetChave()
        {
            string serialToReturn = string.Empty;

            string[] serial = GetSerial.Get(4);
            string serialGen = string.Empty;
            foreach (var item in serial)
            {
                serialGen += item.ToString();
            }
            serialToReturn = serialGen;



            foreach (var item in licencaListModel)
            {
                if (item.Chave == serialGen)
                {
                    serial = GetSerial.Get(4);
                    serialGen = string.Empty;
                    foreach (var s in serial)
                    {
                        serialGen += item.ToString();
                    }
                }
                else
                {
                    serialToReturn = serialGen;
                }
            }

            return serialToReturn;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            licencaModel = new SerialModel();
            licencaModel.Chave = mtxbChave.Text;
            licencaModel.ClienteId = (cbCliente.SelectedItem as IClienteModel).Id;
            licencaModel.ContratoId = int.Parse(txbIdContrato.Text);
            licencaModel.HashChave = mtxbHashChave.Text;
            licencaModel.HashCliente = mtxbHashCliente.Text;
            licencaModel.SoftwareId = contratoModel.SoftwareId;


            if (licencaId != 0)
            {
                UpdateSerial();
            }
            else
            {
                AddSerial();
            }
        }

        private void AddSerial()
        {
            try
            {
                licencaModel = _licencasServices.Add(licencaModel);
                licencaId = licencaModel.Id;
                MessageBox.Show("Licença gerada com sucesso.");
                LoadModels();
                LoadFormFields();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
        }

        private void UpdateSerial()
        {

            try
            {

                _licencasServices.Renew(licencaModel);
                MessageBox.Show("Licença renovada com sucesso");
            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e.InnerException);
            }

        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCliente.SelectedIndex >= 0)
            {

                //SE CLIENTE POSSUI MAIS DE UM CONTRATO CHAMA A TELA PARA SELECIONAR UM CONTRATO.

                if (contratoListModel.Where(cli => cli.ClienteId == (cbCliente.SelectedItem as IClienteModel).Id).Count() > 1)
                {
                    //SELECIONE O CONTRATO DESEJADO.

                }
                else
                {

                    contratoModel = contratoListModel.Where(cliId => cliId.ClienteId == (cbCliente.SelectedItem as IClienteModel).Id).FirstOrDefault();
                    txbIdContrato.Text = contratoModel.Id.ToString();
                    mtbDtRegContrato.Text = contratoModel.DataRegistro.ToShortDateString();
                    mtbDtVencContrato.Text = contratoModel.DataVencimento.ToShortDateString();
                    txbNomeSoftware.Text = softwareListModel.Where(id => id.Id == contratoModel.SoftwareId).FirstOrDefault().Nome;
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
