
namespace MLicencas.FormViews.Clientes
{
    partial class ClienteAddForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txbId = new System.Windows.Forms.TextBox();
            this.mtxbCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRazaoSocial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbNomeFantasia = new System.Windows.Forms.TextBox();
            this.mtxbIe = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbSite = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbEndereco = new System.Windows.Forms.GroupBox();
            this.btnRemoveEnd = new System.Windows.Forms.Button();
            this.btnNovoEnd = new System.Windows.Forms.Button();
            this.dgvEndereco = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.gbContato = new System.Windows.Forms.GroupBox();
            this.btnRemoveCont = new System.Windows.Forms.Button();
            this.btnNovoCont = new System.Windows.Forms.Button();
            this.dgvContato = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbEndereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndereco)).BeginInit();
            this.gbContato.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).BeginInit();
            this.SuspendLayout();
            // 
            // txbId
            // 
            this.txbId.Enabled = false;
            this.txbId.Location = new System.Drawing.Point(91, 10);
            this.txbId.Name = "txbId";
            this.txbId.Size = new System.Drawing.Size(57, 20);
            this.txbId.TabIndex = 0;
            this.txbId.TabStop = false;
            // 
            // mtxbCnpj
            // 
            this.mtxbCnpj.Location = new System.Drawing.Point(372, 68);
            this.mtxbCnpj.Mask = "00,000,000/0000-00";
            this.mtxbCnpj.Name = "mtxbCnpj";
            this.mtxbCnpj.Size = new System.Drawing.Size(110, 20);
            this.mtxbCnpj.TabIndex = 2;
            this.mtxbCnpj.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código:";
            // 
            // cbStatus
            // 
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(420, 39);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 21);
            this.cbStatus.TabIndex = 3;
            this.cbStatus.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Razão Social:";
            // 
            // txbRazaoSocial
            // 
            this.txbRazaoSocial.Location = new System.Drawing.Point(91, 40);
            this.txbRazaoSocial.Name = "txbRazaoSocial";
            this.txbRazaoSocial.Size = new System.Drawing.Size(222, 20);
            this.txbRazaoSocial.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nome Fantasia:";
            // 
            // txbNomeFantasia
            // 
            this.txbNomeFantasia.Location = new System.Drawing.Point(91, 68);
            this.txbNomeFantasia.Name = "txbNomeFantasia";
            this.txbNomeFantasia.Size = new System.Drawing.Size(222, 20);
            this.txbNomeFantasia.TabIndex = 1;
            // 
            // mtxbIe
            // 
            this.mtxbIe.Location = new System.Drawing.Point(382, 97);
            this.mtxbIe.Name = "mtxbIe";
            this.mtxbIe.Size = new System.Drawing.Size(100, 20);
            this.mtxbIe.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "CNPJ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "IE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "E-mail:";
            // 
            // txbEmail
            // 
            this.txbEmail.Location = new System.Drawing.Point(91, 97);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(188, 20);
            this.txbEmail.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "WebSite:";
            // 
            // txbSite
            // 
            this.txbSite.Location = new System.Drawing.Point(91, 127);
            this.txbSite.Name = "txbSite";
            this.txbSite.Size = new System.Drawing.Size(188, 20);
            this.txbSite.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Status:";
            // 
            // gbEndereco
            // 
            this.gbEndereco.Controls.Add(this.btnRemoveEnd);
            this.gbEndereco.Controls.Add(this.btnNovoEnd);
            this.gbEndereco.Controls.Add(this.dgvEndereco);
            this.gbEndereco.Controls.Add(this.label9);
            this.gbEndereco.Enabled = false;
            this.gbEndereco.Location = new System.Drawing.Point(11, 153);
            this.gbEndereco.Name = "gbEndereco";
            this.gbEndereco.Size = new System.Drawing.Size(477, 130);
            this.gbEndereco.TabIndex = 4;
            this.gbEndereco.TabStop = false;
            // 
            // btnRemoveEnd
            // 
            this.btnRemoveEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEnd.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRemoveEnd.FlatAppearance.BorderSize = 0;
            this.btnRemoveEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveEnd.Location = new System.Drawing.Point(6, 103);
            this.btnRemoveEnd.Name = "btnRemoveEnd";
            this.btnRemoveEnd.Size = new System.Drawing.Size(103, 21);
            this.btnRemoveEnd.TabIndex = 20;
            this.btnRemoveEnd.Tag = "1.1";
            this.btnRemoveEnd.Text = "Remover";
            this.btnRemoveEnd.UseVisualStyleBackColor = false;
            this.btnRemoveEnd.Click += new System.EventHandler(this.btnRemoveEnd_Click);
            // 
            // btnNovoEnd
            // 
            this.btnNovoEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoEnd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNovoEnd.FlatAppearance.BorderSize = 0;
            this.btnNovoEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoEnd.Location = new System.Drawing.Point(368, 103);
            this.btnNovoEnd.Name = "btnNovoEnd";
            this.btnNovoEnd.Size = new System.Drawing.Size(103, 21);
            this.btnNovoEnd.TabIndex = 20;
            this.btnNovoEnd.Tag = "1.1";
            this.btnNovoEnd.Text = "Novo Endereço";
            this.btnNovoEnd.UseVisualStyleBackColor = false;
            this.btnNovoEnd.Click += new System.EventHandler(this.btnNovoEnd_Click);
            // 
            // dgvEndereco
            // 
            this.dgvEndereco.AllowUserToAddRows = false;
            this.dgvEndereco.AllowUserToDeleteRows = false;
            this.dgvEndereco.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEndereco.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvEndereco.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEndereco.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvEndereco.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvEndereco.Location = new System.Drawing.Point(6, 16);
            this.dgvEndereco.Name = "dgvEndereco";
            this.dgvEndereco.ReadOnly = true;
            this.dgvEndereco.RowHeadersVisible = false;
            this.dgvEndereco.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvEndereco.Size = new System.Drawing.Size(465, 81);
            this.dgvEndereco.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Endereços";
            // 
            // gbContato
            // 
            this.gbContato.Controls.Add(this.btnRemoveCont);
            this.gbContato.Controls.Add(this.btnNovoCont);
            this.gbContato.Controls.Add(this.dgvContato);
            this.gbContato.Controls.Add(this.label10);
            this.gbContato.Enabled = false;
            this.gbContato.Location = new System.Drawing.Point(11, 289);
            this.gbContato.Name = "gbContato";
            this.gbContato.Size = new System.Drawing.Size(477, 130);
            this.gbContato.TabIndex = 4;
            this.gbContato.TabStop = false;
            // 
            // btnRemoveCont
            // 
            this.btnRemoveCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCont.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRemoveCont.FlatAppearance.BorderSize = 0;
            this.btnRemoveCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCont.Location = new System.Drawing.Point(6, 103);
            this.btnRemoveCont.Name = "btnRemoveCont";
            this.btnRemoveCont.Size = new System.Drawing.Size(103, 21);
            this.btnRemoveCont.TabIndex = 20;
            this.btnRemoveCont.Tag = "1.1";
            this.btnRemoveCont.Text = "Remover";
            this.btnRemoveCont.UseVisualStyleBackColor = false;
            // 
            // btnNovoCont
            // 
            this.btnNovoCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoCont.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNovoCont.FlatAppearance.BorderSize = 0;
            this.btnNovoCont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoCont.Location = new System.Drawing.Point(368, 103);
            this.btnNovoCont.Name = "btnNovoCont";
            this.btnNovoCont.Size = new System.Drawing.Size(103, 21);
            this.btnNovoCont.TabIndex = 19;
            this.btnNovoCont.Tag = "1.1";
            this.btnNovoCont.Text = "Novo Contato";
            this.btnNovoCont.UseVisualStyleBackColor = false;
            // 
            // dgvContato
            // 
            this.dgvContato.AllowUserToAddRows = false;
            this.dgvContato.AllowUserToDeleteRows = false;
            this.dgvContato.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvContato.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvContato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContato.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvContato.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvContato.Location = new System.Drawing.Point(6, 16);
            this.dgvContato.Name = "dgvContato";
            this.dgvContato.ReadOnly = true;
            this.dgvContato.RowHeadersVisible = false;
            this.dgvContato.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvContato.Size = new System.Drawing.Size(465, 81);
            this.dgvContato.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Contatos";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(11, 434);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.PaleGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(383, 434);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 27);
            this.btnSave.TabIndex = 6;
            this.btnSave.Tag = "1.1";
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ClienteAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 473);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbContato);
            this.Controls.Add(this.gbEndereco);
            this.Controls.Add(this.txbSite);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.txbNomeFantasia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txbRazaoSocial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mtxbIe);
            this.Controls.Add(this.mtxbCnpj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ClienteAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Cliente";
            this.Load += new System.EventHandler(this.ClienteAddForm_Load);
            this.gbEndereco.ResumeLayout(false);
            this.gbEndereco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndereco)).EndInit();
            this.gbContato.ResumeLayout(false);
            this.gbContato.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContato)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbId;
        private System.Windows.Forms.MaskedTextBox mtxbCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbRazaoSocial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbNomeFantasia;
        private System.Windows.Forms.MaskedTextBox mtxbIe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbSite;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbEndereco;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbContato;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvEndereco;
        private System.Windows.Forms.DataGridView dgvContato;
        private System.Windows.Forms.Button btnRemoveEnd;
        private System.Windows.Forms.Button btnNovoEnd;
        private System.Windows.Forms.Button btnRemoveCont;
        private System.Windows.Forms.Button btnNovoCont;
    }
}