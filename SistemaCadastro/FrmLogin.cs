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
    public partial class FrmLogin : Form
    {
        AcessosUsuario daoAcesso = new AcessosUsuario();
        Cliente acessoCliente = new Cliente();
        Funcionario acessoFuncionario = new Funcionario();
            
        private static string senhaSuporte = "admin";

        public FrmLogin()
        {
            try
            {
                InitializeComponent();
                daoAcesso.Carregar();
                acessoCliente.Carregar();
                acessoFuncionario.Carregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void brnRegistrar_Click(object sender, EventArgs e)
        {
            FrmCadUsuarioSistema frm = new FrmCadUsuarioSistema();
            frm.ShowDialog();           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                daoAcesso.Carregar();
                acessoCliente.Carregar();
                string login = txtLoginTela.Text;
                string senha = txtSenhaTela.Text;

                if (login.Equals(CLRegras.Constantes.loginSuporte) && senha.Equals(senhaSuporte)) //Suporte(Administradores)
                {
                    MessageBox.Show(CLRegras.Constantes.bemVindo,CLRegras.Constantes.tipoLogin, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMenu frm = new FrmMenu(CLRegras.Constantes.tipoLogin);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                
                string senhaCriptografada = CLRegras.Criptografia.CriarSenha(senha);
                string perfil = daoAcesso.BuscarPerfil(login);

                if (perfil.Equals(CLRegras.Constantes.usuario)) //Secretária
                {
                    daoAcesso.Carregar();
                    AcessosUsuario userLogado = daoAcesso.Buscar(login);

                    if (daoAcesso.ValidarLogin(login) && daoAcesso.ValidarSenha(senhaCriptografada).Equals(true)) //VALIDA usuários 
                    {
                        MessageBox.Show(CLRegras.Constantes.bemVindo, CLRegras.Constantes.usuario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmMenu frm = new FrmMenu(userLogado.login);
                        this.Hide();
                        frm.solicitaçãoToolStripMenuItem.Visible = false;        // Menus que os usuários não pode visualizar
                        frm.secretariaToolStripMenuItem.Visible = false;
                        frm.gerenciarToolStripMenuItem.Visible = false;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show(CLRegras.Constantes.verica, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (perfil.Equals(CLRegras.Constantes.cliente)) //Cliente
                {
                    var item = daoAcesso.Buscar(login); //Cliente ja cadastro com login e senha, para ter acesso verifica a da de expiranção do login
                    int usuario = Convert.ToInt32(txtLoginTela.Text);
                    var item2 = acessoCliente.BuscarClientePorUsuario(usuario);
                    if (daoAcesso.ValidarLogin(login) && daoAcesso.ValidarSenha(senhaCriptografada) && acessoCliente.ValidarExpiracao(item2.dataDeExpiracao).Equals(true)) //VALIDA CLIENTE
                    {
                        MessageBox.Show(CLRegras.Constantes.bemVindo, CLRegras.Constantes.cliente, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmMenu frm = new FrmMenu(item2);
                        this.Hide();
                        frm.cadastroToolStripMenuItem1.Visible = false;     // Menus que cliente não pode visualizar
                        frm.chamadosAbertosToolStripMenuItem.Visible = false;
                        frm.buscaToolStripMenuItem.Visible = false;
                        frm.secretariaToolStripMenuItem.Visible = false;
                        frm.gerenciarToolStripMenuItem.Visible = false;
                        frm.funcionárioToolStripMenuItem.Visible = false;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show(CLRegras.Constantes.verica+" ou " + CLRegras.Constantes.usuario, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else if (perfil.Equals(CLRegras.Constantes.funcionario))  //Funcionário
                {
                    acessoFuncionario.Carregar();
                    var item = acessoFuncionario.BuscarFuncionarioPorUsuario(Convert.ToInt32(login));
                    if (daoAcesso.ValidarLogin(login) && daoAcesso.ValidarSenha(senhaCriptografada).Equals(true)) //VALIDA FUNCIONÁRIO 
                    {
                        MessageBox.Show(CLRegras.Constantes.bemVindo, CLRegras.Constantes.funcionario, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FrmMenu frm = new FrmMenu(item);
                        this.Hide();
                        frm.buscaToolStripMenuItem.Visible = false;              // Menus que funcionario não pode visualizar
                        frm.acompanhamentoToolStripMenuItem.Visible = false;
                        frm.abrirChamadoToolStripMenuItem.Visible = false;
                        frm.cadastroToolStripMenuItem1.Visible = false;
                        frm.secretariaToolStripMenuItem.Visible = false;
                        frm.gerenciarToolStripMenuItem.Visible = false;
                        frm.ShowDialog();
                        this.Close();
                    }
                    else MessageBox.Show(CLRegras.Constantes.verica, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                 
                }
                else MessageBox.Show(CLRegras.Constantes.verica, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception)
            {
                //throw ex;
                MessageBox.Show(CLRegras.Constantes.msgLogin, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        /// <summary>
        /// Primeiro acesso do cliente para criação de senha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoginTela_Leave(object sender, EventArgs e)
        {
            string login = txtLoginTela.Text;
            daoAcesso.Carregar();
            if (daoAcesso.VerificarSituacao(login).Equals(false))  //Se for a primeira vez que o cliente for entrar, abre uma tela para criar senha
            {
                AcessosUsuario item = daoAcesso.Buscar(login);
                if (item != null)
                {              
                    int usuario = Convert.ToInt32(txtLoginTela.Text);
                    Cliente cliente = acessoCliente.BuscarClientePorUsuario(usuario);
                    FrmPrimeiroAcesso primeiroAcesso = new FrmPrimeiroAcesso(cliente.nome, login);                   
                    primeiroAcesso.ShowDialog();
                    this.Close();
                    
                }
            }
        }

        private void txtEsqueciMinhaSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmEsqueciMinhaSenha frm = new FrmEsqueciMinhaSenha();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }
    }
}
