﻿
namespace MLicencas.FormViews.Contatos
{
    partial class ContatoAddForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbCargo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grbTelefones = new System.Windows.Forms.GroupBox();
            this.dgvTelefonesContato = new System.Windows.Forms.DataGridView();
            this.btnAddTel = new System.Windows.Forms.Button();
            this.btnRemTel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grbTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesContato)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 155);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(422, 155);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Tag = "5.2";
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txbEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txbCargo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txbNome);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txbId);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(86, 97);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(161, 20);
            this.txbEmail.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "E-mail:";
            // 
            // txbCargo
            // 
            this.txbCargo.Location = new System.Drawing.Point(86, 71);
            this.txbCargo.Name = "txbCargo";
            this.txbCargo.Size = new System.Drawing.Size(142, 20);
            this.txbCargo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Cargo/Função:";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(86, 45);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(257, 20);
            this.txbNome.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nome:";
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(86, 19);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(41, 20);
            this.txbId.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Código:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Dados do Contato";
            // 
            // grbTelefones
            // 
            this.grbTelefones.Controls.Add(this.dgvTelefonesContato);
            this.grbTelefones.Controls.Add(this.btnAddTel);
            this.grbTelefones.Controls.Add(this.btnRemTel);
            this.grbTelefones.Controls.Add(this.label2);
            this.grbTelefones.Enabled = false;
            this.grbTelefones.Location = new System.Drawing.Point(380, 12);
            this.grbTelefones.Name = "grbTelefones";
            this.grbTelefones.Size = new System.Drawing.Size(152, 131);
            this.grbTelefones.TabIndex = 2;
            this.grbTelefones.TabStop = false;
            // 
            // dgvTelefonesContato
            // 
            this.dgvTelefonesContato.AllowUserToAddRows = false;
            this.dgvTelefonesContato.AllowUserToDeleteRows = false;
            this.dgvTelefonesContato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelefonesContato.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTelefonesContato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTelefonesContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonesContato.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvTelefonesContato.Location = new System.Drawing.Point(4, 15);
            this.dgvTelefonesContato.Name = "dgvTelefonesContato";
            this.dgvTelefonesContato.ReadOnly = true;
            this.dgvTelefonesContato.RowHeadersVisible = false;
            this.dgvTelefonesContato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTelefonesContato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTelefonesContato.Size = new System.Drawing.Size(141, 76);
            this.dgvTelefonesContato.TabIndex = 21;
            this.dgvTelefonesContato.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTelefonesContato_CellFormatting);
            // 
            // btnAddTel
            // 
            this.btnAddTel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddTel.Enabled = false;
            this.btnAddTel.FlatAppearance.BorderSize = 0;
            this.btnAddTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTel.Location = new System.Drawing.Point(88, 97);
            this.btnAddTel.Name = "btnAddTel";
            this.btnAddTel.Size = new System.Drawing.Size(57, 22);
            this.btnAddTel.TabIndex = 0;
            this.btnAddTel.Tag = "5.2";
            this.btnAddTel.Text = "Add";
            this.btnAddTel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddTel.UseVisualStyleBackColor = false;
            // 
            // btnRemTel
            // 
            this.btnRemTel.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnRemTel.Enabled = false;
            this.btnRemTel.FlatAppearance.BorderSize = 0;
            this.btnRemTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemTel.Location = new System.Drawing.Point(4, 95);
            this.btnRemTel.Name = "btnRemTel";
            this.btnRemTel.Size = new System.Drawing.Size(57, 22);
            this.btnRemTel.TabIndex = 20;
            this.btnRemTel.Tag = "5.2";
            this.btnRemTel.Text = "Remove";
            this.btnRemTel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemTel.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Telefones";
            // 
            // ContatoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 194);
            this.Controls.Add(this.grbTelefones);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Name = "ContatoAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contato Fábrica";
            this.Load += new System.EventHandler(this.ContatoAddForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbTelefones.ResumeLayout(false);
            this.grbTelefones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesContato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbTelefones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTel;
        private System.Windows.Forms.Button btnRemTel;
        public System.Windows.Forms.DataGridView dgvTelefonesContato;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbCargo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label3;
    }
}