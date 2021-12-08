
namespace MLicencas.FormViews.Usuarios
{
    partial class UsuarioEditFormView
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
            this.lblId = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblGrupo = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txbLogin = new System.Windows.Forms.TextBox();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.mTxbCpf = new System.Windows.Forms.MaskedTextBox();
            this.txbCargo = new System.Windows.Forms.TextBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(37, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(19, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Id:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(20, 37);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(18, 65);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(26, 93);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 3;
            this.lblCPF.Text = "CPF:";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(18, 121);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(38, 13);
            this.lblCargo.TabIndex = 4;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblGrupo
            // 
            this.lblGrupo.AutoSize = true;
            this.lblGrupo.Location = new System.Drawing.Point(17, 149);
            this.lblGrupo.Name = "lblGrupo";
            this.lblGrupo.Size = new System.Drawing.Size(39, 13);
            this.lblGrupo.TabIndex = 5;
            this.lblGrupo.Text = "Grupo:";
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(62, 6);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(37, 20);
            this.txbId.TabIndex = 7;
            // 
            // txbLogin
            // 
            this.txbLogin.Location = new System.Drawing.Point(62, 34);
            this.txbLogin.Name = "txbLogin";
            this.txbLogin.Size = new System.Drawing.Size(100, 20);
            this.txbLogin.TabIndex = 8;
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(62, 62);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(187, 20);
            this.txbNome.TabIndex = 9;
            // 
            // mTxbCpf
            // 
            this.mTxbCpf.Location = new System.Drawing.Point(62, 90);
            this.mTxbCpf.Name = "mTxbCpf";
            this.mTxbCpf.Size = new System.Drawing.Size(100, 20);
            this.mTxbCpf.TabIndex = 10;
            // 
            // txbCargo
            // 
            this.txbCargo.Location = new System.Drawing.Point(62, 118);
            this.txbCargo.Name = "txbCargo";
            this.txbCargo.Size = new System.Drawing.Size(187, 20);
            this.txbCargo.TabIndex = 11;
            // 
            // cbGrupo
            // 
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(62, 146);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(187, 21);
            this.cbGrupo.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(174, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(11, 186);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // UsuarioEditFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 240);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbGrupo);
            this.Controls.Add(this.txbCargo);
            this.Controls.Add(this.mTxbCpf);
            this.Controls.Add(this.txbNome);
            this.Controls.Add(this.txbLogin);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.lblGrupo);
            this.Controls.Add(this.lblCargo);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UsuarioEditFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UsuarioEditFormView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblGrupo;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txbLogin;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.MaskedTextBox mTxbCpf;
        private System.Windows.Forms.TextBox txbCargo;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}