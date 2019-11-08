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
    public partial class FrmEditarContato : Form
    {
        Contato contatoClientexml = new Contato();
        Contato contatoFuncionarioxml = new Contato();
        Contato contatoEdit;
        string perfil;

        public FrmEditarContato(int id, string idPessoa, string cep, string endereco, string bairro, int numero, string cidade, string uf, string email, string telefone) //Editar Cliente
        {
            try
            {
                InitializeComponent();
                contatoClientexml.Carregar();
                txtCEP.Text = cep;
                txtEndereco.Text = endereco;
                txtBairro.Text = bairro;
                txtNumero.Text = numero.ToString();
                txtCidade.Text = cidade;
                txtUF.Text = uf;
                txtEmail.Text = email.ToString();
                txtTelefone.Text = telefone.ToString();
                contatoEdit = contatoClientexml.BuscaContatoEditar(id, idPessoa);
                perfil = CLRegras.Constantes.cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public FrmEditarContato(string endereco, int numero) //Editar Funcionario
        {
            try
            {
                InitializeComponent();
                contatoFuncionarioxml.Carregar();
                perfil = CLRegras.Constantes.funcionario;
                contatoEdit = contatoFuncionarioxml.BuscarFuncionario(endereco, numero);
                txtCEP.Text = contatoEdit.cep;
                txtEndereco.Text = contatoEdit.endereco;
                txtBairro.Text = contatoEdit.bairro;
                txtNumero.Text = contatoEdit.numero.ToString();
                txtCidade.Text = contatoEdit.cidade;
                txtUF.Text = contatoEdit.uf;
                txtEmail.Text = contatoEdit.email.ToString();
                txtTelefone.Text = contatoEdit.telefone.ToString();
                
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
                if (perfil.Equals(CLRegras.Constantes.cliente)) //Salva cliente
                {
                    Leitura();
                    contatoClientexml.Salvar();
                    MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else // Salva funcionário
                {
                    Leitura();
                    contatoFuncionarioxml.Salvar();
                    MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Método para ler as textbox
        /// </summary>
        private void Leitura()
        {
            string cep = txtCEP.Text;
            string endereco = txtEndereco.Text;
            string cidade = txtCidade.Text;
            string bairro = txtBairro.Text;
            int numero = int.Parse(txtNumero.Text);
            string uf = txtUF.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text;
            contatoEdit.cep = cep;
            contatoEdit.endereco = endereco;
            contatoEdit.cidade = cidade;
            contatoEdit.bairro = bairro;
            contatoEdit.numero = numero;
            contatoEdit.uf = uf;
            contatoEdit.email = email;
            contatoEdit.telefone = telefone;
        }
    }
}
