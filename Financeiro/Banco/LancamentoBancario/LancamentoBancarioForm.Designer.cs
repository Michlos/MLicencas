
namespace Financeiro.Banco.LancamentoBancario
{
    partial class LancamentoBancarioForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCommandos = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnChangeConta = new System.Windows.Forms.Button();
            this.btnEstornar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.panelContaBancaria = new System.Windows.Forms.Panel();
            this.dtpDataFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpDataInicial = new System.Windows.Forms.DateTimePicker();
            this.txbSaldo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTotalExtrato = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbConta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbAgencia = new System.Windows.Forms.TextBox();
            this.txbBanco = new System.Windows.Forms.TextBox();
            this.panelLancamentos = new System.Windows.Forms.Panel();
            this.dgvLancamentos = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.novoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estornarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exibirEstornoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCommandos.SuspendLayout();
            this.panelContaBancaria.SuspendLayout();
            this.panelLancamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLancamentos)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommandos
            // 
            this.panelCommandos.Controls.Add(this.btnClose);
            this.panelCommandos.Controls.Add(this.btnChangeConta);
            this.panelCommandos.Controls.Add(this.btnEstornar);
            this.panelCommandos.Controls.Add(this.btnNovo);
            this.panelCommandos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommandos.Location = new System.Drawing.Point(0, 413);
            this.panelCommandos.Name = "panelCommandos";
            this.panelCommandos.Size = new System.Drawing.Size(625, 37);
            this.panelCommandos.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(9, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChangeConta
            // 
            this.btnChangeConta.BackColor = System.Drawing.Color.PaleGreen;
            this.btnChangeConta.FlatAppearance.BorderSize = 0;
            this.btnChangeConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeConta.Location = new System.Drawing.Point(81, 6);
            this.btnChangeConta.Name = "btnChangeConta";
            this.btnChangeConta.Size = new System.Drawing.Size(124, 23);
            this.btnChangeConta.TabIndex = 0;
            this.btnChangeConta.Text = "Outra Conta";
            this.btnChangeConta.UseVisualStyleBackColor = false;
            this.btnChangeConta.Click += new System.EventHandler(this.btnChangeConta_Click);
            // 
            // btnEstornar
            // 
            this.btnEstornar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEstornar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnEstornar.FlatAppearance.BorderSize = 0;
            this.btnEstornar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstornar.Location = new System.Drawing.Point(358, 6);
            this.btnEstornar.Name = "btnEstornar";
            this.btnEstornar.Size = new System.Drawing.Size(124, 23);
            this.btnEstornar.TabIndex = 0;
            this.btnEstornar.Text = "Estornar Lançamento";
            this.btnEstornar.UseVisualStyleBackColor = false;
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(488, 6);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(124, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo Lançamento";
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // panelContaBancaria
            // 
            this.panelContaBancaria.Controls.Add(this.dtpDataFinal);
            this.panelContaBancaria.Controls.Add(this.dtpDataInicial);
            this.panelContaBancaria.Controls.Add(this.txbSaldo);
            this.panelContaBancaria.Controls.Add(this.label4);
            this.panelContaBancaria.Controls.Add(this.txbTotalExtrato);
            this.panelContaBancaria.Controls.Add(this.label7);
            this.panelContaBancaria.Controls.Add(this.txbConta);
            this.panelContaBancaria.Controls.Add(this.label3);
            this.panelContaBancaria.Controls.Add(this.label6);
            this.panelContaBancaria.Controls.Add(this.label2);
            this.panelContaBancaria.Controls.Add(this.label5);
            this.panelContaBancaria.Controls.Add(this.label1);
            this.panelContaBancaria.Controls.Add(this.txbAgencia);
            this.panelContaBancaria.Controls.Add(this.txbBanco);
            this.panelContaBancaria.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContaBancaria.Location = new System.Drawing.Point(0, 0);
            this.panelContaBancaria.Name = "panelContaBancaria";
            this.panelContaBancaria.Size = new System.Drawing.Size(625, 137);
            this.panelContaBancaria.TabIndex = 1;
            // 
            // dtpDataFinal
            // 
            this.dtpDataFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFinal.Location = new System.Drawing.Point(296, 93);
            this.dtpDataFinal.Name = "dtpDataFinal";
            this.dtpDataFinal.Size = new System.Drawing.Size(98, 20);
            this.dtpDataFinal.TabIndex = 2;
            this.dtpDataFinal.ValueChanged += new System.EventHandler(this.dtpDataFinal_ValueChanged);
            // 
            // dtpDataInicial
            // 
            this.dtpDataInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataInicial.Location = new System.Drawing.Point(76, 93);
            this.dtpDataInicial.Name = "dtpDataInicial";
            this.dtpDataInicial.Size = new System.Drawing.Size(98, 20);
            this.dtpDataInicial.TabIndex = 2;
            this.dtpDataInicial.ValueChanged += new System.EventHandler(this.dtpDataInicial_ValueChanged);
            // 
            // txbSaldo
            // 
            this.txbSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSaldo.Location = new System.Drawing.Point(415, 23);
            this.txbSaldo.Name = "txbSaldo";
            this.txbSaldo.ReadOnly = true;
            this.txbSaldo.Size = new System.Drawing.Size(182, 31);
            this.txbSaldo.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Saldo em Conta:";
            // 
            // txbTotalExtrato
            // 
            this.txbTotalExtrato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTotalExtrato.Location = new System.Drawing.Point(485, 93);
            this.txbTotalExtrato.Name = "txbTotalExtrato";
            this.txbTotalExtrato.ReadOnly = true;
            this.txbTotalExtrato.Size = new System.Drawing.Size(112, 20);
            this.txbTotalExtrato.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Total Extrato:";
            // 
            // txbConta
            // 
            this.txbConta.BackColor = System.Drawing.Color.White;
            this.txbConta.Location = new System.Drawing.Point(76, 64);
            this.txbConta.Name = "txbConta";
            this.txbConta.ReadOnly = true;
            this.txbConta.Size = new System.Drawing.Size(127, 20);
            this.txbConta.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Conta:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(237, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Data Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Agência:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Data Inicial:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Banco:";
            // 
            // txbAgencia
            // 
            this.txbAgencia.BackColor = System.Drawing.Color.White;
            this.txbAgencia.Location = new System.Drawing.Point(76, 38);
            this.txbAgencia.Name = "txbAgencia";
            this.txbAgencia.ReadOnly = true;
            this.txbAgencia.Size = new System.Drawing.Size(57, 20);
            this.txbAgencia.TabIndex = 0;
            // 
            // txbBanco
            // 
            this.txbBanco.BackColor = System.Drawing.Color.White;
            this.txbBanco.Location = new System.Drawing.Point(76, 12);
            this.txbBanco.Name = "txbBanco";
            this.txbBanco.ReadOnly = true;
            this.txbBanco.Size = new System.Drawing.Size(227, 20);
            this.txbBanco.TabIndex = 0;
            // 
            // panelLancamentos
            // 
            this.panelLancamentos.Controls.Add(this.dgvLancamentos);
            this.panelLancamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLancamentos.Location = new System.Drawing.Point(0, 137);
            this.panelLancamentos.Name = "panelLancamentos";
            this.panelLancamentos.Size = new System.Drawing.Size(625, 276);
            this.panelLancamentos.TabIndex = 2;
            // 
            // dgvLancamentos
            // 
            this.dgvLancamentos.AllowUserToAddRows = false;
            this.dgvLancamentos.AllowUserToDeleteRows = false;
            this.dgvLancamentos.AllowUserToResizeColumns = false;
            this.dgvLancamentos.AllowUserToResizeRows = false;
            this.dgvLancamentos.BackgroundColor = System.Drawing.Color.White;
            this.dgvLancamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLancamentos.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvLancamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLancamentos.Location = new System.Drawing.Point(0, 0);
            this.dgvLancamentos.Name = "dgvLancamentos";
            this.dgvLancamentos.ReadOnly = true;
            this.dgvLancamentos.RowHeadersVisible = false;
            this.dgvLancamentos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvLancamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLancamentos.Size = new System.Drawing.Size(625, 276);
            this.dgvLancamentos.TabIndex = 0;
            this.dgvLancamentos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLancamentos_CellMouseClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.estornarToolStripMenuItem,
            this.exibirEstornoToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(147, 92);
            // 
            // novoToolStripMenuItem
            // 
            this.novoToolStripMenuItem.Name = "novoToolStripMenuItem";
            this.novoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.novoToolStripMenuItem.Text = "Novo";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // estornarToolStripMenuItem
            // 
            this.estornarToolStripMenuItem.Name = "estornarToolStripMenuItem";
            this.estornarToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.estornarToolStripMenuItem.Text = "Estornar";
            // 
            // exibirEstornoToolStripMenuItem
            // 
            this.exibirEstornoToolStripMenuItem.Name = "exibirEstornoToolStripMenuItem";
            this.exibirEstornoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exibirEstornoToolStripMenuItem.Text = "Exibir Estorno";
            // 
            // LancamentoBancarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 450);
            this.Controls.Add(this.panelLancamentos);
            this.Controls.Add(this.panelContaBancaria);
            this.Controls.Add(this.panelCommandos);
            this.Name = "LancamentoBancarioForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financeiro - Lançamentos Bancários";
            this.panelCommandos.ResumeLayout(false);
            this.panelContaBancaria.ResumeLayout(false);
            this.panelContaBancaria.PerformLayout();
            this.panelLancamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLancamentos)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommandos;
        private System.Windows.Forms.Panel panelContaBancaria;
        private System.Windows.Forms.Panel panelLancamentos;
        private System.Windows.Forms.TextBox txbConta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAgencia;
        private System.Windows.Forms.TextBox txbBanco;
        private System.Windows.Forms.TextBox txbSaldo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvLancamentos;
        private System.Windows.Forms.DateTimePicker dtpDataFinal;
        private System.Windows.Forms.DateTimePicker dtpDataInicial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChangeConta;
        private System.Windows.Forms.Button btnEstornar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem novoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estornarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exibirEstornoToolStripMenuItem;
        private System.Windows.Forms.TextBox txbTotalExtrato;
        private System.Windows.Forms.Label label7;
    }
}