using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLRegras;

namespace SistemaCadastro
{
    public partial class FrmEsqueciMinhaSenha : Form
    {
        AcessosUsuario consultaAcesso = new AcessosUsuario();
        Cliente consultaCliente = new Cliente();
        Contato consultaContato = new Contato();
        AcessosUsuario dadosAcesso;
        string token = string.Empty;

        public FrmEsqueciMinhaSenha()
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }
            InitializeComponent();
            txtToken.Enabled = false;
            txtSenha.Enabled = false;
            txtConfirSenha.Enabled = false;
            btnAlterarSenha.Enabled = false;
            consultaAcesso.Carregar();
            consultaCliente.Carregar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }

            if (consultaAcesso.ValidarLogin(txtUsuario.Text).Equals(true))
            {
                var consultar = consultaCliente.BuscarClientePorUsuario(Convert.ToInt32(txtUsuario.Text)); //Busca CLiente para mandar email
                string id = consultar.id;
                dadosAcesso = consultaAcesso.Buscar(txtUsuario.Text);
                token = GetUniqueKey(); // Gera token para mudança de senha
                EnviarEmailParaValidar(consultaContato.EmailsContato(id), token, consultar.nome);
                txtToken.Enabled = true;
                txtSenha.Enabled = true;
                txtConfirSenha.Enabled = true;
                btnAlterarSenha.Enabled = true;
            }
            else MessageBox.Show("Não "+ CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLogin frm = new FrmLogin();
                this.Hide();
                frm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        private void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSenha.Text.Equals(txtConfirSenha.Text) && token.Equals(txtToken.Text))
                {
                    string senhaCriptografada = CLRegras.Criptografia.CriarSenha(txtSenha.Text);
                    dadosAcesso.senha = senhaCriptografada;
                    consultaAcesso.Salvar();
                    MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show(CLRegras.Constantes.senhaDiferentes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

                throw ex;
            }     
        }

        /// <summary>
        /// Gera um token para enviar para o email cadastrado e validar
        /// </summary>
        /// <returns></returns>
        public static string GetUniqueKey()
        {
            try
            {
                char[] chars =
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
                byte[] data = new byte[6];
                using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
                {
                    crypto.GetBytes(data);
                }
                StringBuilder result = new StringBuilder(5);
                foreach (byte b in data)
                {
                    result.Append(chars[b % (chars.Length)]);
                }
                return result.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Método para enviar email para um destinatario
        /// </summary>
        /// <param name="emailDestinatario"></param>
        /// <param name="token"></param>
        /// <param name="nome"></param>
        public static void EnviarEmailParaValidar(List<string> emailDestinatario, string token, string nome)
        {
            MailMessage msg = new MailMessage();
            foreach (var item in emailDestinatario)
            {
                msg.To.Add(item);
            }
            msg.Subject = CLRegras.Constantes.redefinir;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Body = "Prezado(a) " + nome + ". Redefinição de senha, TOKEN PARA VALIDAR " + token + " . Atenciosamente, dev Luiz Fernando";
            msg.From = new MailAddress(CLRegras.Constantes.emailGmail);
            SmtpClient cliente = new SmtpClient();
            cliente.Credentials = new NetworkCredential(CLRegras.Constantes.emailGmail, "1234lfs!");
            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";
            try
            {
                cliente.Send(msg);
                MessageBox.Show(CLRegras.Constantes.redefinirSenhaEnviada, CLRegras.Constantes.redefinir, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                EnviarEmailSistema(msg.Subject, msg.Body, true, CLRegras.Constantes.emailMeioAmbiente, CLRegras.Constantes.emailMeioAmbiente);
                MessageBox.Show(CLRegras.Constantes.redefinirSenhaEnviada + "(sistema)",CLRegras.Constantes.redefinir, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void EnviarEmailSistema(string assunto, string texto, bool textoEmHtml, string remetente, string destinatarios)
        {
            try
            {
                MailMessage mensagem = new MailMessage();
                mensagem.From = new MailAddress(remetente, string.Empty);
                mensagem.To.Add(destinatarios);
                mensagem.Subject = assunto;
                mensagem.Body = texto;
                mensagem.IsBodyHtml = textoEmHtml;
                mensagem.Priority = MailPriority.High;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Host = "10.47.16.60";
                smtpClient.Port = 25;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Send(mensagem);
            }
            catch (SmtpException ex)
            {
                throw new Exception("Inconformidade ao enviar e-mail!", ex);
            }
        }        
    }
}
