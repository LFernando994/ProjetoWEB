namespace SistemaCadastro
{
    partial class FrmAcompanhamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAcompanhamento));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.idcolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeSoliColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funcicolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datacolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(700, 433);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acompanhamento Chamado";
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcolu,
            this.nomeSoliColu,
            this.Funcicolu,
            this.areaColu,
            this.Datacolu});
            this.dgvListar.Location = new System.Drawing.Point(6, 19);
            this.dgvListar.MultiSelect = false;
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListar.Size = new System.Drawing.Size(688, 408);
            this.dgvListar.TabIndex = 0;
            // 
            // idcolu
            // 
            this.idcolu.HeaderText = "Prioridade";
            this.idcolu.Name = "idcolu";
            this.idcolu.ReadOnly = true;
            this.idcolu.Width = 79;
            // 
            // nomeSoliColu
            // 
            this.nomeSoliColu.HeaderText = "Nome do Solicitante";
            this.nomeSoliColu.Name = "nomeSoliColu";
            this.nomeSoliColu.ReadOnly = true;
            this.nomeSoliColu.Width = 116;
            // 
            // Funcicolu
            // 
            this.Funcicolu.HeaderText = "Funcionário Responsável";
            this.Funcicolu.Name = "Funcicolu";
            this.Funcicolu.ReadOnly = true;
            this.Funcicolu.Width = 139;
            // 
            // areaColu
            // 
            this.areaColu.HeaderText = "Área de Atuação";
            this.areaColu.Name = "areaColu";
            this.areaColu.ReadOnly = true;
            this.areaColu.Width = 103;
            // 
            // Datacolu
            // 
            this.Datacolu.HeaderText = "Data da Solicitação";
            this.Datacolu.Name = "Datacolu";
            this.Datacolu.ReadOnly = true;
            this.Datacolu.Width = 114;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(637, 451);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAcompanhamento
            // 
            this.AcceptButton = this.btnCancelar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 485);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAcompanhamento";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acompanhamento";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeSoliColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funcicolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datacolu;
    }
}