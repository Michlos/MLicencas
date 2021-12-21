
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
            this.contratosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novoContratoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestaoDeContratosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestaoDeUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastroDaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.statusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.contratosToolStripMenuItem,
            this.menuGestaoDeUsuarios,
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
            this.gestaoDeClientesToolStripMenuItem});
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
            // contratosToolStripMenuItem
            // 
            this.contratosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoContratoToolStripMenuItem,
            this.gestaoDeContratosToolStripMenuItem});
            this.contratosToolStripMenuItem.Name = "contratosToolStripMenuItem";
            this.contratosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.contratosToolStripMenuItem.Text = "C&ontratos";
            // 
            // novoContratoToolStripMenuItem
            // 
            this.novoContratoToolStripMenuItem.Name = "novoContratoToolStripMenuItem";
            this.novoContratoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.novoContratoToolStripMenuItem.Tag = "2.1";
            this.novoContratoToolStripMenuItem.Text = "&Novo";
            this.novoContratoToolStripMenuItem.Click += new System.EventHandler(this.novoContratoToolStripMenuItem_Click);
            // 
            // gestaoDeContratosToolStripMenuItem
            // 
            this.gestaoDeContratosToolStripMenuItem.Name = "gestaoDeContratosToolStripMenuItem";
            this.gestaoDeContratosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.gestaoDeContratosToolStripMenuItem.Tag = "2";
            this.gestaoDeContratosToolStripMenuItem.Text = "&Gestão de Contratos";
            this.gestaoDeContratosToolStripMenuItem.Click += new System.EventHandler(this.gestaoDeContratosToolStripMenuItem_Click);
            // 
            // menuGestaoDeUsuarios
            // 
            this.menuGestaoDeUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.gruposToolStripMenuItem});
            this.menuGestaoDeUsuarios.Name = "menuGestaoDeUsuarios";
            this.menuGestaoDeUsuarios.Size = new System.Drawing.Size(119, 20);
            this.menuGestaoDeUsuarios.Tag = "6";
            this.menuGestaoDeUsuarios.Text = "&Gestão de Usuários";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.usuariosToolStripMenuItem.Text = "&Usuários";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // gruposToolStripMenuItem
            // 
            this.gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            this.gruposToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.gruposToolStripMenuItem.Text = "&Grupos";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroDaEmpresaToolStripMenuItem});
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.sobreToolStripMenuItem.Text = "Sobr&e";
            // 
            // cadastroDaEmpresaToolStripMenuItem
            // 
            this.cadastroDaEmpresaToolStripMenuItem.Name = "cadastroDaEmpresaToolStripMenuItem";
            this.cadastroDaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cadastroDaEmpresaToolStripMenuItem.Tag = "5";
            this.cadastroDaEmpresaToolStripMenuItem.Text = "Cadastro da &Empresa";
            this.cadastroDaEmpresaToolStripMenuItem.Click += new System.EventHandler(this.cadastroDaEmpresaToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem menuGestaoDeUsuarios;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel statusUsuario;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastroDaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoSoftwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contratosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novoContratoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestaoDeContratosToolStripMenuItem;
    }
}

