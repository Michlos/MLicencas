
namespace MLicencas.FormViews.Fabrica
{
    partial class FabricaFormView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txbId = new System.Windows.Forms.TextBox();
            this.txbRazaoSocial = new System.Windows.Forms.TextBox();
            this.txbNomeFantasia = new System.Windows.Forms.TextBox();
            this.txbIe = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbWebSite = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mtxbCnpj = new System.Windows.Forms.MaskedTextBox();
            this.dgvEnderecosFabrica = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvContatosFabrica = new System.Windows.Forms.DataGridView();
            this.btnRemCont = new System.Windows.Forms.Button();
            this.btnAddCont = new System.Windows.Forms.Button();
            this.cMenuContatos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarTSMIContatos = new System.Windows.Forms.ToolStripMenuItem();
            this.editarTSMIContatos = new System.Windows.Forms.ToolStripMenuItem();
            this.removerTSMIContatos = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddEnd = new System.Windows.Forms.Button();
            this.btnRemEnd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cMenuEndereco = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarTSMIEndereco = new System.Windows.Forms.ToolStripMenuItem();
            this.editarTSMIEndereco = new System.Windows.Forms.ToolStripMenuItem();
            this.removerTSMIEndereco = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecosFabrica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatosFabrica)).BeginInit();
            this.cMenuContatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.cMenuEndereco.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(107, 22);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(63, 20);
            this.txbId.TabIndex = 0;
            // 
            // txbRazaoSocial
            // 
            this.txbRazaoSocial.Location = new System.Drawing.Point(107, 48);
            this.txbRazaoSocial.Name = "txbRazaoSocial";
            this.txbRazaoSocial.Size = new System.Drawing.Size(285, 20);
            this.txbRazaoSocial.TabIndex = 2;
            // 
            // txbNomeFantasia
            // 
            this.txbNomeFantasia.Location = new System.Drawing.Point(107, 77);
            this.txbNomeFantasia.Name = "txbNomeFantasia";
            this.txbNomeFantasia.Size = new System.Drawing.Size(285, 20);
            this.txbNomeFantasia.TabIndex = 3;
            // 
            // txbIe
            // 
            this.txbIe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbIe.Location = new System.Drawing.Point(562, 49);
            this.txbIe.Name = "txbIe";
            this.txbIe.Size = new System.Drawing.Size(111, 20);
            this.txbIe.TabIndex = 1;
            // 
            // txbEmail
            // 
            this.txbEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txbEmail.Location = new System.Drawing.Point(107, 105);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(250, 20);
            this.txbEmail.TabIndex = 4;
            // 
            // txbWebSite
            // 
            this.txbWebSite.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txbWebSite.Location = new System.Drawing.Point(424, 105);
            this.txbWebSite.Name = "txbWebSite";
            this.txbWebSite.Size = new System.Drawing.Size(250, 20);
            this.txbWebSite.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CNPJ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Inscrição Estadual:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Razão Social:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Nome Fantasia:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "E-mail:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(390, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Site:";
            // 
            // mtxbCnpj
            // 
            this.mtxbCnpj.Location = new System.Drawing.Point(562, 20);
            this.mtxbCnpj.Mask = "00,000,000\\/0000\\-00";
            this.mtxbCnpj.Name = "mtxbCnpj";
            this.mtxbCnpj.Size = new System.Drawing.Size(111, 20);
            this.mtxbCnpj.TabIndex = 0;
            this.mtxbCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // dgvEnderecosFabrica
            // 
            this.dgvEnderecosFabrica.AllowUserToAddRows = false;
            this.dgvEnderecosFabrica.AllowUserToDeleteRows = false;
            this.dgvEnderecosFabrica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEnderecosFabrica.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEnderecosFabrica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEnderecosFabrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEnderecosFabrica.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEnderecosFabrica.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvEnderecosFabrica.Location = new System.Drawing.Point(3, 14);
            this.dgvEnderecosFabrica.Name = "dgvEnderecosFabrica";
            this.dgvEnderecosFabrica.ReadOnly = true;
            this.dgvEnderecosFabrica.RowHeadersVisible = false;
            this.dgvEnderecosFabrica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEnderecosFabrica.Size = new System.Drawing.Size(415, 177);
            this.dgvEnderecosFabrica.TabIndex = 1;
            this.dgvEnderecosFabrica.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEnderecosFabrica_CellContentDoubleClick);
            this.dgvEnderecosFabrica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvEnderecosFabrica_CellFormatting);
            this.dgvEnderecosFabrica.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvEnderecosFabrica_CellMouseClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Endereços:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, -2);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Contatos:";
            // 
            // dgvContatosFabrica
            // 
            this.dgvContatosFabrica.AllowUserToAddRows = false;
            this.dgvContatosFabrica.AllowUserToDeleteRows = false;
            this.dgvContatosFabrica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContatosFabrica.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContatosFabrica.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvContatosFabrica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContatosFabrica.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvContatosFabrica.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvContatosFabrica.Location = new System.Drawing.Point(3, 13);
            this.dgvContatosFabrica.Name = "dgvContatosFabrica";
            this.dgvContatosFabrica.ReadOnly = true;
            this.dgvContatosFabrica.RowHeadersVisible = false;
            this.dgvContatosFabrica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContatosFabrica.Size = new System.Drawing.Size(243, 178);
            this.dgvContatosFabrica.TabIndex = 1;
            this.dgvContatosFabrica.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContatosFabrica_CellContentDoubleClick);
            this.dgvContatosFabrica.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvContatosFabrica_CellFormatting_1);
            this.dgvContatosFabrica.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContatosFabrica_CellMouseClick);
            // 
            // btnRemCont
            // 
            this.btnRemCont.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRemCont.Enabled = false;
            this.btnRemCont.FlatAppearance.BorderSize = 0;
            this.btnRemCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemCont.Location = new System.Drawing.Point(3, 194);
            this.btnRemCont.Name = "btnRemCont";
            this.btnRemCont.Size = new System.Drawing.Size(103, 22);
            this.btnRemCont.TabIndex = 14;
            this.btnRemCont.Tag = "5.3.3";
            this.btnRemCont.Text = "Rem Contato";
            this.btnRemCont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemCont.UseVisualStyleBackColor = false;
            this.btnRemCont.Click += new System.EventHandler(this.btnRemCont_Click);
            // 
            // btnAddCont
            // 
            this.btnAddCont.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddCont.Enabled = false;
            this.btnAddCont.FlatAppearance.BorderSize = 0;
            this.btnAddCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCont.Location = new System.Drawing.Point(143, 194);
            this.btnAddCont.Name = "btnAddCont";
            this.btnAddCont.Size = new System.Drawing.Size(103, 22);
            this.btnAddCont.TabIndex = 0;
            this.btnAddCont.Tag = "5.3.1";
            this.btnAddCont.Text = "Add Contato";
            this.btnAddCont.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddCont.UseVisualStyleBackColor = false;
            this.btnAddCont.Click += new System.EventHandler(this.btnAddCont_Click);
            // 
            // cMenuContatos
            // 
            this.cMenuContatos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarTSMIContatos,
            this.editarTSMIContatos,
            this.removerTSMIContatos});
            this.cMenuContatos.Name = "cMenuContatos";
            this.cMenuContatos.Size = new System.Drawing.Size(126, 70);
            // 
            // adicionarTSMIContatos
            // 
            this.adicionarTSMIContatos.Name = "adicionarTSMIContatos";
            this.adicionarTSMIContatos.Size = new System.Drawing.Size(125, 22);
            this.adicionarTSMIContatos.Tag = "5.3.1";
            this.adicionarTSMIContatos.Text = "Adicionar";
            this.adicionarTSMIContatos.Click += new System.EventHandler(this.adicionarTSMIContatos_Click);
            // 
            // editarTSMIContatos
            // 
            this.editarTSMIContatos.Name = "editarTSMIContatos";
            this.editarTSMIContatos.Size = new System.Drawing.Size(125, 22);
            this.editarTSMIContatos.Tag = "5.3";
            this.editarTSMIContatos.Text = "Editar";
            this.editarTSMIContatos.Click += new System.EventHandler(this.editarTSMIContatos_Click);
            // 
            // removerTSMIContatos
            // 
            this.removerTSMIContatos.Name = "removerTSMIContatos";
            this.removerTSMIContatos.Size = new System.Drawing.Size(125, 22);
            this.removerTSMIContatos.Tag = "5.3.3";
            this.removerTSMIContatos.Text = "Remover";
            this.removerTSMIContatos.Click += new System.EventHandler(this.removerTSMIContatos_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvContatosFabrica);
            this.groupBox1.Controls.Add(this.btnAddCont);
            this.groupBox1.Controls.Add(this.btnRemCont);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(459, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 231);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txbId);
            this.groupBox2.Controls.Add(this.txbNomeFantasia);
            this.groupBox2.Controls.Add(this.mtxbCnpj);
            this.groupBox2.Controls.Add(this.txbRazaoSocial);
            this.groupBox2.Controls.Add(this.txbEmail);
            this.groupBox2.Controls.Add(this.txbWebSite);
            this.groupBox2.Controls.Add(this.txbIe);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 149);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, -2);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Dados Cadastrais:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnAddEnd);
            this.groupBox3.Controls.Add(this.dgvEnderecosFabrica);
            this.groupBox3.Controls.Add(this.btnRemEnd);
            this.groupBox3.Location = new System.Drawing.Point(12, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(424, 231);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // btnAddEnd
            // 
            this.btnAddEnd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddEnd.Enabled = false;
            this.btnAddEnd.FlatAppearance.BorderSize = 0;
            this.btnAddEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddEnd.Location = new System.Drawing.Point(315, 194);
            this.btnAddEnd.Name = "btnAddEnd";
            this.btnAddEnd.Size = new System.Drawing.Size(103, 22);
            this.btnAddEnd.TabIndex = 0;
            this.btnAddEnd.Tag = "5.2";
            this.btnAddEnd.Text = "Add Endereço";
            this.btnAddEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddEnd.UseVisualStyleBackColor = false;
            this.btnAddEnd.Click += new System.EventHandler(this.btnAddEnd_Click);
            // 
            // btnRemEnd
            // 
            this.btnRemEnd.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRemEnd.Enabled = false;
            this.btnRemEnd.FlatAppearance.BorderSize = 0;
            this.btnRemEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemEnd.Location = new System.Drawing.Point(3, 194);
            this.btnRemEnd.Name = "btnRemEnd";
            this.btnRemEnd.Size = new System.Drawing.Size(103, 22);
            this.btnRemEnd.TabIndex = 14;
            this.btnRemEnd.Tag = "5.4.3";
            this.btnRemEnd.Text = "Rem Endereço";
            this.btnRemEnd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRemEnd.UseVisualStyleBackColor = false;
            this.btnRemEnd.Click += new System.EventHandler(this.btnRemEnd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(602, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 1;
            this.btnSave.Tag = "5.2";
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cMenuEndereco
            // 
            this.cMenuEndereco.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarTSMIEndereco,
            this.editarTSMIEndereco,
            this.removerTSMIEndereco});
            this.cMenuEndereco.Name = "cMenuContatos";
            this.cMenuEndereco.Size = new System.Drawing.Size(126, 70);
            // 
            // adicionarTSMIEndereco
            // 
            this.adicionarTSMIEndereco.Name = "adicionarTSMIEndereco";
            this.adicionarTSMIEndereco.Size = new System.Drawing.Size(125, 22);
            this.adicionarTSMIEndereco.Tag = "5.2";
            this.adicionarTSMIEndereco.Text = "Adicionar";
            this.adicionarTSMIEndereco.Click += new System.EventHandler(this.adicionarTSMIEndereco_Click);
            // 
            // editarTSMIEndereco
            // 
            this.editarTSMIEndereco.Name = "editarTSMIEndereco";
            this.editarTSMIEndereco.Size = new System.Drawing.Size(125, 22);
            this.editarTSMIEndereco.Tag = "5.2";
            this.editarTSMIEndereco.Text = "Editar";
            this.editarTSMIEndereco.Click += new System.EventHandler(this.editarTSMIEndereco_Click);
            // 
            // removerTSMIEndereco
            // 
            this.removerTSMIEndereco.Name = "removerTSMIEndereco";
            this.removerTSMIEndereco.Size = new System.Drawing.Size(125, 22);
            this.removerTSMIEndereco.Tag = "5.2";
            this.removerTSMIEndereco.Text = "Remover";
            this.removerTSMIEndereco.Click += new System.EventHandler(this.removerTSMIEndereco_Click);
            // 
            // FabricaFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 467);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FabricaFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fábrica - Cadastro da Fábrica de Software";
            this.Load += new System.EventHandler(this.FabricaFormView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnderecosFabrica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatosFabrica)).EndInit();
            this.cMenuContatos.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.cMenuEndereco.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.TextBox txbRazaoSocial;
        private System.Windows.Forms.TextBox txbNomeFantasia;
        private System.Windows.Forms.TextBox txbIe;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.TextBox txbWebSite;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mtxbCnpj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddCont;
        private System.Windows.Forms.Button btnRemCont;
        private System.Windows.Forms.ContextMenuStrip cMenuContatos;
        private System.Windows.Forms.ToolStripMenuItem adicionarTSMIContatos;
        private System.Windows.Forms.ToolStripMenuItem editarTSMIContatos;
        private System.Windows.Forms.ToolStripMenuItem removerTSMIContatos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddEnd;
        private System.Windows.Forms.Button btnRemEnd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ContextMenuStrip cMenuEndereco;
        private System.Windows.Forms.ToolStripMenuItem adicionarTSMIEndereco;
        private System.Windows.Forms.ToolStripMenuItem editarTSMIEndereco;
        private System.Windows.Forms.ToolStripMenuItem removerTSMIEndereco;
        public System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.DataGridView dgvEnderecosFabrica;
        public System.Windows.Forms.DataGridView dgvContatosFabrica;
    }
}