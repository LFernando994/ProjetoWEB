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
    public partial class FrmPrimeiroAcesso : Form
    {
        AcessosUsuario daoAcesso = new AcessosUsuario();
        Cliente consulta = new Cliente();
        AcessosUsuario acessoEdit;
        Cliente clienteConsulta;

        public FrmPrimeiroAcesso(string nome, string usuario)
        {
            try
            {
                InitializeComponent();
                daoAcesso.Carregar();
                lblNome.Text = nome;
                acessoEdit = daoAcesso.Buscar(usuario);
                consulta.Carregar();
                clienteConsulta = consulta.BuscarClientePorUsuario(Convert.ToInt32(usuario));
            }
            catch (Exception ex)
            {

                throw ex;
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSenha.Text.Equals(txtConfirSenha.Text))
                {
                    string senhaCriptografada = CLRegras.Criptografia.CriarSenha(txtSenha.Text);
                    acessoEdit.senha = senhaCriptografada;
                    daoAcesso.Salvar();
                    MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    FrmMenu frm = new FrmMenu(clienteConsulta);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else MessageBox.Show(CLRegras.Constantes.senhaDiferentes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
