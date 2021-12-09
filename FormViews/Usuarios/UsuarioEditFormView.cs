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
        private IEnumerable<IGrupoModel> grupoListModel = new List<IGrupoModel>();
        private RequestType.Type requestType;

        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;
        private GruposServices _gruposServices;

        public UsuarioEditFormView(IUsuarioModel usuario, RequestType.Type requestType)
        {
            LoadServices();
            InitializeComponent();
            this.usuario = usuario;
            this.requestType = requestType;
            LoadModels();
        }

        private void LoadModels()
        {
            grupoListModel = _gruposServices.GetAll();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
            _gruposServices = new GruposServices(new GrupoRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void UsuarioEditFormView_Load(object sender, EventArgs e)
        {
            LoadComboBoxGrupo();
            LoadFields(this.requestType);
        }

        private void LoadFields(RequestType.Type requestType)
        {

            if (requestType.Equals(RequestType.Type.Edit))
            {
                MessageBox.Show("ATENÇÃO\nLogin e CPF de usuário não podem ser alterados.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //EDITANDO USUÁRIO
                txbId.Text = usuario.Id.ToString();
                txbLogin.Text = usuario.Login;
                txbLogin.Enabled = false;
                txbNome.Text = usuario.Nome;
                mTxbCpf.Text = usuario.Cpf;
                mTxbCpf.Enabled = false;
                txbCargo.Text = usuario.Cargo;
                cbGrupo.SelectedValue = grupoListModel.Where(gId => gId.Id == usuario.GrupoId).Select(nom => nom.Nome).FirstOrDefault();
            }
        }

        private void LoadComboBoxGrupo()
        {
            cbGrupo.DataSource = grupoListModel;
            cbGrupo.ValueMember = "Nome";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (requestType.Equals(RequestType.Type.Edit))
            {
                usuario.Nome = txbNome.Text;
                usuario.Cargo = txbCargo.Text;
                usuario.GrupoId = (cbGrupo.SelectedItem as GrupoModel).Id;
                try
                {
                    _usuariosServices.Edit(usuario);
                    MessageBox.Show("Dados alterados com sucesso.", this.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }
            else
            {
                usuario.Login = txbLogin.Text;
                usuario.Nome = txbNome.Text;
                usuario.Cpf = mTxbCpf.Text;
                usuario.Cargo = txbCargo.Text;
                usuario.Senha = GetHashSenha.GetSenha("ML1234");
                usuario.GrupoId = (cbGrupo.SelectedItem as GrupoModel).Id;
                usuario.Ativo = true;
                usuario.AlteraSenha = true;

                if (_usuariosServices.GetByLogin(usuario.Login).Id != 0)
                {
                    MessageBox.Show($"Login: \"{usuario.Login}\"\nJá está em uso.\nTente outro", this.Text);
                    txbLogin.Focus();
                }
                else
                {
                    try
                    {
                        IUsuarioModel usuarioRecebido = new UsuarioModel();
                        usuarioRecebido = _usuariosServices.Add(usuario);
                        if (usuarioRecebido.Id != 0)
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso.\nO Usuário deve alterar a senha no próximo login\nSENHA:\"ML1234\"", this.Text);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw new Exception(ex.Message, ex.InnerException);
                    }
                }
            }
        }
    }
}
