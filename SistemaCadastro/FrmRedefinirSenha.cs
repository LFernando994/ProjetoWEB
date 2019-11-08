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
    public partial class FrmRedefinirSenha : Form
    {
        AcessosUsuario consultaAcesso = new AcessosUsuario();
        AcessosUsuario usuarioEdit;

        public FrmRedefinirSenha()
        {
            try
            {
                InitializeComponent();
                consultaAcesso.Carregar();
                txtConfirSenha.Enabled = false;
                txtSenha.Enabled = false;
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioEdit = consultaAcesso.Buscar(txtUsuario.Text);
                if (usuarioEdit != null)
                {
                    MessageBox.Show(usuarioEdit.perfil + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConfirSenha.Enabled = true;
                    txtSenha.Enabled = true;
                    btnSalvar.Enabled = true;
                    txtUsuario.Enabled = false;
                    btnBuscar.Enabled = false;
                }
                else MessageBox.Show(CLRegras.Constantes.verica, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    string senhaNova = CLRegras.Criptografia.CriarSenha(txtSenha.Text);
                    usuarioEdit.senha = senhaNova;
                    consultaAcesso.Salvar();
                    MessageBox.Show(CLRegras.Constantes.senhaAlterada, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show(CLRegras.Constantes.senhaDiferentes, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
