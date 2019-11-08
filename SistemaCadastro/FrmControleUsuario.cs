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
    public partial class FrmControleUsuario : Form
    {
        AcessosUsuario consultaAcesso = new AcessosUsuario();

        public FrmControleUsuario()
        {
            try
            {
                InitializeComponent();               
                PreencherGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }                   
        }
        private void PreencherGrid()
        {
            try
            {              
                dgvControle.Rows.Clear();
                foreach (var x in consultaAcesso.GetListarTodos())
                {
                    dgvControle.Rows.Add(x.id, x.nome, x.login, x.perfil);
                }
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
                string usuario = txtUsuario.Text;
                var x = consultaAcesso.Buscar(usuario);
                if (x != null)
                {
                    dgvControle.Rows.Clear();
                    dgvControle.Rows.Add(x.id, x.nome, x.login, x.perfil);
                }
                else MessageBox.Show("não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvControle.CurrentRow != null)
                {
                    string usuario = dgvControle.CurrentRow.Cells[2].Value.ToString();
                    AcessosUsuario usuarioBuscado = consultaAcesso.Buscar(usuario);
                    consultaAcesso.Remover(usuarioBuscado);
                    MessageBox.Show("Usuário" + CLRegras.Constantes.removido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PreencherGrid();
                }
                else MessageBox.Show(CLRegras.Constantes.verica, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = dgvControle.CurrentRow.Cells[2].Value.ToString();
                FrmAlterarPerfil frm = new FrmAlterarPerfil(usuario);
                frm.ShowDialog();
                PreencherGrid();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
