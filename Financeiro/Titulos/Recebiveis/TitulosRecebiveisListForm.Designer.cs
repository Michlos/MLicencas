
namespace Financeiro.Titulos.Recebiveis
{
    partial class TitulosRecebiveisListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCommands = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBoleto = new System.Windows.Forms.Button();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.btnGerarTitulo = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMesFiltro = new System.Windows.Forms.ComboBox();
            this.dgvRecebiveis = new System.Windows.Forms.DataGridView();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelCommands.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecebiveis)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCommands
            // 
            this.panelCommands.Controls.Add(this.btnClose);
            this.panelCommands.Controls.Add(this.btnBoleto);
            this.panelCommands.Controls.Add(this.btnLiquidar);
            this.panelCommands.Controls.Add(this.btnGerarTitulo);
            this.panelCommands.Controls.Add(this.btnNovo);
            this.panelCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCommands.Location = new System.Drawing.Point(0, 415);
            this.panelCommands.Name = "panelCommands";
            this.panelCommands.Size = new System.Drawing.Size(800, 35);
            this.panelCommands.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBoleto
            // 
            this.btnBoleto.BackColor = System.Drawing.Color.PaleGreen;
            this.btnBoleto.FlatAppearance.BorderSize = 0;
            this.btnBoleto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBoleto.Location = new System.Drawing.Point(533, 6);
            this.btnBoleto.Name = "btnBoleto";
            this.btnBoleto.Size = new System.Drawing.Size(81, 23);
            this.btnBoleto.TabIndex = 0;
            this.btnBoleto.Tag = "7.4.1";
            this.btnBoleto.Text = "Gerar Boleto";
            this.btnBoleto.UseVisualStyleBackColor = false;
            this.btnBoleto.Click += new System.EventHandler(this.btnBoleto_Click);
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.BackColor = System.Drawing.Color.PaleGreen;
            this.btnLiquidar.FlatAppearance.BorderSize = 0;
            this.btnLiquidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiquidar.Location = new System.Drawing.Point(445, 6);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(81, 23);
            this.btnLiquidar.TabIndex = 0;
            this.btnLiquidar.Tag = "7.2.3";
            this.btnLiquidar.Text = "Liquidar";
            this.btnLiquidar.UseVisualStyleBackColor = false;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // btnGerarTitulo
            // 
            this.btnGerarTitulo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnGerarTitulo.FlatAppearance.BorderSize = 0;
            this.btnGerarTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerarTitulo.Location = new System.Drawing.Point(621, 6);
            this.btnGerarTitulo.Name = "btnGerarTitulo";
            this.btnGerarTitulo.Size = new System.Drawing.Size(81, 23);
            this.btnGerarTitulo.TabIndex = 0;
            this.btnGerarTitulo.Tag = "7.2.1";
            this.btnGerarTitulo.Text = "Gerar Títulos";
            this.toolTip.SetToolTip(this.btnGerarTitulo, "Gerar títulos através de contratos existentes");
            this.btnGerarTitulo.UseVisualStyleBackColor = false;
            this.btnGerarTitulo.Click += new System.EventHandler(this.btnGerarTitulo_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNovo.FlatAppearance.BorderSize = 0;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Location = new System.Drawing.Point(709, 6);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(81, 23);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Tag = "7.2.1";
            this.btnNovo.Text = "Novo Título";
            this.btnNovo.UseVisualStyleBackColor = false;
            // 
            // panelFiltros
            // 
            this.panelFiltros.Controls.Add(this.label1);
            this.panelFiltros.Controls.Add(this.cbMesFiltro);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(800, 38);
            this.panelFiltros.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mês Vencimento:";
            // 
            // cbMesFiltro
            // 
            this.cbMesFiltro.FormattingEnabled = true;
            this.cbMesFiltro.Location = new System.Drawing.Point(101, 9);
            this.cbMesFiltro.Name = "cbMesFiltro";
            this.cbMesFiltro.Size = new System.Drawing.Size(121, 21);
            this.cbMesFiltro.TabIndex = 0;
            this.cbMesFiltro.SelectedIndexChanged += new System.EventHandler(this.cbMesFiltro_SelectedIndexChanged);
            // 
            // dgvRecebiveis
            // 
            this.dgvRecebiveis.AllowUserToAddRows = false;
            this.dgvRecebiveis.AllowUserToDeleteRows = false;
            this.dgvRecebiveis.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecebiveis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecebiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecebiveis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecebiveis.GridColor = System.Drawing.Color.PaleGreen;
            this.dgvRecebiveis.Location = new System.Drawing.Point(0, 0);
            this.dgvRecebiveis.Name = "dgvRecebiveis";
            this.dgvRecebiveis.ReadOnly = true;
            this.dgvRecebiveis.RowHeadersVisible = false;
            this.dgvRecebiveis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvRecebiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecebiveis.Size = new System.Drawing.Size(800, 377);
            this.dgvRecebiveis.TabIndex = 0;
            // 
            // panelContainer
            // 
            this.panelContainer.Controls.Add(this.dgvRecebiveis);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 38);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 377);
            this.panelContainer.TabIndex = 2;
            // 
            // TitulosRecebiveisListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelCommands);
            this.Name = "TitulosRecebiveisListForm";
            this.Text = "Financeiro - Títulos Recebíveis";
            this.panelCommands.ResumeLayout(false);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecebiveis)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCommands;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnGerarTitulo;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnLiquidar;
        private System.Windows.Forms.Button btnBoleto;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.DataGridView dgvRecebiveis;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMesFiltro;
    }
}