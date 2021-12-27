
namespace MLicencas.FormViews.Fabrica.Endereco
{
    partial class EndFabAddForm
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
            this.lblAddBairro = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbBairro = new System.Windows.Forms.ComboBox();
            this.cbCidade = new System.Windows.Forms.ComboBox();
            this.cbUf = new System.Windows.Forms.ComboBox();
            this.cbTipoEndereco = new System.Windows.Forms.ComboBox();
            this.mtxbCep = new System.Windows.Forms.MaskedTextBox();
            this.txbNumero = new System.Windows.Forms.TextBox();
            this.txbComplemento = new System.Windows.Forms.TextBox();
            this.txbLogradouro = new System.Windows.Forms.TextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddBairro
            // 
            this.lblAddBairro.AutoSize = true;
            this.lblAddBairro.BackColor = System.Drawing.Color.PaleGreen;
            this.lblAddBairro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAddBairro.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddBairro.Location = new System.Drawing.Point(252, 203);
            this.lblAddBairro.Name = "lblAddBairro";
            this.lblAddBairro.Size = new System.Drawing.Size(13, 15);
            this.lblAddBairro.TabIndex = 38;
            this.lblAddBairro.Tag = "5.4.2";
            this.lblAddBairro.Text = "+";
            this.lblAddBairro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAddBairro.Click += new System.EventHandler(this.lblAddBairro_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(13, 252);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(218, 252);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 36;
            this.btnSave.Tag = "5.4.2";
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Tipo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "CEP:";
            // 
            // cbBairro
            // 
            this.cbBairro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbBairro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbBairro.FormattingEnabled = true;
            this.cbBairro.Location = new System.Drawing.Point(84, 199);
            this.cbBairro.Name = "cbBairro";
            this.cbBairro.Size = new System.Drawing.Size(163, 21);
            this.cbBairro.TabIndex = 35;
            // 
            // cbCidade
            // 
            this.cbCidade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCidade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCidade.FormattingEnabled = true;
            this.cbCidade.Location = new System.Drawing.Point(84, 172);
            this.cbCidade.Name = "cbCidade";
            this.cbCidade.Size = new System.Drawing.Size(163, 21);
            this.cbCidade.TabIndex = 34;
            this.cbCidade.SelectedIndexChanged += new System.EventHandler(this.cbCidade_SelectedIndexChanged);
            // 
            // cbUf
            // 
            this.cbUf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbUf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbUf.FormattingEnabled = true;
            this.cbUf.Location = new System.Drawing.Point(84, 145);
            this.cbUf.Name = "cbUf";
            this.cbUf.Size = new System.Drawing.Size(40, 21);
            this.cbUf.TabIndex = 33;
            this.cbUf.SelectedIndexChanged += new System.EventHandler(this.cbUf_SelectedIndexChanged);
            // 
            // cbTipoEndereco
            // 
            this.cbTipoEndereco.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTipoEndereco.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTipoEndereco.FormattingEnabled = true;
            this.cbTipoEndereco.Location = new System.Drawing.Point(200, 11);
            this.cbTipoEndereco.Name = "cbTipoEndereco";
            this.cbTipoEndereco.Size = new System.Drawing.Size(121, 21);
            this.cbTipoEndereco.TabIndex = 19;
            // 
            // mtxbCep
            // 
            this.mtxbCep.Location = new System.Drawing.Point(255, 119);
            this.mtxbCep.Mask = "00,000-000";
            this.mtxbCep.Name = "mtxbCep";
            this.mtxbCep.Size = new System.Drawing.Size(66, 20);
            this.mtxbCep.TabIndex = 32;
            this.mtxbCep.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // txbNumero
            // 
            this.txbNumero.Location = new System.Drawing.Point(84, 119);
            this.txbNumero.Name = "txbNumero";
            this.txbNumero.Size = new System.Drawing.Size(40, 20);
            this.txbNumero.TabIndex = 22;
            // 
            // txbComplemento
            // 
            this.txbComplemento.Location = new System.Drawing.Point(84, 64);
            this.txbComplemento.Multiline = true;
            this.txbComplemento.Name = "txbComplemento";
            this.txbComplemento.Size = new System.Drawing.Size(237, 49);
            this.txbComplemento.TabIndex = 21;
            // 
            // txbLogradouro
            // 
            this.txbLogradouro.Location = new System.Drawing.Point(84, 38);
            this.txbLogradouro.Name = "txbLogradouro";
            this.txbLogradouro.Size = new System.Drawing.Size(237, 20);
            this.txbLogradouro.TabIndex = 20;
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(84, 12);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(40, 20);
            this.txbId.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Bairro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Cidade:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "UF:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Complemento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Nº";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Logradouro:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Código:";
            // 
            // EndFabAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 294);
            this.Controls.Add(this.lblAddBairro);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbBairro);
            this.Controls.Add(this.cbCidade);
            this.Controls.Add(this.cbUf);
            this.Controls.Add(this.cbTipoEndereco);
            this.Controls.Add(this.mtxbCep);
            this.Controls.Add(this.txbNumero);
            this.Controls.Add(this.txbComplemento);
            this.Controls.Add(this.txbLogradouro);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EndFabAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fábrica - Editar Endereço";
            this.Load += new System.EventHandler(this.EndFabAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddBairro;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbBairro;
        private System.Windows.Forms.ComboBox cbCidade;
        private System.Windows.Forms.ComboBox cbUf;
        private System.Windows.Forms.ComboBox cbTipoEndereco;
        private System.Windows.Forms.MaskedTextBox mtxbCep;
        private System.Windows.Forms.TextBox txbNumero;
        private System.Windows.Forms.TextBox txbComplemento;
        private System.Windows.Forms.TextBox txbLogradouro;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}