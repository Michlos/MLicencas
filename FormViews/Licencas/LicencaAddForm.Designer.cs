
namespace MLicencas.FormViews.Licencas
{
    partial class LicencaAddForm
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
            this.txbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbIdContrato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDadosContrato = new System.Windows.Forms.GroupBox();
            this.mtbDtVencContrato = new System.Windows.Forms.MaskedTextBox();
            this.mtbDtRegContrato = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbNomeSoftware = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mtxbChave = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mtxbHashCliente = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mtxbHashChave = new System.Windows.Forms.MaskedTextBox();
            this.btnGen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbDadosContrato.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(61, 6);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(66, 20);
            this.txbId.TabIndex = 0;
            this.txbId.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(61, 32);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(276, 21);
            this.cbCliente.TabIndex = 2;
            this.cbCliente.SelectedIndexChanged += new System.EventHandler(this.cbCliente_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente:";
            // 
            // txbIdContrato
            // 
            this.txbIdContrato.Location = new System.Drawing.Point(49, 29);
            this.txbIdContrato.Name = "txbIdContrato";
            this.txbIdContrato.ReadOnly = true;
            this.txbIdContrato.Size = new System.Drawing.Size(66, 20);
            this.txbIdContrato.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Id:";
            // 
            // gbDadosContrato
            // 
            this.gbDadosContrato.Controls.Add(this.mtbDtVencContrato);
            this.gbDadosContrato.Controls.Add(this.mtbDtRegContrato);
            this.gbDadosContrato.Controls.Add(this.label4);
            this.gbDadosContrato.Controls.Add(this.label6);
            this.gbDadosContrato.Controls.Add(this.txbNomeSoftware);
            this.gbDadosContrato.Controls.Add(this.txbIdContrato);
            this.gbDadosContrato.Controls.Add(this.label7);
            this.gbDadosContrato.Controls.Add(this.label5);
            this.gbDadosContrato.Controls.Add(this.label3);
            this.gbDadosContrato.Location = new System.Drawing.Point(12, 67);
            this.gbDadosContrato.Name = "gbDadosContrato";
            this.gbDadosContrato.Size = new System.Drawing.Size(486, 108);
            this.gbDadosContrato.TabIndex = 3;
            this.gbDadosContrato.TabStop = false;
            // 
            // mtbDtVencContrato
            // 
            this.mtbDtVencContrato.Location = new System.Drawing.Point(381, 29);
            this.mtbDtVencContrato.Mask = "00/00/0000";
            this.mtbDtVencContrato.Name = "mtbDtVencContrato";
            this.mtbDtVencContrato.ReadOnly = true;
            this.mtbDtVencContrato.Size = new System.Drawing.Size(76, 20);
            this.mtbDtVencContrato.TabIndex = 2;
            this.mtbDtVencContrato.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDtRegContrato
            // 
            this.mtbDtRegContrato.Location = new System.Drawing.Point(207, 29);
            this.mtbDtRegContrato.Mask = "00/00/0000";
            this.mtbDtRegContrato.Name = "mtbDtRegContrato";
            this.mtbDtRegContrato.ReadOnly = true;
            this.mtbDtRegContrato.Size = new System.Drawing.Size(76, 20);
            this.mtbDtRegContrato.TabIndex = 2;
            this.mtbDtRegContrato.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Contrato:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Vencimento:";
            // 
            // txbNomeSoftware
            // 
            this.txbNomeSoftware.Location = new System.Drawing.Point(82, 64);
            this.txbNomeSoftware.Name = "txbNomeSoftware";
            this.txbNomeSoftware.ReadOnly = true;
            this.txbNomeSoftware.Size = new System.Drawing.Size(375, 20);
            this.txbNomeSoftware.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Software:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(152, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Registro:";
            // 
            // mtxbChave
            // 
            this.mtxbChave.Location = new System.Drawing.Point(82, 19);
            this.mtxbChave.Name = "mtxbChave";
            this.mtxbChave.ReadOnly = true;
            this.mtxbChave.Size = new System.Drawing.Size(276, 20);
            this.mtxbChave.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Chave:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "HashCliente:";
            // 
            // mtxbHashCliente
            // 
            this.mtxbHashCliente.Enabled = false;
            this.mtxbHashCliente.Location = new System.Drawing.Point(82, 55);
            this.mtxbHashCliente.Name = "mtxbHashCliente";
            this.mtxbHashCliente.Size = new System.Drawing.Size(333, 20);
            this.mtxbHashCliente.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "HashChave:";
            // 
            // mtxbHashChave
            // 
            this.mtxbHashChave.Enabled = false;
            this.mtxbHashChave.Location = new System.Drawing.Point(82, 93);
            this.mtxbHashChave.Name = "mtxbHashChave";
            this.mtxbHashChave.Size = new System.Drawing.Size(333, 20);
            this.mtxbHashChave.TabIndex = 4;
            // 
            // btnGen
            // 
            this.btnGen.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGen.FlatAppearance.BorderSize = 0;
            this.btnGen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGen.Location = new System.Drawing.Point(249, 334);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(121, 27);
            this.btnGen.TabIndex = 23;
            this.btnGen.Tag = "2.1";
            this.btnGen.Text = "Gerar Chave";
            this.btnGen.UseVisualStyleBackColor = false;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(377, 334);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 27);
            this.btnSave.TabIndex = 23;
            this.btnSave.Tag = "2.1";
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.mtxbChave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.mtxbHashChave);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.mtxbHashCliente);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 124);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Licença:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 334);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 27);
            this.btnClose.TabIndex = 23;
            this.btnClose.Tag = "2.1";
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // LicencaAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.gbDadosContrato);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbId);
            this.Name = "LicencaAddForm";
            this.Text = "Gerador de Chaves de Licença";
            this.Load += new System.EventHandler(this.LicencaAddForm_Load);
            this.gbDadosContrato.ResumeLayout(false);
            this.gbDadosContrato.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbIdContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbDadosContrato;
        private System.Windows.Forms.MaskedTextBox mtbDtVencContrato;
        private System.Windows.Forms.MaskedTextBox mtbDtRegContrato;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNomeSoftware;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtxbChave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mtxbHashCliente;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mtxbHashChave;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnClose;
    }
}