
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
            this.SuspendLayout();
            // 
            // panelAccessList
            // 
            this.panelAccessList.Location = new System.Drawing.Point(525, 12);
            this.panelAccessList.Name = "panelAccessList";
            this.panelAccessList.Size = new System.Drawing.Size(263, 426);
            this.panelAccessList.TabIndex = 1;
            // 
            // panelUsuariosList
            // 
            this.panelUsuariosList.Location = new System.Drawing.Point(12, 12);
            this.panelUsuariosList.Name = "panelUsuariosList";
            this.panelUsuariosList.Size = new System.Drawing.Size(507, 426);
            this.panelUsuariosList.TabIndex = 1;
            // 
            // UsuariosFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelUsuariosList);
            this.Controls.Add(this.panelAccessList);
            this.Name = "UsuariosFormView";
            this.Text = "Gestão de Usuários";
            this.Load += new System.EventHandler(this.UsuariosFormView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelAccessList;
        private UCViews.Usuarios.UsuariosListUC usuariosListUC;
        private System.Windows.Forms.Panel panelUsuariosList;
    }
}