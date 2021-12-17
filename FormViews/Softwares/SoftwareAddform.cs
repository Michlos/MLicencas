using CommonComponents;

using DomainLayer.Softwares;
using DomainLayer.Softwares.Plataformas;
using DomainLayer.Softwares.SistemasOperacionais;

using InfraStructure;
using InfraStructure.Repository.Plataformas;
using InfraStructure.Repository.SistemasOperacionais;
using InfraStructure.Repository.Softwares;

using ServiceLayer.CommonServices;

using ServicesLayer.Plataformas;
using ServicesLayer.SistemasOperacionais;
using ServicesLayer.Softwares;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MLicencas.FormViews.Softwares
{
    public partial class SoftwareAddform : Form
    {
        private int softwareId;

        //SERVICES
        private QueryStringServices _queryString;
        private SoftwaresServices _softwaresServices;
        private PlataformasServices _plataformasServices;
        private SistemasOperacionaisServices _osServices;

        //MODELS LISTMODELS
        private DataAccessStatus dataAccessStatus = new DataAccessStatus();
        private IEnumerable<IPlataformaModel> plataformaListModel = new List<IPlataformaModel>();
        private IEnumerable<ISistemaOperacionalModel> osListModel = new List<ISistemaOperacionalModel>();
        private ISoftwareModel softwareModel;

        public SoftwareAddform(int softwareId)
        {
            LoadServices();
            InitializeComponent();
            this.softwareId = softwareId;
            LoadModels();
        }

        private void LoadModels()
        {
            osListModel = _osServices.GetAll();
            plataformaListModel = _plataformasServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _softwaresServices = new SoftwaresServices(new SoftwareRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _plataformasServices = new PlataformasServices(new PlataformaRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _osServices = new SistemasOperacionaisServices(new SistemaOperacionalRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void SoftwareAddform_Load(object sender, EventArgs e)
        {
            LoadCBPlataformas();
            LoadCBOs();
            LoadFormFields();
        }

        private void LoadFormFields()
        {
            if (softwareId != 0)
            {
                softwareModel = _softwaresServices.GetById(softwareId);

                txbId.Text = softwareModel.Id.ToString();
                txbNome.Text = softwareModel.Nome;
                txbDescricao.Text = softwareModel.Descricao;
                txbPublicoAlvo.Text = softwareModel.PublicoAlvo;
                txbVersao.Text = softwareModel.Versao;
                cbPlataforma.Text = plataformaListModel.Where(id => id.Id == softwareModel.PlataformaId).FirstOrDefault().Nome;
                cbOs.Text = osListModel.Where(id => id.Id == softwareModel.OsId).FirstOrDefault().Nome;
                chbCliServ.Checked = softwareModel.ClienteServidor;
            }
        }

        private void LoadCBOs()
        {
            cbOs.DisplayMember = "Nome";
            cbOs.DataSource = osListModel;
            cbOs.SelectedIndex = -1;
        }

        private void LoadCBPlataformas()
        {
            cbPlataforma.DisplayMember = "Nome";
            cbPlataforma.DataSource = plataformaListModel;
            cbPlataforma.SelectedIndex = -1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            softwareModel = new SoftwareModel();

            softwareModel.Id = softwareId;
            softwareModel.Nome = txbNome.Text;
            softwareModel.Descricao = txbDescricao.Text;
            softwareModel.PublicoAlvo = txbPublicoAlvo.Text;
            softwareModel.Versao = txbVersao.Text;
            softwareModel.ClienteServidor = chbCliServ.Checked;
            softwareModel.OsId = (cbOs.SelectedItem as ISistemaOperacionalModel).Id;
            softwareModel.PlataformaId = (cbPlataforma.SelectedItem as IPlataformaModel).Id;



            if (softwareId != 0)
            {
                UpdateSoftware();
            }
            else
            {
                AddSoftware();
            }
        }

        private void AddSoftware()
        {
            try
            {
                softwareModel = _softwaresServices.Add(softwareModel);
                MessageBox.Show("Software Cadastrado com Sucesso.", this.Text);
                softwareId = softwareModel.Id;
                LoadFormFields();
            }
            catch (Exception e)
            {
                this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Adicionar o Software", e.HelpLink, 0, e.StackTrace);
                MessageBox.Show(this.dataAccessStatus.CustomMessage + "\n\nMessageError: "+ dataAccessStatus.ExceptionMessage 
                    + "\n\nStackTrace: "+ dataAccessStatus.StackTrace + "\n\nInnerException: " +e.InnerException, this.Text);
            }
        }

        private void UpdateSoftware()
        {
            try
            {
                _softwaresServices.Edit(softwareModel);
                MessageBox.Show("Software Editado com Sucesso.", this.Text);
            }
            catch (Exception e)
            {
                this.dataAccessStatus.setValues("Error", false, e.Message, "Não foi possível Atualizar os dados do Software", e.HelpLink, 0, e.StackTrace);
                MessageBox.Show(this.dataAccessStatus.CustomMessage + "\n\nMessageError: " + dataAccessStatus.ExceptionMessage
                    + "\n\nStackTrace: " + dataAccessStatus.StackTrace + "\n\nInnerException: " + e.InnerException, this.Text);
            }
        }
    }
}
