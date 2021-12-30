
namespace MLicencas
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.softwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contratosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.novoContratoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoDeContratosClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licencasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarLicencaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoDeLicencasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financeiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoBancáriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeBancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeBoletosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosDaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestãoDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.gestãoDeContasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.licencasToolStripMenuItem,
            this.financeiroToolStripMenuItem,
            this.configuracaoToolStripMenuItem,
            this.sobreToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(784, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // softwareToolStripMenuItem
            // 
            this.softwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoSoftwareToolStripMenuItem,
            this.gestaoSoftwareToolStripMenuItem});
            this.softwareToolStripMenuItem.Name = "softwareToolStripMenuItem";
            this.softwareToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.softwareToolStripMenuItem.Text = "&Software";
            // 
            // novoSoftwareToolStripMenuItem
            // 
            this.novoSoftwareToolStripMenuItem.Name = "novoSoftwareToolStripMenuItem";
            this.novoSoftwareToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.novoSoftwareToolStripMenuItem.Tag = "3.1";
            this.novoSoftwareToolStripMenuItem.Text = "&Novo";
            this.novoSoftwareToolStripMenuItem.Click += new System.EventHandler(this.novoSoftwareToolStripMenuItem_Click);
            // 
            // gestaoSoftwareToolStripMenuItem
            // 
            this.gestaoSoftwareToolStripMenuItem.Name = "gestaoSoftwareToolStripMenuItem";
            this.gestaoSoftwareToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestaoSoftwareToolStripMenuItem.Tag = "3";
            this.gestaoSoftwareToolStripMenuItem.Text = "&Gestão de Software";
            this.gestaoSoftwareToolStripMenuItem.Click += new System.EventHandler(this.gestaoSoftwareToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoClienteToolStripMenuItem,
            this.gestaoDeClientesToolStripMenuItem,
            this.contratosToolStripMenuItem1});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Text = "&Clientes";
            // 
            // novoClienteToolStripMenuItem
            // 
            this.novoClienteToolStripMenuItem.Name = "novoClienteToolStripMenuItem";
            this.novoClienteToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.novoClienteToolStripMenuItem.Tag = "1.1";
            this.novoClienteToolStripMenuItem.Text = "&Novo";
            this.novoClienteToolStripMenuItem.Click += new System.EventHandler(this.novoClienteToolStripMenuItem_Click);
            // 
            // gestaoDeClientesToolStripMenuItem
            // 
            this.gestaoDeClientesToolStripMenuItem.Name = "gestaoDeClientesToolStripMenuItem";
            this.gestaoDeClientesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.gestaoDeClientesToolStripMenuItem.Tag = "1";
            this.gestaoDeClientesToolStripMenuItem.Text = "&Gestão de Clientes";
            this.gestaoDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gestaoDeClientesToolStripMenuItem_Click);
            // 
            // contratosToolStripMenuItem1
            // 
            this.contratosToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoContratoToolStripMenuItem1,
            this.gestaoDeContratosClientesToolStripMenuItem});
            this.contratosToolStripMenuItem1.Name = "contratosToolStripMenuItem1";
            this.contratosToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.contratosToolStripMenuItem1.Text = "Contratos";
            // 
            // novoContratoToolStripMenuItem1
            // 
            this.novoContratoToolStripMenuItem1.Name = "novoContratoToolStripMenuItem1";
            this.novoContratoToolStripMenuItem1.Size = new System.Drawing.Size(181, 22);
            this.novoContratoToolStripMenuItem1.Text = "Novo Contrato";
            this.novoContratoToolStripMenuItem1.Click += new System.EventHandler(this.novoContratoToolStripMenuItem_Click);
            // 
            // gestaoDeContratosClientesToolStripMenuItem
            // 
            this.gestaoDeContratosClientesToolStripMenuItem.Name = "gestaoDeContratosClientesToolStripMenuItem";
            this.gestaoDeContratosClientesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.gestaoDeContratosClientesToolStripMenuItem.Text = "Gestão de Contratos";
            this.gestaoDeContratosClientesToolStripMenuItem.Click += new System.EventHandler(this.gestaoDeContratosToolStripMenuItem_Click);
            // 
            // licencasToolStripMenuItem
            // 
            this.licencasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarLicencaToolStripMenuItem,
            this.gestaoDeLicencasToolStripMenuItem});
            this.licencasToolStripMenuItem.Name = "licencasToolStripMenuItem";
            this.licencasToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.licencasToolStripMenuItem.Text = "&Licenças";
            // 
            // gerarLicencaToolStripMenuItem
            // 
            this.gerarLicencaToolStripMenuItem.Name = "gerarLicencaToolStripMenuItem";
            this.gerarLicencaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gerarLicencaToolStripMenuItem.Text = "Gerar &Licença";
            // 
            // gestaoDeLicencasToolStripMenuItem
            // 
            this.gestaoDeLicencasToolStripMenuItem.Name = "gestaoDeLicencasToolStripMenuItem";
            this.gestaoDeLicencasToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gestaoDeLicencasToolStripMenuItem.Text = "&Gestão de Licenças";
            this.gestaoDeLicencasToolStripMenuItem.Click += new System.EventHandler(this.gestaoDeLicencasToolStripMenuItem_Click);
            // 
            // financeiroToolStripMenuItem
            // 
            this.financeiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestãoBancáriaToolStripMenuItem,
            this.gestãoDeBoletosToolStripMenuItem});
            this.financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            this.financeiroToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.financeiroToolStripMenuItem.Text = "Financeiro";
            // 
            // gestãoBancáriaToolStripMenuItem
            // 
            this.gestãoBancáriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaDeBancosToolStripMenuItem,
            this.gestãoDeContasToolStripMenuItem});
            this.gestãoBancáriaToolStripMenuItem.Name = "gestãoBancáriaToolStripMenuItem";
            this.gestãoBancáriaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestãoBancáriaToolStripMenuItem.Text = "Gestão Bancária";
            // 
            // listaDeBancosToolStripMenuItem
            // 
            this.listaDeBancosToolStripMenuItem.Name = "listaDeBancosToolStripMenuItem";
            this.listaDeBancosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listaDeBancosToolStripMenuItem.Text = "Gestão de Bancos";
            this.listaDeBancosToolStripMenuItem.Click += new System.EventHandler(this.gestaoDeBancosToolStripMenuItem_Click);
            // 
            // gestãoDeBoletosToolStripMenuItem
            // 
            this.gestãoDeBoletosToolStripMenuItem.Name = "gestãoDeBoletosToolStripMenuItem";
            this.gestãoDeBoletosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestãoDeBoletosToolStripMenuItem.Text = "Gestão de Boletos";
            // 
            // configuracaoToolStripMenuItem
            // 
            this.configuracaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dadosDaEmpresaToolStripMenuItem,
            this.gestãoDeUsuariosToolStripMenuItem});
            this.configuracaoToolStripMenuItem.Name = "configuracaoToolStripMenuItem";
            this.configuracaoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.configuracaoToolStripMenuItem.Text = "Configuração";
            // 
            // dadosDaEmpresaToolStripMenuItem
            // 
            this.dadosDaEmpresaToolStripMenuItem.Name = "dadosDaEmpresaToolStripMenuItem";
            this.dadosDaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.dadosDaEmpresaToolStripMenuItem.Text = "Dados da Empresa";
            this.dadosDaEmpresaToolStripMenuItem.Click += new System.EventHandler(this.cadastroDaEmpresaToolStripMenuItem_Click);
            // 
            // gestãoDeUsuariosToolStripMenuItem
            // 
            this.gestãoDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoUsuarioToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.gruposToolStripMenuItem1});
            this.gestãoDeUsuariosToolStripMenuItem.Name = "gestãoDeUsuariosToolStripMenuItem";
            this.gestãoDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.gestãoDeUsuariosToolStripMenuItem.Text = "Gestão de Usuários";
            // 
            // novoUsuarioToolStripMenuItem
            // 
            this.novoUsuarioToolStripMenuItem.Name = "novoUsuarioToolStripMenuItem";
            this.novoUsuarioToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.novoUsuarioToolStripMenuItem.Text = "Novo Usuário";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.usuariosToolStripMenuItem.Text = "Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem1
            // 
            this.gruposToolStripMenuItem1.Name = "gruposToolStripMenuItem1";
            this.gruposToolStripMenuItem1.Size = new System.Drawing.Size(146, 22);
            this.gruposToolStripMenuItem1.Text = "Grupos";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem1});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobr&e";
            // 
            // sobreToolStripMenuItem1
            // 
            this.sobreToolStripMenuItem1.Name = "sobreToolStripMenuItem1";
            this.sobreToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem1.Text = "Sobre";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusUsuario});
            this.statusStripMain.Location = new System.Drawing.Point(0, 539);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(784, 22);
            this.statusStripMain.TabIndex = 2;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // statusUsuario
            // 
            this.statusUsuario.Name = "statusUsuario";
            this.statusUsuario.Size = new System.Drawing.Size(99, 17);
            this.statusUsuario.Text = "NomeUsuarioTXT";
            // 
            // gestãoDeContasToolStripMenuItem
            // 
            this.gestãoDeContasToolStripMenuItem.Name = "gestãoDeContasToolStripMenuItem";
            this.gestãoDeContasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestãoDeContasToolStripMenuItem.Text = "Gestão de Contas";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MLicenças - Sistema de Gerenciamento de Licenças de Software";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainView_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusUsuario;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licencasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarLicencaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoDeLicencasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem configuracaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dadosDaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem contratosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem novoContratoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gestaoDeContratosClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financeiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoBancáriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeBancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeBoletosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestãoDeContasToolStripMenuItem;
    }
}

