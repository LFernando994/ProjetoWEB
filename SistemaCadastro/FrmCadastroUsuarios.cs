using CLData;
using CLRegras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class FrmCadastroUsuarios : Form
    {
        static int pinDeAcesso = 1010;
        DAOAcesso daoAcessos = new DAOAcesso();
        DAOSecretaria secretariaxml = new DAOSecretaria();
        UsuarioSistema novaSecretaria;
        Usuario acessos;
        int id;
        bool edit; //Olha se é edição ou cadastro de uma secretaria
        UsuarioSistema secretariaEdit;
   

        public FrmCadastroUsuarios() // Construtor para cadastro
        {
            try
            {
                InitializeComponent();
                txtLogin.Enabled = false;
                daoAcessos.Carregar();
                secretariaxml.Carregar();
            }
            catch (Exception ex)
            {

                throw ex;
            }           
        }
        public FrmCadastroUsuarios(bool edicao, int secretariaRG) //Construtor para edição 
        {
            try
            {
                InitializeComponent();
                secretariaxml.Carregar();
                txtConfirSenha.Visible = false;
                lblConfirmarSenha.Visible = false;
                txtSenha.Enabled = false;
                txtLogin.Enabled = false;
                txtPIN.Visible = false;
                lblMsgPIN.Visible = false;
                lblPiN.Visible = false;
                txtSenha.Visible = false;
                lblSenha.Visible = false;
                this.Text = "Editar Secretário(a)";
                edit = edicao;
                secretariaEdit = secretariaxml.BuscarSecretariaPorUsuario(secretariaRG);  // Busca a pessoa para ser editado por meio da rg passado por parametro
                txtNome.Text = secretariaEdit.nome;
                txtCPF.Text = secretariaEdit.cpf;
                txtRg.Text = secretariaEdit.rg.ToString();
                txtLogin.Text = secretariaEdit.rg.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }      
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string cpf = txtCPF.Text;
                cpf = cpf.Replace(',', '.');
                if (edit.Equals(true)) //Edição
                {
                    string nome = txtNome.Text;
                    cpf = txtCPF.Text;
                    int rg = Convert.ToInt32(txtRg.Text);
                    secretariaEdit.nome = nome;          
                    secretariaxml.Salvar();
                    MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else //Cadastro
                {
                    id = secretariaxml.ContadorID();
                    string nome = txtNome.Text;
                    int rg = int.Parse(txtRg.Text);
                    cpf = txtCPF.Text;
                    string login = txtLogin.Text;
                    string senha = txtSenha.Text;
                    string confirmarSenha = txtConfirSenha.Text;
                    int pin = Convert.ToInt16(txtPIN.Text);

                    if (senha.Equals(confirmarSenha))
                    {
                        if (pin.Equals(pinDeAcesso))
                        {
                            string senhaCriptografada = CLRegras.Criptografia.CriarSenha(senha);
                            int idUsuario = daoAcessos.ContadorID();                           
                            novaSecretaria = new Secretaria(id, nome, cpf, rg);
                            acessos = new Usuario(idUsuario, nome, login, senhaCriptografada, CLRegras.Constantes.secretaria);
                            secretariaxml.Adicionar(novaSecretaria);
                            secretariaxml.Salvar();
                            daoAcessos.Adicionar(acessos);
                            daoAcessos.Salvar();
                            MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else MessageBox.Show(CLRegras.Constantes.pinInvalido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else MessageBox.Show(CLRegras.Constantes.senhaDiferentes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        /// <summary>
        /// quando sai do rg ja preenche automatico o usuário, por padrão rg e usuário são iguais
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRg_Leave(object sender, EventArgs e)
        {
            txtLogin.Text = txtRg.Text;
        }

        /// <summary>
        /// Valida nome, não deixa o campo nome ficar vazia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {               
                errorProvider1.SetError(txtNome, CLRegras.Constantes.digiteNome);
            }
            else
            {              
                errorProvider1.SetError(txtCPF, null);
            }
        }
    }
}