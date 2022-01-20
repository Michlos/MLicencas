
namespace MLicencas.FormViews.Contratos
{
    partial class ContratoAddForm
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
            this.pnlBottomMenu = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGerarLicenca = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.txbParcelas = new System.Windows.Forms.TextBox();
            this.cbSoftware = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtVencimento = new System.Windows.Forms.DateTimePicker();
            this.dtRegistro = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTermo = new System.Windows.Forms.TextBox();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvClausulas = new System.Windows.Forms.DataGridView();
            this.pnlRighMenu = new System.Windows.Forms.Panel();
            this.dgvIncisos = new System.Windows.Forms.DataGridView();
            this.clausulaContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novoClausulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarClausulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerClausulaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incisoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novoIncisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarIncisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removerIncisoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txbValor = new System.Windows.Forms.TextBox();
            this.txbValorParcela = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSaveContrato = new System.Windows.Forms.Button();
            this.pnlBottomMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClausulas)).BeginInit();
            this.pnlRighMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncisos)).BeginInit();
            this.clausulaContextMenu.SuspendLayout();
            this.incisoContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottomMenu
            // 
            this.pnlBottomMenu.Controls.Add(this.btnClose);
            this.pnlBottomMenu.Controls.Add(this.btnGerarLicenca);
            this.pnlBottomMenu.Controls.Add(this.btnSaveContrato);
            this.pnlBottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomMenu.Location = new System.Drawing.Point(0, 474);
            this.pnlBottomMenu.Name = "pnlBottomMenu";
            this.pnlBottomMenu.Size = new System.Drawing.Size(753, 44);
            this.pnlBottomMenu.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGerarLicenca
            // 
            this.btnGerarLicenca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGerarLicenca.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGerarLicenca.Enabled = false;
            this.btnGerarLicenca.FlatAppearance.BorderSize = 0;
            this.btnGerarLicenca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarLicenca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGerarLicenca.Location = new System.Drawing.Point(327, 5);
            this.btnGerarLicenca.Name = "btnGerarLicenca";
            this.btnGerarLicenca.Size = new System.Drawing.Size(87, 29);
            this.btnGerarLicenca.TabIndex = 1;
            this.btnGerarLicenca.Text = "Gerar Licença";
            this.btnGerarLicenca.UseVisualStyleBackColor = false;
            this.btnGerarLicenca.Click += new System.EventHandler(this.btnSaveContrato_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.txbParcelas);
            this.pnlHeader.Controls.Add(this.cbSoftware);
            this.pnlHeader.Controls.Add(this.cbCliente);
            this.pnlHeader.Controls.Add(this.cbStatus);
            this.pnlHeader.Controls.Add(this.dtVencimento);
            this.pnlHeader.Controls.Add(this.dtRegistro);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label8);
            this.pnlHeader.Controls.Add(this.label11);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label7);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.txbTermo);
            this.pnlHeader.Controls.Add(this.txbValorParcela);
            this.pnlHeader.Controls.Add(this.txbValor);
            this.pnlHeader.Controls.Add(this.textBox3);
            this.pnlHeader.Controls.Add(this.txbNome);
            this.pnlHeader.Controls.Add(this.txbId);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.label9);
            this.pnlHeader.Controls.Add(this.label10);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(753, 153);
            this.pnlHeader.TabIndex = 0;
            // 
            // txbParcelas
            // 
            this.txbParcelas.Location = new System.Drawing.Point(550, 29);
            this.txbParcelas.Name = "txbParcelas";
            this.txbParcelas.Size = new System.Drawing.Size(32, 20);
            this.txbParcelas.TabIndex = 6;
            this.txbParcelas.Leave += new System.EventHandler(this.txbParcelas_Leave);
            // 
            // cbSoftware
            // 
            this.cbSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSoftware.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSoftware.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSoftware.FormattingEnabled = true;
            this.cbSoftware.Location = new System.Drawing.Point(349, 55);
            this.cbSoftware.Name = "cbSoftware";
            this.cbSoftware.Size = new System.Drawing.Size(140, 21);
            this.cbSoftware.TabIndex = 9;
            // 
            // cbCliente
            // 
            this.cbCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(48, 55);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(226, 21);
            this.cbCliente.TabIndex = 8;
            this.cbCliente.TabStop = false;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(252, 3);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(72, 21);
            this.cbStatus.TabIndex = 1;
            this.cbStatus.TabStop = false;
            // 
            // dtVencimento
            // 
            this.dtVencimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVencimento.Location = new System.Drawing.Point(656, 3);
            this.dtVencimento.MinDate = new System.DateTime(2021, 12, 18, 0, 0, 0, 0);
            this.dtVencimento.Name = "dtVencimento";
            this.dtVencimento.Size = new System.Drawing.Size(85, 20);
            this.dtVencimento.TabIndex = 3;
            // 
            // dtRegistro
            // 
            this.dtRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegistro.Location = new System.Drawing.Point(496, 3);
            this.dtRegistro.MinDate = new System.DateTime(2021, 12, 18, 0, 0, 0, 0);
            this.dtRegistro.Name = "dtRegistro";
            this.dtRegistro.Size = new System.Drawing.Size(85, 20);
            this.dtRegistro.TabIndex = 2;
            this.dtRegistro.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Termo:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(297, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Software:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(499, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Parcelas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Título:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Cliente:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // txbTermo
            // 
            this.txbTermo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTermo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTermo.Location = new System.Drawing.Point(48, 82);
            this.txbTermo.Multiline = true;
            this.txbTermo.Name = "txbTermo";
            this.txbTermo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbTermo.Size = new System.Drawing.Size(693, 61);
            this.txbTermo.TabIndex = 10;
            this.txbTermo.TabStop = false;
            this.txbTermo.Text = "Decidem as partes, na melhor forma de direito, celebrar o presente CONTRATO DE PR" +
    "ESTAÇÃO DE SERVIÇOS, que reger-se-á mediante as cláusulas e condições adiante es" +
    "tipuladas.";
            // 
            // txbNome
            // 
            this.txbNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbNome.Location = new System.Drawing.Point(48, 29);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(276, 20);
            this.txbNome.TabIndex = 4;
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(48, 3);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(56, 20);
            this.txbId.TabIndex = 0;
            this.txbId.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Registro:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vencimento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(334, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Valor Contrato:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(591, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Valor Parcela:";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.Controls.Add(this.dgvClausulas);
            this.pnlContainer.Controls.Add(this.label12);
            this.pnlContainer.Location = new System.Drawing.Point(0, 155);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(753, 151);
            this.pnlContainer.TabIndex = 2;
            // 
            // dgvClausulas
            // 
            this.dgvClausulas.AllowUserToAddRows = false;
            this.dgvClausulas.AllowUserToDeleteRows = false;
            this.dgvClausulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClausulas.BackgroundColor = System.Drawing.Color.White;
            this.dgvClausulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClausulas.Location = new System.Drawing.Point(12, 16);
            this.dgvClausulas.Name = "dgvClausulas";
            this.dgvClausulas.ReadOnly = true;
            this.dgvClausulas.RowHeadersVisible = false;
            this.dgvClausulas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvClausulas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClausulas.Size = new System.Drawing.Size(729, 103);
            this.dgvClausulas.TabIndex = 0;
            this.dgvClausulas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClausulas_CellClick);
            this.dgvClausulas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvClausulas_MouseClick);
            // 
            // pnlRighMenu
            // 
            this.pnlRighMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRighMenu.Controls.Add(this.dgvIncisos);
            this.pnlRighMenu.Controls.Add(this.label13);
            this.pnlRighMenu.Location = new System.Drawing.Point(0, 280);
            this.pnlRighMenu.Name = "pnlRighMenu";
            this.pnlRighMenu.Size = new System.Drawing.Size(753, 193);
            this.pnlRighMenu.TabIndex = 3;
            // 
            // dgvIncisos
            // 
            this.dgvIncisos.AllowUserToAddRows = false;
            this.dgvIncisos.AllowUserToDeleteRows = false;
            this.dgvIncisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncisos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvIncisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncisos.Location = new System.Drawing.Point(11, 20);
            this.dgvIncisos.Name = "dgvIncisos";
            this.dgvIncisos.ReadOnly = true;
            this.dgvIncisos.RowHeadersVisible = false;
            this.dgvIncisos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvIncisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncisos.Size = new System.Drawing.Size(730, 166);
            this.dgvIncisos.TabIndex = 0;
            this.dgvIncisos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvIncisos_MouseClick);
            // 
            // clausulaContextMenu
            // 
            this.clausulaContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoClausulaToolStripMenuItem,
            this.editarClausulaToolStripMenuItem,
            this.removerClausulaToolStripMenuItem});
            this.clausulaContextMenu.Name = "clausulaContextMenu";
            this.clausulaContextMenu.Size = new System.Drawing.Size(122, 70);
            // 
            // novoClausulaToolStripMenuItem
            // 
            this.novoClausulaToolStripMenuItem.Name = "novoClausulaToolStripMenuItem";
            this.novoClausulaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.novoClausulaToolStripMenuItem.Text = "Novo";
            this.novoClausulaToolStripMenuItem.Click += new System.EventHandler(this.btnAddClausula_Click);
            // 
            // editarClausulaToolStripMenuItem
            // 
            this.editarClausulaToolStripMenuItem.Name = "editarClausulaToolStripMenuItem";
            this.editarClausulaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.editarClausulaToolStripMenuItem.Text = "Editar";
            this.editarClausulaToolStripMenuItem.Click += new System.EventHandler(this.editarClausulaToolStripMenuItem_Click);
            // 
            // removerClausulaToolStripMenuItem
            // 
            this.removerClausulaToolStripMenuItem.Name = "removerClausulaToolStripMenuItem";
            this.removerClausulaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.removerClausulaToolStripMenuItem.Text = "Remover";
            this.removerClausulaToolStripMenuItem.Click += new System.EventHandler(this.removerClausulaToolStripMenuItem_Click);
            // 
            // incisoContextMenu
            // 
            this.incisoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoIncisoToolStripMenuItem,
            this.editarIncisoToolStripMenuItem,
            this.removerIncisoToolStripMenuItem});
            this.incisoContextMenu.Name = "incisoContextMenu";
            this.incisoContextMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // novoIncisoToolStripMenuItem
            // 
            this.novoIncisoToolStripMenuItem.Name = "novoIncisoToolStripMenuItem";
            this.novoIncisoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.novoIncisoToolStripMenuItem.Text = "Novo";
            this.novoIncisoToolStripMenuItem.Click += new System.EventHandler(this.btnAddInciso_Click);
            // 
            // editarIncisoToolStripMenuItem
            // 
            this.editarIncisoToolStripMenuItem.Name = "editarIncisoToolStripMenuItem";
            this.editarIncisoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editarIncisoToolStripMenuItem.Text = "Editar";
            this.editarIncisoToolStripMenuItem.Click += new System.EventHandler(this.editarIncisoToolStripMenuItem_Click);
            // 
            // removerIncisoToolStripMenuItem
            // 
            this.removerIncisoToolStripMenuItem.Name = "removerIncisoToolStripMenuItem";
            this.removerIncisoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.removerIncisoToolStripMenuItem.Text = "Remover";
            this.removerIncisoToolStripMenuItem.Click += new System.EventHandler(this.removerIncisoToolStripMenuItem_Click);
            // 
            // txbValor
            // 
            this.txbValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbValor.Location = new System.Drawing.Point(409, 29);
            this.txbValor.Name = "txbValor";
            this.txbValor.Size = new System.Drawing.Size(80, 20);
            this.txbValor.TabIndex = 5;
            // 
            // txbValorParcela
            // 
            this.txbValorParcela.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txbValorParcela.Location = new System.Drawing.Point(661, 29);
            this.txbValorParcela.Name = "txbValorParcela";
            this.txbValorParcela.Size = new System.Drawing.Size(80, 20);
            this.txbValorParcela.TabIndex = 7;
            this.txbValorParcela.TabStop = false;
            // 
            // textBox3
            // 
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Location = new System.Drawing.Point(661, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(80, 20);
            this.textBox3.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Cláusulas - Cabeçalho";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Termos";
            // 
            // btnSaveContrato
            // 
            this.btnSaveContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveContrato.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSaveContrato.FlatAppearance.BorderSize = 0;
            this.btnSaveContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveContrato.Image = global::MLicencas.Properties.Resources.iconSave20x20;
            this.btnSaveContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveContrato.Location = new System.Drawing.Point(654, 5);
            this.btnSaveContrato.Name = "btnSaveContrato";
            this.btnSaveContrato.Size = new System.Drawing.Size(87, 29);
            this.btnSaveContrato.TabIndex = 0;
            this.btnSaveContrato.Text = "Salvar";
            this.btnSaveContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveContrato.UseVisualStyleBackColor = false;
            this.btnSaveContrato.Click += new System.EventHandler(this.btnSaveContrato_Click);
            // 
            // ContratoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 518);
            this.Controls.Add(this.pnlRighMenu);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottomMenu);
            this.Name = "ContratoAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contrato - Edição de Contrato";
            this.Load += new System.EventHandler(this.ContratoAddForm_Load);
            this.pnlBottomMenu.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClausulas)).EndInit();
            this.pnlRighMenu.ResumeLayout(false);
            this.pnlRighMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncisos)).EndInit();
            this.clausulaContextMenu.ResumeLayout(false);
            this.incisoContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomMenu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnSaveContrato;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTermo;
        private System.Windows.Forms.DateTimePicker dtRegistro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtVencimento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSoftware;
        private System.Windows.Forms.ComboBox cbCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlRighMenu;
        private System.Windows.Forms.DataGridView dgvClausulas;
        private System.Windows.Forms.DataGridView dgvIncisos;
        private System.Windows.Forms.ContextMenuStrip clausulaContextMenu;
        private System.Windows.Forms.ToolStripMenuItem novoClausulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarClausulaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerClausulaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip incisoContextMenu;
        private System.Windows.Forms.ToolStripMenuItem novoIncisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarIncisoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removerIncisoToolStripMenuItem;
        private System.Windows.Forms.Button btnGerarLicenca;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txbParcelas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbValorParcela;
        private System.Windows.Forms.TextBox txbValor;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}