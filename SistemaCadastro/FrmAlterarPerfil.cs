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
    public partial class FrmAlterarPerfil : Form
    {
        AcessosUsuario consultaAcesso = new AcessosUsuario();
        AcessosUsuario usuarioEdit;
        public FrmAlterarPerfil(string usuario)
        {
            try
            {
                InitializeComponent();
                consultaAcesso.Carregar();
                usuarioEdit = consultaAcesso.Buscar(usuario);
                cbxPerfil.Text = usuarioEdit.perfil;

            }
            catch (Exception ex)
            {
                throw ex;
            }     
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioEdit.perfil = cbxPerfil.Text;
                consultaAcesso.Salvar();
                MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK,MessageBoxIcon.Information);              
                this.Close();
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
