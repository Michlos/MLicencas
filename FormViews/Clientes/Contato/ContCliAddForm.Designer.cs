
namespace MLicencas.FormViews.Clientes.Contato
{
    partial class ContCliAddForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.telefoneContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txbId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txbCargo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTelefonesContato = new System.Windows.Forms.DataGridView();
            this.gbTelefones = new System.Windows.Forms.GroupBox();
            this.btnAddTel = new System.Windows.Forms.Button();
            this.btnRemTel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chbResponsavel = new System.Windows.Forms.CheckBox();
            this.gbDadosContrato = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbRg = new System.Windows.Forms.TextBox();
            this.mtxbCpf = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbEstadoCivil = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbNacionalidade = new System.Windows.Forms.TextBox();
            this.telefoneContextMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesContato)).BeginInit();
            this.gbTelefones.SuspendLayout();
            this.gbDadosContrato.SuspendLayout();
            this.SuspendLayout();
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.removerToolStripMenuItem.Tag = "1.5.3";
            this.removerToolStripMenuItem.Text = "Remover";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.btnRemTel_Click);
            // 
            // telefoneContextMenu
            // 
            this.telefoneContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarToolStripMenuItem,
            this.removerToolStripMenuItem});
            this.telefoneContextMenu.Name = "telefoneContextMenu";
            this.telefoneContextMenu.Size = new System.Drawing.Size(126, 48);
            // 
            // adicionarToolStripMenuItem
            // 
            this.adicionarToolStripMenuItem.Name = "adicionarToolStripMenuItem";
            this.adicionarToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.adicionarToolStripMenuItem.Tag = "1.5.1";
            this.adicionarToolStripMenuItem.Text = "Adicionar";
            this.adicionarToolStripMenuItem.Click += new System.EventHandler(this.btnAddTel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(429, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 23;
            this.btnSave.Tag = "1.5.1";
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
            this.btnClose.Location = new System.Drawing.Point(12, 249);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 25;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(86, 19);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(41, 20);
            this.txbId.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chbResponsavel);
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
            this.groupBox1.Size = new System.Drawing.Size(350, 131);
            this.groupBox1.TabIndex = 22;
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
            // dgvTelefonesContato
            // 
            this.dgvTelefonesContato.AllowUserToAddRows = false;
            this.dgvTelefonesContato.AllowUserToDeleteRows = false;
            this.dgvTelefonesContato.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTelefonesContato.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTelefonesContato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTelefonesContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTelefonesContato.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvTelefonesContato.Location = new System.Drawing.Point(5, 15);
            this.dgvTelefonesContato.Name = "dgvTelefonesContato";
            this.dgvTelefonesContato.ReadOnly = true;
            this.dgvTelefonesContato.RowHeadersVisible = false;
            this.dgvTelefonesContato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvTelefonesContato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTelefonesContato.Size = new System.Drawing.Size(153, 76);
            this.dgvTelefonesContato.TabIndex = 21;
            this.dgvTelefonesContato.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTelefonesContato_CellMouseClick);
            // 
            // gbTelefones
            // 
            this.gbTelefones.Controls.Add(this.dgvTelefonesContato);
            this.gbTelefones.Controls.Add(this.btnAddTel);
            this.gbTelefones.Controls.Add(this.btnRemTel);
            this.gbTelefones.Controls.Add(this.label2);
            this.gbTelefones.Enabled = false;
            this.gbTelefones.Location = new System.Drawing.Point(368, 12);
            this.gbTelefones.Name = "gbTelefones";
            this.gbTelefones.Size = new System.Drawing.Size(164, 131);
            this.gbTelefones.TabIndex = 24;
            this.gbTelefones.TabStop = false;
            // 
            // btnAddTel
            // 
            this.btnAddTel.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddTel.FlatAppearance.BorderSize = 0;
            this.btnAddTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTel.Location = new System.Drawing.Point(101, 97);
            this.btnAddTel.Name = "btnAddTel";
            this.btnAddTel.Size = new System.Drawing.Size(57, 22);
            this.btnAddTel.TabIndex = 0;
            this.btnAddTel.Tag = "1.5.1";
            this.btnAddTel.Text = "Add";
            this.btnAddTel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddTel.UseVisualStyleBackColor = false;
            this.btnAddTel.Click += new System.EventHandler(this.btnAddTel_Click);
            // 
            // btnRemTel
            // 
            this.btnRemTel.BackColor = System.Drawing.Color.PaleVioletRed;
            this.btnRemTel.FlatAppearance.BorderSize = 0;
            this.btnRemTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemTel.Location = new System.Drawing.Point(5, 97);
            this.btnRemTel.Name = "btnRemTel";
            this.btnRemTel.Size = new System.Drawing.Size(57, 22);
            this.btnRemTel.TabIndex = 20;
            this.btnRemTel.Tag = "1.5.3";
            this.btnRemTel.Text = "Remove";
            this.btnRemTel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemTel.UseVisualStyleBackColor = false;
            this.btnRemTel.Click += new System.EventHandler(this.btnRemTel_Click);
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
            // chbResponsavel
            // 
            this.chbResponsavel.AutoSize = true;
            this.chbResponsavel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chbResponsavel.Location = new System.Drawing.Point(226, 18);
            this.chbResponsavel.Name = "chbResponsavel";
            this.chbResponsavel.Size = new System.Drawing.Size(117, 17);
            this.chbResponsavel.TabIndex = 22;
            this.chbResponsavel.Text = "Responsável Legal";
            this.chbResponsavel.UseVisualStyleBackColor = true;
            this.chbResponsavel.CheckedChanged += new System.EventHandler(this.chbResponsavel_CheckedChanged);
            // 
            // gbDadosContrato
            // 
            this.gbDadosContrato.Controls.Add(this.mtxbCpf);
            this.gbDadosContrato.Controls.Add(this.label7);
            this.gbDadosContrato.Controls.Add(this.txbNacionalidade);
            this.gbDadosContrato.Controls.Add(this.txbEstadoCivil);
            this.gbDadosContrato.Controls.Add(this.label11);
            this.gbDadosContrato.Controls.Add(this.txbRg);
            this.gbDadosContrato.Controls.Add(this.label10);
            this.gbDadosContrato.Controls.Add(this.label9);
            this.gbDadosContrato.Controls.Add(this.label8);
            this.gbDadosContrato.Enabled = false;
            this.gbDadosContrato.Location = new System.Drawing.Point(12, 150);
            this.gbDadosContrato.Name = "gbDadosContrato";
            this.gbDadosContrato.Size = new System.Drawing.Size(514, 85);
            this.gbDadosContrato.TabIndex = 26;
            this.gbDadosContrato.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Dados Adicionais para Contrato";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Rg:";
            // 
            // txbRg
            // 
            this.txbRg.Location = new System.Drawing.Point(76, 19);
            this.txbRg.Name = "txbRg";
            this.txbRg.Size = new System.Drawing.Size(86, 20);
            this.txbRg.TabIndex = 0;
            // 
            // mtxbCpf
            // 
            this.mtxbCpf.Location = new System.Drawing.Point(356, 19);
            this.mtxbCpf.Mask = "000,000,000-00";
            this.mtxbCpf.Name = "mtxbCpf";
            this.mtxbCpf.Size = new System.Drawing.Size(94, 20);
            this.mtxbCpf.TabIndex = 22;
            this.mtxbCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(326, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "CPF:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Estado Civil:";
            // 
            // txbEstadoCivil
            // 
            this.txbEstadoCivil.Location = new System.Drawing.Point(76, 52);
            this.txbEstadoCivil.Name = "txbEstadoCivil";
            this.txbEstadoCivil.Size = new System.Drawing.Size(86, 20);
            this.txbEstadoCivil.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(272, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Nacionalidade:";
            // 
            // txbNacionalidade
            // 
            this.txbNacionalidade.Location = new System.Drawing.Point(356, 52);
            this.txbNacionalidade.Name = "txbNacionalidade";
            this.txbNacionalidade.Size = new System.Drawing.Size(93, 20);
            this.txbNacionalidade.TabIndex = 0;
            // 
            // ContCliAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 288);
            this.Controls.Add(this.gbDadosContrato);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbTelefones);
            this.Name = "ContCliAddForm";
            this.Text = "Clientes - Cadastro de Contatos";
            this.Load += new System.EventHandler(this.ContCliAddForm_Load);
            this.telefoneContextMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTelefonesContato)).EndInit();
            this.gbTelefones.ResumeLayout(false);
            this.gbTelefones.PerformLayout();
            this.gbDadosContrato.ResumeLayout(false);
            this.gbDadosContrato.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip telefoneContextMenu;
        private System.Windows.Forms.ToolStripMenuItem adicionarToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbCargo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dgvTelefonesContato;
        private System.Windows.Forms.GroupBox gbTelefones;
        private System.Windows.Forms.Button btnAddTel;
        private System.Windows.Forms.Button btnRemTel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbResponsavel;
        private System.Windows.Forms.GroupBox gbDadosContrato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtxbCpf;
        private System.Windows.Forms.TextBox txbRg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txbNacionalidade;
        private System.Windows.Forms.TextBox txbEstadoCivil;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}