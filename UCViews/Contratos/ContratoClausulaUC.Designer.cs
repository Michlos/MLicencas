
namespace MLicencas.UCViews.Contratos
{
    partial class ContratoClausulaUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbTitulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picbSave = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // txbTitulo
            // 
            this.txbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbTitulo.Location = new System.Drawing.Point(3, 18);
            this.txbTitulo.Name = "txbTitulo";
            this.txbTitulo.Size = new System.Drawing.Size(437, 20);
            this.txbTitulo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Título";
            // 
            // picbSave
            // 
            this.picbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbSave.Image = global::MLicencas.Properties.Resources.iconSave20x20;
            this.picbSave.Location = new System.Drawing.Point(446, 16);
            this.picbSave.Name = "picbSave";
            this.picbSave.Size = new System.Drawing.Size(22, 22);
            this.picbSave.TabIndex = 2;
            this.picbSave.TabStop = false;
            this.picbSave.Click += new System.EventHandler(this.picbSave_Click);
            // 
            // ContratoClausulaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picbSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbTitulo);
            this.Name = "ContratoClausulaUC";
            this.Size = new System.Drawing.Size(482, 48);
            this.Load += new System.EventHandler(this.ContratoClausulaUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picbSave;
    }
}
