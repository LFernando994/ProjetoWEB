using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CLRegras;

namespace SistemaCadastro
{
    public partial class FrmEditarCliente : Form
    {
        Cliente daoCliente = new Cliente();
        int id;
        Cliente clienteEdit;

        public FrmEditarCliente(int id, string nome, string cpf, int rg, DateTime dataDeNascimento, char sexo, string grupoSanguineo, DateTime dataExpiracao)
        {
            try
            {
                daoCliente.Carregar();
                InitializeComponent();
                txtUsuario.Enabled = false;
                txtRg.Enabled = false;
                txtCPF.Enabled = false;
                this.id = id;
                txtNome.Text = nome;
                txtCPF.Text = cpf;
                txtRg.Text = rg.ToString();
                txtDataNasc.Text = dataDeNascimento.ToString();
                cBxSexo.Text = sexo.ToString();
                cBxGrupoSanguineo.Text = grupoSanguineo.ToString();
                dtpDataDeExpiração.Text = dataExpiracao.ToString();
                txtUsuario.Text = rg.ToString();

                clienteEdit = daoCliente.BuscarClientePorID(id);
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
                string nome = txtNome.Text;
                string cpf = txtCPF.Text;
                int rg = Convert.ToInt32(txtRg.Text);
                DateTime dataDeNasc = Convert.ToDateTime(txtDataNasc.Text);
                string sexo = cBxSexo.Text;
                string grupoSanguineo = cBxGrupoSanguineo.Text;
                string usuario = txtUsuario.Text;
                DateTime dataExpiracao = Convert.ToDateTime(dtpDataDeExpiração.Text);

                clienteEdit.nome = nome;
                //clienteEdit.cpf = cpf;
                //clienteEdit.rg = rg;
                clienteEdit.dataDeNascimento = dataDeNasc;
                clienteEdit.sexo = sexo;
                clienteEdit.grupoSanguineo = grupoSanguineo;
                clienteEdit.dataDeExpiracao = dataExpiracao;
                daoCliente.Salvar();
                MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
      
        }
    }
}
