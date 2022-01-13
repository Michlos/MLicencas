
namespace Financeiro.Banco.ContaBancaria
{
    partial class ContaListForm
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
            this.dgvContas = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.adicionarContaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarContaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvContas
            // 
            this.dgvContas.AllowUserToAddRows = false;
            this.dgvContas.AllowUserToDeleteRows = false;
            this.dgvContas.AllowUserToResizeColumns = false;
            this.dgvContas.AllowUserToResizeRows = false;
            this.dgvContas.BackgroundColor = System.Drawing.Color.White;
            this.dgvContas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvContas.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvContas.Location = new System.Drawing.Point(12, 12);
            this.dgvContas.Name = "dgvContas";
            this.dgvContas.RowHeadersVisible = false;
            this.dgvContas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvContas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContas.Size = new System.Drawing.Size(594, 390);
            this.dgvContas.TabIndex = 0;
            this.dgvContas.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvContas_CellMouseClick);
            this.dgvContas.SelectionChanged += new System.EventHandler(this.dgvContas_SelectionChanged);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(503, 411);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(103, 27);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "Adicionar Conta";
            this.btnNew.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(12, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 27);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Fechar";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adicionarContaToolStripMenuItem,
            this.editarContaToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(161, 48);
            // 
            // adicionarContaToolStripMenuItem
            // 
            this.adicionarContaToolStripMenuItem.Name = "adicionarContaToolStripMenuItem";
            this.adicionarContaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.adicionarContaToolStripMenuItem.Text = "Adicionar Conta";
            this.adicionarContaToolStripMenuItem.Click += new System.EventHandler(this.adicionarContaToolStripMenuItem_Click);
            // 
            // editarContaToolStripMenuItem
            // 
            this.editarContaToolStripMenuItem.Name = "editarContaToolStripMenuItem";
            this.editarContaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.editarContaToolStripMenuItem.Text = "Editar Conta";
            this.editarContaToolStripMenuItem.Click += new System.EventHandler(this.editarContaToolStripMenuItem_Click);
            // 
            // ContaListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 450);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvContas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ContaListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ContaListForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContas)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvContas;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem adicionarContaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarContaToolStripMenuItem;
    }
}