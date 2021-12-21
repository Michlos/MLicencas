
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
            this.txbOrdem = new System.Windows.Forms.TextBox();
            this.picbSave = new System.Windows.Forms.PictureBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // txbTitulo
            // 
            this.txbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTitulo.Location = new System.Drawing.Point(73, 16);
            this.txbTitulo.Name = "txbTitulo";
            this.txbTitulo.Size = new System.Drawing.Size(297, 20);
            this.txbTitulo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Título";
            // 
            // txbOrdem
            // 
            this.txbOrdem.Location = new System.Drawing.Point(376, 16);
            this.txbOrdem.Name = "txbOrdem";
            this.txbOrdem.Size = new System.Drawing.Size(64, 20);
            this.txbOrdem.TabIndex = 3;
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
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(3, 16);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(64, 20);
            this.txbId.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Ordem";
            // 
            // ContratoClausulaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.txbOrdem);
            this.Controls.Add(this.picbSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
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
        private System.Windows.Forms.TextBox txbOrdem;
        private System.Windows.Forms.PictureBox picbSave;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
