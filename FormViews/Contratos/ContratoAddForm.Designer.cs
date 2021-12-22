
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
            this.pnlBottomMenu = new System.Windows.Forms.Panel();
            this.btnSaveContrato = new System.Windows.Forms.Button();
            this.btnAddClausula = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.cbSoftware = new System.Windows.Forms.ComboBox();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.dtVencimento = new System.Windows.Forms.DateTimePicker();
            this.dtRegistro = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTermo = new System.Windows.Forms.TextBox();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.txbId = new System.Windows.Forms.TextBox();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlRighMenu = new System.Windows.Forms.Panel();
            this.dgvClausulas = new System.Windows.Forms.DataGridView();
            this.dgvIncisos = new System.Windows.Forms.DataGridView();
            this.btnAddInciso = new System.Windows.Forms.Button();
            this.pnlBottomMenu.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlRighMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClausulas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncisos)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottomMenu
            // 
            this.pnlBottomMenu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBottomMenu.Controls.Add(this.btnSaveContrato);
            this.pnlBottomMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomMenu.Location = new System.Drawing.Point(0, 474);
            this.pnlBottomMenu.Name = "pnlBottomMenu";
            this.pnlBottomMenu.Size = new System.Drawing.Size(912, 44);
            this.pnlBottomMenu.TabIndex = 0;
            // 
            // btnSaveContrato
            // 
            this.btnSaveContrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveContrato.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSaveContrato.FlatAppearance.BorderSize = 0;
            this.btnSaveContrato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveContrato.Image = global::MLicencas.Properties.Resources.iconSave20x20;
            this.btnSaveContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveContrato.Location = new System.Drawing.Point(813, 5);
            this.btnSaveContrato.Name = "btnSaveContrato";
            this.btnSaveContrato.Size = new System.Drawing.Size(87, 29);
            this.btnSaveContrato.TabIndex = 0;
            this.btnSaveContrato.Text = "Salvar";
            this.btnSaveContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveContrato.UseVisualStyleBackColor = false;
            this.btnSaveContrato.Click += new System.EventHandler(this.btnSaveContrato_Click);
            // 
            // btnAddClausula
            // 
            this.btnAddClausula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddClausula.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddClausula.Enabled = false;
            this.btnAddClausula.FlatAppearance.BorderSize = 0;
            this.btnAddClausula.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddClausula.Image = global::MLicencas.Properties.Resources.IconAdd20x20;
            this.btnAddClausula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddClausula.Location = new System.Drawing.Point(813, 110);
            this.btnAddClausula.Name = "btnAddClausula";
            this.btnAddClausula.Size = new System.Drawing.Size(87, 29);
            this.btnAddClausula.TabIndex = 0;
            this.btnAddClausula.Text = "Clausula";
            this.btnAddClausula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddClausula.UseVisualStyleBackColor = false;
            this.btnAddClausula.Click += new System.EventHandler(this.btnAddClausula_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlHeader.Controls.Add(this.cbSoftware);
            this.pnlHeader.Controls.Add(this.cbCliente);
            this.pnlHeader.Controls.Add(this.cbStatus);
            this.pnlHeader.Controls.Add(this.dtVencimento);
            this.pnlHeader.Controls.Add(this.dtRegistro);
            this.pnlHeader.Controls.Add(this.label3);
            this.pnlHeader.Controls.Add(this.label8);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.label7);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label6);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.txbTermo);
            this.pnlHeader.Controls.Add(this.txbNome);
            this.pnlHeader.Controls.Add(this.txbId);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(912, 155);
            this.pnlHeader.TabIndex = 3;
            // 
            // cbSoftware
            // 
            this.cbSoftware.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSoftware.FormattingEnabled = true;
            this.cbSoftware.Location = new System.Drawing.Point(760, 56);
            this.cbSoftware.Name = "cbSoftware";
            this.cbSoftware.Size = new System.Drawing.Size(140, 21);
            this.cbSoftware.TabIndex = 3;
            // 
            // cbCliente
            // 
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(45, 55);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(226, 21);
            this.cbCliente.TabIndex = 3;
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(249, 3);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(72, 21);
            this.cbStatus.TabIndex = 3;
            // 
            // dtVencimento
            // 
            this.dtVencimento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtVencimento.Location = new System.Drawing.Point(815, 30);
            this.dtVencimento.MinDate = new System.DateTime(2021, 12, 18, 0, 0, 0, 0);
            this.dtVencimento.Name = "dtVencimento";
            this.dtVencimento.Size = new System.Drawing.Size(85, 20);
            this.dtVencimento.TabIndex = 2;
            // 
            // dtRegistro
            // 
            this.dtRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtRegistro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtRegistro.Location = new System.Drawing.Point(815, 4);
            this.dtRegistro.MinDate = new System.DateTime(2021, 12, 18, 0, 0, 0, 0);
            this.dtRegistro.Name = "dtRegistro";
            this.dtRegistro.Size = new System.Drawing.Size(85, 20);
            this.dtRegistro.TabIndex = 2;
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
            this.label8.Location = new System.Drawing.Point(708, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Software:";
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
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(726, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Data do Contrato:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 7);
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
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(705, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Validade do Contrato:";
            // 
            // txbTermo
            // 
            this.txbTermo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTermo.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTermo.Location = new System.Drawing.Point(45, 82);
            this.txbTermo.Multiline = true;
            this.txbTermo.Name = "txbTermo";
            this.txbTermo.Size = new System.Drawing.Size(855, 61);
            this.txbTermo.TabIndex = 0;
            this.txbTermo.Text = "Decidem as partes, na melhor forma de direito, celebrar o presente CONTRATO DE PR" +
    "ESTAÇÃO DE SERVIÇOS, que reger-se-á mediante as cláusulas e condições adiante es" +
    "tipuladas.";
            // 
            // txbNome
            // 
            this.txbNome.Location = new System.Drawing.Point(45, 29);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(276, 20);
            this.txbNome.TabIndex = 0;
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(45, 3);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(56, 20);
            this.txbId.TabIndex = 0;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.AutoScroll = true;
            this.pnlContainer.BackColor = System.Drawing.Color.Maroon;
            this.pnlContainer.Controls.Add(this.btnAddClausula);
            this.pnlContainer.Controls.Add(this.dgvClausulas);
            this.pnlContainer.Location = new System.Drawing.Point(0, 155);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(912, 151);
            this.pnlContainer.TabIndex = 4;
            // 
            // pnlRighMenu
            // 
            this.pnlRighMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRighMenu.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlRighMenu.Controls.Add(this.btnAddInciso);
            this.pnlRighMenu.Controls.Add(this.dgvIncisos);
            this.pnlRighMenu.Location = new System.Drawing.Point(0, 300);
            this.pnlRighMenu.Name = "pnlRighMenu";
            this.pnlRighMenu.Size = new System.Drawing.Size(912, 173);
            this.pnlRighMenu.TabIndex = 1;
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
            this.dgvClausulas.Size = new System.Drawing.Size(795, 123);
            this.dgvClausulas.TabIndex = 0;
            // 
            // dgvIncisos
            // 
            this.dgvIncisos.AllowUserToAddRows = false;
            this.dgvIncisos.AllowUserToDeleteRows = false;
            this.dgvIncisos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIncisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvIncisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncisos.Location = new System.Drawing.Point(11, 12);
            this.dgvIncisos.Name = "dgvIncisos";
            this.dgvIncisos.ReadOnly = true;
            this.dgvIncisos.Size = new System.Drawing.Size(795, 154);
            this.dgvIncisos.TabIndex = 0;
            // 
            // btnAddInciso
            // 
            this.btnAddInciso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddInciso.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddInciso.Enabled = false;
            this.btnAddInciso.FlatAppearance.BorderSize = 0;
            this.btnAddInciso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInciso.Image = global::MLicencas.Properties.Resources.IconAdd20x20;
            this.btnAddInciso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddInciso.Location = new System.Drawing.Point(812, 137);
            this.btnAddInciso.Name = "btnAddInciso";
            this.btnAddInciso.Size = new System.Drawing.Size(87, 29);
            this.btnAddInciso.TabIndex = 0;
            this.btnAddInciso.Text = "Inciso";
            this.btnAddInciso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddInciso.UseVisualStyleBackColor = false;
            this.btnAddInciso.Click += new System.EventHandler(this.btnAddClausula_Click);
            // 
            // ContratoAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 518);
            this.Controls.Add(this.pnlRighMenu);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBottomMenu);
            this.Name = "ContratoAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edição de Contrato";
            this.Load += new System.EventHandler(this.ContratoAddForm_Load);
            this.pnlBottomMenu.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlContainer.ResumeLayout(false);
            this.pnlRighMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClausulas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottomMenu;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnAddClausula;
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
        private System.Windows.Forms.Button btnAddInciso;
        private System.Windows.Forms.DataGridView dgvIncisos;
    }
}