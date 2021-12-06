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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLicencas.FormViews.Login
{
    public partial class AlteraSenhaForm : Form
    {
        //SERVICES
        private QueryStringServices _queryString;
        private UsuariosServices _usuariosServices;

        private IUsuarioModel usuario;
        public AlteraSenhaForm()
        {
            
            LoadServices();
            InitializeComponent();
        }

        private void LoadServices()
        {
            _queryString = new QueryStringServices(new QueryString());
            _usuariosServices = new UsuariosServices(new UsuarioRepository(_queryString.GetQueryApp()), new ModelDataAnnotationCheck());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAltera_Click(object sender, EventArgs e)
        {
            
            if (!txbSenha.Text.Equals(""))
            {
                if (txbSenha.Text.Equals(txbConfirmaSenha.Text))
                {
                    usuario = MainView._UsuarioModel;

                    usuario.Senha = GetHashSenha.GetSenha(txbSenha.Text);
                    usuario.AlteraSenha = false;
                    try
                    {
                        _usuariosServices.Edit(usuario);
                        MessageBox.Show("Senha alterada com sucesso");
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error", "Não foi possível alterar a senha do usuário.");
                        throw new Exception(ex.Message, ex.InnerException);
                    }
                }
            }
        }
    }
}
