namespace SistemaCadastro
{
    partial class FrmLista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLista));
            this.gbPerfil = new System.Windows.Forms.GroupBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNome = new System.Windows.Forms.Label();
            this.dgvListar = new System.Windows.Forms.DataGridView();
            this.idColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfcolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rgcolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDeNascColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gsColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexoColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuário = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataExpir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormacaoColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grauDeEscolColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDeAtuacaoColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qntChamadosColu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.gbPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).BeginInit();
            this.SuspendLayout();
            // 
            // gbPerfil
            // 
            this.gbPerfil.Controls.Add(this.txtCPF);
            this.gbPerfil.Controls.Add(this.btnBuscar);
            this.gbPerfil.Controls.Add(this.lblNome);
            this.gbPerfil.Controls.Add(this.dgvListar);
            this.gbPerfil.Location = new System.Drawing.Point(12, 12);
            this.gbPerfil.Name = "gbPerfil";
            this.gbPerfil.Size = new System.Drawing.Size(696, 431);
            this.gbPerfil.TabIndex = 1;
            this.gbPerfil.TabStop = false;
            this.gbPerfil.Text = " Clientes";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(60, 37);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 11;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(166, 37);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(64, 20);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(24, 42);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(30, 13);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "CPF:";
            // 
            // dgvListar
            // 
            this.dgvListar.AllowUserToAddRows = false;
            this.dgvListar.AllowUserToDeleteRows = false;
            this.dgvListar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvListar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvListar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColu,
            this.nomeColu,
            this.cpfcolu,
            this.rgcolu,
            this.dataDeNascColu,
            this.gsColu,
            this.sexoColu,
            this.Usuário,
            this.DataExpir,
            this.FormacaoColu,
            this.grauDeEscolColu,
            this.areaDeAtuacaoColu,
            this.qntChamadosColu});
            this.dgvListar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListar.Location = new System.Drawing.Point(6, 89);
            this.dgvListar.MultiSelect = false;
            this.dgvListar.Name = "dgvListar";
            this.dgvListar.ReadOnly = true;
            this.dgvListar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListar.Size = new System.Drawing.Size(684, 325);
            this.dgvListar.TabIndex = 7;
            // 
            // idColu
            // 
            this.idColu.HeaderText = "ID";
            this.idColu.Name = "idColu";
            this.idColu.ReadOnly = true;
            this.idColu.Width = 43;
            // 
            // nomeColu
            // 
            this.nomeColu.HeaderText = "Nome";
            this.nomeColu.Name = "nomeColu";
            this.nomeColu.ReadOnly = true;
            this.nomeColu.Width = 60;
            // 
            // cpfcolu
            // 
            this.cpfcolu.HeaderText = "CPF";
            this.cpfcolu.Name = "cpfcolu";
            this.cpfcolu.ReadOnly = true;
            this.cpfcolu.Width = 52;
            // 
            // rgcolu
            // 
            this.rgcolu.HeaderText = "RG";
            this.rgcolu.Name = "rgcolu";
            this.rgcolu.ReadOnly = true;
            this.rgcolu.Width = 48;
            // 
            // dataDeNascColu
            // 
            this.dataDeNascColu.HeaderText = "Data de Nascimento";
            this.dataDeNascColu.Name = "dataDeNascColu";
            this.dataDeNascColu.ReadOnly = true;
            this.dataDeNascColu.Width = 118;
            // 
            // gsColu
            // 
            this.gsColu.HeaderText = "Grupo Sanguíneo";
            this.gsColu.Name = "gsColu";
            this.gsColu.ReadOnly = true;
            this.gsColu.Width = 107;
            // 
            // sexoColu
            // 
            this.sexoColu.HeaderText = "Sexo";
            this.sexoColu.Name = "sexoColu";
            this.sexoColu.ReadOnly = true;
            this.sexoColu.Width = 56;
            // 
            // Usuário
            // 
            this.Usuário.HeaderText = "Usuário";
            this.Usuário.Name = "Usuário";
            this.Usuário.ReadOnly = true;
            this.Usuário.Width = 68;
            // 
            // DataExpir
            // 
            this.DataExpir.HeaderText = "Data de Expiração";
            this.DataExpir.Name = "DataExpir";
            this.DataExpir.ReadOnly = true;
            this.DataExpir.Width = 110;
            // 
            // FormacaoColu
            // 
            this.FormacaoColu.HeaderText = "Formação";
            this.FormacaoColu.Name = "FormacaoColu";
            this.FormacaoColu.ReadOnly = true;
            this.FormacaoColu.Width = 79;
            // 
            // grauDeEscolColu
            // 
            this.grauDeEscolColu.HeaderText = "Grau de Escolaridade";
            this.grauDeEscolColu.Name = "grauDeEscolColu";
            this.grauDeEscolColu.ReadOnly = true;
            this.grauDeEscolColu.Width = 123;
            // 
            // areaDeAtuacaoColu
            // 
            this.areaDeAtuacaoColu.HeaderText = "Área de Atuação";
            this.areaDeAtuacaoColu.Name = "areaDeAtuacaoColu";
            this.areaDeAtuacaoColu.ReadOnly = true;
            this.areaDeAtuacaoColu.Width = 103;
            // 
            // qntChamadosColu
            // 
            this.qntChamadosColu.HeaderText = "Quantidade de Chamados";
            this.qntChamadosColu.Name = "qntChamadosColu";
            this.qntChamadosColu.ReadOnly = true;
            this.qntChamadosColu.Width = 141;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(637, 459);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(556, 459);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(475, 459);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 10;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(12, 459);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 11;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // FrmLista
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(724, 494);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.gbPerfil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Clientes";
            this.gbPerfil.ResumeLayout(false);
            this.gbPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPerfil;
        private System.Windows.Forms.DataGridView dgvListar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfcolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn rgcolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataDeNascColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn gsColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexoColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuário;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataExpir;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormacaoColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn grauDeEscolColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDeAtuacaoColu;
        private System.Windows.Forms.DataGridViewTextBoxColumn qntChamadosColu;
    }
}