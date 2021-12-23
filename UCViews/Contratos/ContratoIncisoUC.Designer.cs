
namespace MLicencas.UCViews.Contratos
{
    partial class ContratoIncisoUC

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
            this.txbTermo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picbSave = new System.Windows.Forms.PictureBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbSave)).BeginInit();
            this.SuspendLayout();
            // 
            // txbTermo
            // 
            this.txbTermo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txbTermo.Location = new System.Drawing.Point(14, 60);
            this.txbTermo.Multiline = true;
            this.txbTermo.Name = "txbTermo";
            this.txbTermo.Size = new System.Drawing.Size(437, 127);
            this.txbTermo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Termo:";
            // 
            // picbSave
            // 
            this.picbSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbSave.Image = global::MLicencas.Properties.Resources.iconSave20x20;
            this.picbSave.Location = new System.Drawing.Point(457, 165);
            this.picbSave.Name = "picbSave";
            this.picbSave.Size = new System.Drawing.Size(22, 22);
            this.picbSave.TabIndex = 2;
            this.picbSave.TabStop = false;
            this.picbSave.Click += new System.EventHandler(this.picbSave_Click);
            // 
            // txbNumero
            // 
            this.txbNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txbNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNumero.Location = new System.Drawing.Point(14, 20);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(47, 20);
            this.txbNumero.TabIndex = 0;
            this.txbNumero.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número:";
            // 
            // ContratoIncisoUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picbSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbNumero);
            this.Controls.Add(this.txbTermo);
            this.Name = "ContratoIncisoUC";
            this.Size = new System.Drawing.Size(490, 200);
            this.Load += new System.EventHandler(this.ContratoClausulaUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbTermo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picbSave;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.Label label2;
    }
}
