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
    public partial class FrmAlterarSenha : Form
    {
        AcessosUsuario consultaAcesso = new AcessosUsuario();
        Cliente clienteLogado;
        Funcionario funcionarioLogado;
        UsuariosSistema secretariaLogado;

        public FrmAlterarSenha() //Administrador
        {
            try
            {
                InitializeComponent();
                txtConfirSenha.Enabled = false;
                txtNovaSenha.Enabled = false;
                txtSenhaAtual.Enabled = false;
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }
        public FrmAlterarSenha(Funcionario funcionario) //Funcionario
        {
            try
            {
                InitializeComponent();
                funcionarioLogado = funcionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public FrmAlterarSenha(UsuariosSistema secretaria) //Secretaria 
        {
            try
            {
                InitializeComponent();
                secretariaLogado = secretaria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FrmAlterarSenha(Cliente cliente) //Cliente
        {
            try
            {
                InitializeComponent();
                clienteLogado = cliente;
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
                consultaAcesso.Carregar();

                if (funcionarioLogado != null) // Alterar senha do funcionario logado
                {
                    var usuarioEdit = consultaAcesso.Buscar(funcionarioLogado.rg.ToString()); //Busca o usuario
                    string senhaCript = CLRegras.Criptografia.CriarSenha(txtSenhaAtual.Text); //Converte a senha digitada para criptografada
                    AlterarSenha(usuarioEdit, senhaCript);

                }
                else if (secretariaLogado != null) // Alterar senha do secretaria logado
                {
                    var usuarioEdit = consultaAcesso.Buscar(secretariaLogado.rg.ToString()); //Busca o usuario
                    string senhaCript = CLRegras.Criptografia.CriarSenha(txtSenhaAtual.Text); //Converte a senha digitada para criptografada
                    AlterarSenha(usuarioEdit, senhaCript);
                }
                else if (clienteLogado != null) // Alterar senha do cliente logado
                {
                    var usuarioEdit = consultaAcesso.Buscar(clienteLogado.rg.ToString()); //Busca o usuario
                    string senhaCript = CLRegras.Criptografia.CriarSenha(txtSenhaAtual.Text); //Converte a senha digitada para criptografada
                    AlterarSenha(usuarioEdit, senhaCript);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }

        /// <summary>
        /// Método para alterar senha
        /// </summary>
        /// <param name="pessoa"></param>
        /// <param name="senhaCriptografada"></param>
        private void AlterarSenha(AcessosUsuario pessoa, string senhaCriptografada)
        {
            try
            {
                if (senhaCriptografada.Equals(pessoa.senha)) //Verifica se é igual
                {
                    if (txtNovaSenha.Text.Equals(txtConfirSenha.Text)) //Confere se os dois campos estão com a mesma senha(confirmação)
                    {
                        string senhaNova = CLRegras.Criptografia.CriarSenha(txtNovaSenha.Text);
                        pessoa.senha = senhaNova;
                        consultaAcesso.Salvar();
                        MessageBox.Show(CLRegras.Constantes.senhaAlterada, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else MessageBox.Show(CLRegras.Constantes.senhaDiferentes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show(CLRegras.Constantes.senhaAtualDif, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
    }
}
