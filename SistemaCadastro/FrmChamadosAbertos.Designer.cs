namespace SistemaCadastro
{
    partial class FrmChamadosAbertos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChamadosAbertos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvChamados = new System.Windows.Forms.DataGridView();
            this.idColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nomecolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areadeAtuaColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datacolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnFinalizarChamado = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvChamados);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chamados";
            // 
            // dgvChamados
            // 
            this.dgvChamados.AllowUserToAddRows = false;
            this.dgvChamados.AllowUserToDeleteRows = false;
            this.dgvChamados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvChamados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColu,
            this.Nomecolu,
            this.areadeAtuaColu,
            this.Datacolu});
            this.dgvChamados.Location = new System.Drawing.Point(6, 19);
            this.dgvChamados.MultiSelect = false;
            this.dgvChamados.Name = "dgvChamados";
            this.dgvChamados.ReadOnly = true;
            this.dgvChamados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChamados.Size = new System.Drawing.Size(728, 222);
            this.dgvChamados.TabIndex = 0;
            this.dgvChamados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChamados_CellClick);
            this.dgvChamados.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvChamados_RowHeaderMouseClick);
            // 
            // idColu
            // 
            this.idColu.HeaderText = "ID";
            this.idColu.Name = "idColu";
            this.idColu.ReadOnly = true;
            this.idColu.Width = 43;
            // 
            // Nomecolu
            // 
            this.Nomecolu.HeaderText = "Nome do Solicitante";
            this.Nomecolu.Name = "Nomecolu";
            this.Nomecolu.ReadOnly = true;
            this.Nomecolu.Width = 116;
            // 
            // areadeAtuaColu
            // 
            this.areadeAtuaColu.HeaderText = "Área de Atuação";
            this.areadeAtuaColu.Name = "areadeAtuaColu";
            this.areadeAtuaColu.ReadOnly = true;
            this.areadeAtuaColu.Width = 103;
            // 
            // Datacolu
            // 
            this.Datacolu.HeaderText = "Data da Solicitação";
            this.Datacolu.Name = "Datacolu";
            this.Datacolu.ReadOnly = true;
            this.Datacolu.Width = 114;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescricao);
            this.groupBox2.Location = new System.Drawing.Point(12, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(740, 175);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricao.Location = new System.Drawing.Point(6, 19);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ReadOnly = true;
            this.txtDescricao.Size = new System.Drawing.Size(728, 150);
            this.txtDescricao.TabIndex = 0;
            // 
            // btnFinalizarChamado
            // 
            this.btnFinalizarChamado.Location = new System.Drawing.Point(574, 452);
            this.btnFinalizarChamado.Name = "btnFinalizarChamado";
            this.btnFinalizarChamado.Size = new System.Drawing.Size(97, 36);
            this.btnFinalizarChamado.TabIndex = 2;
            this.btnFinalizarChamado.Text = "Finalizar Chamado";
            this.btnFinalizarChamado.UseVisualStyleBackColor = true;
            this.btnFinalizarChamado.Click += new System.EventHandler(this.btnFinalizarChamado_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 459);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FrmChamadosAbertos
            // 
            this.AcceptButton = this.btnFinalizarChamado;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 494);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnFinalizarChamado);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChamadosAbertos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chamados Abertos";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamados)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvChamados;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFinalizarChamado;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nomecolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn areadeAtuaColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Datacolu;
    }
}