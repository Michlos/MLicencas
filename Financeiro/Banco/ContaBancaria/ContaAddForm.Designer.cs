﻿
namespace Financeiro.Banco.ContaBancaria
{
    partial class ContaAddForm
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
            this.txbNomeBanco = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoConta = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbAgencia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbAgenciaDV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbConta = new System.Windows.Forms.TextBox();
            this.txbContaDV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chbEmiteBoleto = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbId
            // 
            this.txbId.Location = new System.Drawing.Point(90, 12);
            this.txbId.Name = "txbId";
            this.txbId.ReadOnly = true;
            this.txbId.Size = new System.Drawing.Size(44, 20);
            this.txbId.TabIndex = 0;
            this.txbId.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id:";
            // 
            // txbNomeBanco
            // 
            this.txbNomeBanco.Location = new System.Drawing.Point(90, 38);
            this.txbNomeBanco.Name = "txbNomeBanco";
            this.txbNomeBanco.ReadOnly = true;
            this.txbNomeBanco.Size = new System.Drawing.Size(112, 20);
            this.txbNomeBanco.TabIndex = 0;
            this.txbNomeBanco.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Banco:";
            // 
            // cbTipoConta
            // 
            this.cbTipoConta.FormattingEnabled = true;
            this.cbTipoConta.Location = new System.Drawing.Point(90, 64);
            this.cbTipoConta.Name = "cbTipoConta";
            this.cbTipoConta.Size = new System.Drawing.Size(112, 21);
            this.cbTipoConta.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo de Conta:";
            // 
            // txbAgencia
            // 
            this.txbAgencia.Location = new System.Drawing.Point(90, 91);
            this.txbAgencia.Name = "txbAgencia";
            this.txbAgencia.Size = new System.Drawing.Size(78, 20);
            this.txbAgencia.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Agência:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "-";
            // 
            // txbAgenciaDV
            // 
            this.txbAgenciaDV.Location = new System.Drawing.Point(178, 91);
            this.txbAgenciaDV.Name = "txbAgenciaDV";
            this.txbAgenciaDV.Size = new System.Drawing.Size(24, 20);
            this.txbAgenciaDV.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(168, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "-";
            // 
            // txbConta
            // 
            this.txbConta.Location = new System.Drawing.Point(90, 117);
            this.txbConta.Name = "txbConta";
            this.txbConta.Size = new System.Drawing.Size(78, 20);
            this.txbConta.TabIndex = 3;
            // 
            // txbContaDV
            // 
            this.txbContaDV.Location = new System.Drawing.Point(178, 117);
            this.txbContaDV.Name = "txbContaDV";
            this.txbContaDV.Size = new System.Drawing.Size(24, 20);
            this.txbContaDV.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Conta:";
            // 
            // chbEmiteBoleto
            // 
            this.chbEmiteBoleto.AutoSize = true;
            this.chbEmiteBoleto.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbEmiteBoleto.Location = new System.Drawing.Point(18, 143);
            this.chbEmiteBoleto.Name = "chbEmiteBoleto";
            this.chbEmiteBoleto.Size = new System.Drawing.Size(85, 17);
            this.chbEmiteBoleto.TabIndex = 5;
            this.chbEmiteBoleto.Text = "Emite Boleto";
            this.chbEmiteBoleto.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(129, 172);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 24);
            this.btnClose.TabIndex = 24;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ContaAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 208);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbEmiteBoleto);
            this.Controls.Add(this.cbTipoConta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbContaDV);
            this.Controls.Add(this.txbAgenciaDV);
            this.Controls.Add(this.txbConta);
            this.Controls.Add(this.txbAgencia);
            this.Controls.Add(this.txbNomeBanco);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContaAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro - Add Conta";
            this.Load += new System.EventHandler(this.ContaAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNomeBanco;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoConta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbAgencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbAgenciaDV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbConta;
        private System.Windows.Forms.TextBox txbContaDV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbEmiteBoleto;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
    }
}