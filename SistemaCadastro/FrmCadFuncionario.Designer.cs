namespace SistemaCadastro
{
    partial class FrmCadFuncionario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadFuncionario));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbAreaDeAtuacao = new System.Windows.Forms.ComboBox();
            this.cbgrauDeEscolaridade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFormacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnAdicionarContato = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvContatos = new System.Windows.Forms.DataGridView();
            this.clnEndereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailcolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefonecolu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBxGrupoSanguineo = new System.Windows.Forms.ComboBox();
            this.cBxSexo = new System.Windows.Forms.ComboBox();
            this.txtDataNasc = new System.Windows.Forms.MaskedTextBox();
            this.txtRg = new System.Windows.Forms.MaskedTextBox();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDataNasc = new System.Windows.Forms.Label();
            this.lblRG = new System.Windows.Forms.Label();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.cbAreaDeAtuacao);
            this.groupBox3.Controls.Add(this.cbgrauDeEscolaridade);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtFormacao);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(14, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 98);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Formação";
            // 
            // cbAreaDeAtuacao
            // 
            this.cbAreaDeAtuacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAreaDeAtuacao.FormattingEnabled = true;
            this.cbAreaDeAtuacao.Location = new System.Drawing.Point(101, 63);
            this.cbAreaDeAtuacao.Name = "cbAreaDeAtuacao";
            this.cbAreaDeAtuacao.Size = new System.Drawing.Size(213, 21);
            this.cbAreaDeAtuacao.TabIndex = 11;
            // 
            // cbgrauDeEscolaridade
            // 
            this.cbgrauDeEscolaridade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbgrauDeEscolaridade.FormattingEnabled = true;
            this.cbgrauDeEscolaridade.Items.AddRange(new object[] {
            "Analfabeto",
            "Ensino fundamental incompleto",
            "Ensino fundamental completo",
            "Ensino médio incompleto",
            "Ensino médio completo",
            "Superior completo (ou graduação)",
            "Pós-graduação",
            "Mestrado",
            "Doutorado",
            "Pós-Doutorado"});
            this.cbgrauDeEscolaridade.Location = new System.Drawing.Point(451, 22);
            this.cbgrauDeEscolaridade.Name = "cbgrauDeEscolaridade";
            this.cbgrauDeEscolaridade.Size = new System.Drawing.Size(202, 21);
            this.cbgrauDeEscolaridade.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Grau de Escolaridade:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Área de Atuação:";
            // 
            // txtFormacao
            // 
            this.txtFormacao.Location = new System.Drawing.Point(101, 22);
            this.txtFormacao.Name = "txtFormacao";
            this.txtFormacao.Size = new System.Drawing.Size(213, 20);
            this.txtFormacao.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Formação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(579, 75);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(111, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(465, 456);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 14;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(546, 456);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 16;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(627, 456);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(14, 455);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 12;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnAdicionarContato
            // 
            this.btnAdicionarContato.Location = new System.Drawing.Point(607, 238);
            this.btnAdicionarContato.Name = "btnAdicionarContato";
            this.btnAdicionarContato.Size = new System.Drawing.Size(103, 31);
            this.btnAdicionarContato.TabIndex = 18;
            this.btnAdicionarContato.Text = "Adicionar Contato";
            this.btnAdicionarContato.UseVisualStyleBackColor = true;
            this.btnAdicionarContato.Click += new System.EventHandler(this.btnAdicionarContato_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvContatos);
            this.groupBox2.Location = new System.Drawing.Point(14, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 184);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contatos";
            // 
            // dgvContatos
            // 
            this.dgvContatos.AllowUserToAddRows = false;
            this.dgvContatos.AllowUserToDeleteRows = false;
            this.dgvContatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvContatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnEndereco,
            this.clnNumero,
            this.clnBairro,
            this.clnCidade,
            this.clnUf,
            this.clnCep,
            this.emailcolu,
            this.Telefonecolu});
            this.dgvContatos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvContatos.Location = new System.Drawing.Point(6, 19);
            this.dgvContatos.MultiSelect = false;
            this.dgvContatos.Name = "dgvContatos";
            this.dgvContatos.ReadOnly = true;
            this.dgvContatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContatos.Size = new System.Drawing.Size(684, 159);
            this.dgvContatos.TabIndex = 0;
            // 
            // clnEndereco
            // 
            this.clnEndereco.HeaderText = "Endereço";
            this.clnEndereco.Name = "clnEndereco";
            this.clnEndereco.ReadOnly = true;
            this.clnEndereco.Width = 78;
            // 
            // clnNumero
            // 
            this.clnNumero.HeaderText = "Número";
            this.clnNumero.Name = "clnNumero";
            this.clnNumero.ReadOnly = true;
            this.clnNumero.Width = 69;
            // 
            // clnBairro
            // 
            this.clnBairro.HeaderText = "Bairro";
            this.clnBairro.Name = "clnBairro";
            this.clnBairro.ReadOnly = true;
            this.clnBairro.Width = 59;
            // 
            // clnCidade
            // 
            this.clnCidade.HeaderText = "Cidade";
            this.clnCidade.Name = "clnCidade";
            this.clnCidade.ReadOnly = true;
            this.clnCidade.Width = 65;
            // 
            // clnUf
            // 
            this.clnUf.HeaderText = "UF";
            this.clnUf.Name = "clnUf";
            this.clnUf.ReadOnly = true;
            this.clnUf.Width = 46;
            // 
            // clnCep
            // 
            this.clnCep.HeaderText = "CEP";
            this.clnCep.Name = "clnCep";
            this.clnCep.ReadOnly = true;
            this.clnCep.Width = 53;
            // 
            // emailcolu
            // 
            this.emailcolu.HeaderText = "E-mail";
            this.emailcolu.Name = "emailcolu";
            this.emailcolu.ReadOnly = true;
            this.emailcolu.Width = 60;
            // 
            // Telefonecolu
            // 
            this.Telefonecolu.HeaderText = "Telefone";
            this.Telefonecolu.Name = "Telefonecolu";
            this.Telefonecolu.ReadOnly = true;
            this.Telefonecolu.Width = 74;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBxGrupoSanguineo);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.cBxSexo);
            this.groupBox1.Controls.Add(this.txtDataNasc);
            this.groupBox1.Controls.Add(this.txtRg);
            this.groupBox1.Controls.Add(this.txtCPF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblDataNasc);
            this.groupBox1.Controls.Add(this.lblRG);
            this.groupBox1.Controls.Add(this.lblSexo);
            this.groupBox1.Controls.Add(this.lblCPF);
            this.groupBox1.Controls.Add(this.txtNome);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 113);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Funcionário";
            // 
            // cBxGrupoSanguineo
            // 
            this.cBxGrupoSanguineo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBxGrupoSanguineo.FormattingEnabled = true;
            this.cBxGrupoSanguineo.Items.AddRange(new object[] {
            "A+",
            "A-",
            "B+",
            "B-",
            "AB+",
            "AB-",
            "O+",
            "O-"});
            this.cBxGrupoSanguineo.Location = new System.Drawing.Point(438, 74);
            this.cBxGrupoSanguineo.Name = "cBxGrupoSanguineo";
            this.cBxGrupoSanguineo.Size = new System.Drawing.Size(78, 21);
            this.cBxGrupoSanguineo.TabIndex = 5;
            // 
            // cBxSexo
            // 
            this.cBxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBxSexo.FormattingEnabled = true;
            this.cBxSexo.Items.AddRange(new object[] {
            "M",
            "F"});
            this.cBxSexo.Location = new System.Drawing.Point(247, 73);
            this.cBxSexo.Name = "cBxSexo";
            this.cBxSexo.Size = new System.Drawing.Size(78, 21);
            this.cBxSexo.TabIndex = 4;
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.Location = new System.Drawing.Point(119, 74);
            this.txtDataNasc.Mask = "00/00/0000";
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(80, 20);
            this.txtDataNasc.TabIndex = 3;
            this.txtDataNasc.ValidatingType = typeof(System.DateTime);
            // 
            // txtRg
            // 
            this.txtRg.Location = new System.Drawing.Point(579, 19);
            this.txtRg.Mask = "00000000";
            this.txtRg.Name = "txtRg";
            this.txtRg.Size = new System.Drawing.Size(109, 20);
            this.txtRg.TabIndex = 2;
            this.txtRg.Leave += new System.EventHandler(this.txtRg_Leave);
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(45, 19);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(100, 20);
            this.txtCPF.TabIndex = 0;
            this.txtCPF.Leave += new System.EventHandler(this.txtCPF_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Grupo Sanguíneo:";
            // 
            // lblDataNasc
            // 
            this.lblDataNasc.AutoSize = true;
            this.lblDataNasc.Location = new System.Drawing.Point(9, 77);
            this.lblDataNasc.Name = "lblDataNasc";
            this.lblDataNasc.Size = new System.Drawing.Size(107, 13);
            this.lblDataNasc.TabIndex = 5;
            this.lblDataNasc.Text = "Data de Nascimento:";
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Location = new System.Drawing.Point(547, 22);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(26, 13);
            this.lblRG.TabIndex = 4;
            this.lblRG.Text = "RG:";
            // 
            // lblSexo
            // 
            this.lblSexo.AutoSize = true;
            this.lblSexo.Location = new System.Drawing.Point(207, 77);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(34, 13);
            this.lblSexo.TabIndex = 3;
            this.lblSexo.Text = "Sexo:";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(9, 22);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 2;
            this.lblCPF.Text = "CPF:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(217, 19);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(298, 20);
            this.txtNome.TabIndex = 1;
            this.txtNome.Validating += new System.ComponentModel.CancelEventHandler(this.txtNome_Validating);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(173, 22);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 0;
            this.lblNome.Text = "Nome:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Secretária",
            "Analista de Sistemas",
            "Desenvolvedor",
            "Estagiário",
            "Gerente de Projetos"});
            this.comboBox1.Location = new System.Drawing.Point(450, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(203, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Função";
            // 
            // FrmCadastroFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionarContato);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCadastroFuncionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Funcionário";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAdicionarContato;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvContatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEndereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUf;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCep;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailcolu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefonecolu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBxGrupoSanguineo;
        private System.Windows.Forms.ComboBox cBxSexo;
        private System.Windows.Forms.MaskedTextBox txtDataNasc;
        private System.Windows.Forms.MaskedTextBox txtRg;
        private System.Windows.Forms.MaskedTextBox txtCPF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDataNasc;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtFormacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbgrauDeEscolaridade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbAreaDeAtuacao;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}