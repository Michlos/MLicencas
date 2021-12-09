
namespace MLicencas.FormViews.Usuarios
{
    partial class UsuariosFormView
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
            this.panelAccessList = new System.Windows.Forms.Panel();
            this.panelUsuariosList = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEditUsario = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelAccessList
            // 
            this.panelAccessList.Location = new System.Drawing.Point(525, 12);
            this.panelAccessList.Name = "panelAccessList";
            this.panelAccessList.Size = new System.Drawing.Size(263, 399);
            this.panelAccessList.TabIndex = 1;
            // 
            // panelUsuariosList
            // 
            this.panelUsuariosList.Location = new System.Drawing.Point(12, 12);
            this.panelUsuariosList.Name = "panelUsuariosList";
            this.panelUsuariosList.Size = new System.Drawing.Size(507, 399);
            this.panelUsuariosList.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.PaleGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(714, 417);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 27);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "Pedidos";
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(525, 417);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 27);
            this.btnSave.TabIndex = 3;
            this.btnSave.TabStop = false;
            this.btnSave.Tag = "6.3";
            this.btnSave.Text = "Salvar Permissões";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEditUsario
            // 
            this.btnEditUsario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditUsario.BackColor = System.Drawing.Color.PaleGreen;
            this.btnEditUsario.FlatAppearance.BorderSize = 0;
            this.btnEditUsario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUsario.ForeColor = System.Drawing.Color.Black;
            this.btnEditUsario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditUsario.Location = new System.Drawing.Point(132, 417);
            this.btnEditUsario.Name = "btnEditUsario";
            this.btnEditUsario.Size = new System.Drawing.Size(114, 27);
            this.btnEditUsario.TabIndex = 3;
            this.btnEditUsario.TabStop = false;
            this.btnEditUsario.Tag = "6.2";
            this.btnEditUsario.Text = "Editar Usuário";
            this.btnEditUsario.UseVisualStyleBackColor = false;
            this.btnEditUsario.Click += new System.EventHandler(this.btnEditUsario_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.ForeColor = System.Drawing.Color.Black;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(12, 417);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(114, 27);
            this.btnNovo.TabIndex = 3;
            this.btnNovo.TabStop = false;
            this.btnNovo.Tag = "6.1";
            this.btnNovo.Text = "Novo Usuário";
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // UsuariosFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnEditUsario);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panelUsuariosList);
            this.Controls.Add(this.panelAccessList);
            this.MaximizeBox = false;
            this.Name = "UsuariosFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Usuários";
            this.Load += new System.EventHandler(this.UsuariosFormView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelAccessList;
        private System.Windows.Forms.Panel panelUsuariosList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEditUsario;
        private System.Windows.Forms.Button btnNovo;
    }
}