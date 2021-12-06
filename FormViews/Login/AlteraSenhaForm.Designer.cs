
namespace MLicencas.FormViews.Login
{
    partial class AlteraSenhaForm
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
            this.lblInformeSenha = new System.Windows.Forms.Label();
            this.lblRepitaSenha = new System.Windows.Forms.Label();
            this.txbSenha = new System.Windows.Forms.TextBox();
            this.txbConfirmaSenha = new System.Windows.Forms.TextBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAltera = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInformeSenha
            // 
            this.lblInformeSenha.AutoSize = true;
            this.lblInformeSenha.Location = new System.Drawing.Point(29, 56);
            this.lblInformeSenha.Name = "lblInformeSenha";
            this.lblInformeSenha.Size = new System.Drawing.Size(94, 13);
            this.lblInformeSenha.TabIndex = 0;
            this.lblInformeSenha.Text = "Informe um senha:";
            // 
            // lblRepitaSenha
            // 
            this.lblRepitaSenha.AutoSize = true;
            this.lblRepitaSenha.Location = new System.Drawing.Point(39, 93);
            this.lblRepitaSenha.Name = "lblRepitaSenha";
            this.lblRepitaSenha.Size = new System.Drawing.Size(84, 13);
            this.lblRepitaSenha.TabIndex = 1;
            this.lblRepitaSenha.Text = "Repíta a senha:";
            // 
            // txbSenha
            // 
            this.txbSenha.Location = new System.Drawing.Point(122, 53);
            this.txbSenha.Name = "txbSenha";
            this.txbSenha.PasswordChar = '*';
            this.txbSenha.Size = new System.Drawing.Size(100, 20);
            this.txbSenha.TabIndex = 0;
            // 
            // txbConfirmaSenha
            // 
            this.txbConfirmaSenha.Location = new System.Drawing.Point(122, 90);
            this.txbConfirmaSenha.Name = "txbConfirmaSenha";
            this.txbConfirmaSenha.PasswordChar = '*';
            this.txbConfirmaSenha.Size = new System.Drawing.Size(100, 20);
            this.txbConfirmaSenha.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(34, 21);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(197, 16);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Alteração de Senha Obrigatória";
            // 
            // btnAltera
            // 
            this.btnAltera.Location = new System.Drawing.Point(156, 120);
            this.btnAltera.Name = "btnAltera";
            this.btnAltera.Size = new System.Drawing.Size(75, 23);
            this.btnAltera.TabIndex = 2;
            this.btnAltera.Text = "Altera";
            this.btnAltera.UseVisualStyleBackColor = true;
            this.btnAltera.Click += new System.EventHandler(this.btnAltera_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(37, 120);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Cancelar";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AlteraSenhaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(261, 173);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAltera);
            this.Controls.Add(this.txbConfirmaSenha);
            this.Controls.Add(this.txbSenha);
            this.Controls.Add(this.lblRepitaSenha);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblInformeSenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AlteraSenhaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlteraSenhaForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInformeSenha;
        private System.Windows.Forms.Label lblRepitaSenha;
        private System.Windows.Forms.TextBox txbSenha;
        private System.Windows.Forms.TextBox txbConfirmaSenha;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAltera;
        private System.Windows.Forms.Button btnClose;
    }
}