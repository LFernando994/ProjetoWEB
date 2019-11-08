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
    public partial class FrmCadContatosFuncion : Form
    {
        Contato contatosNovo;
        Contato contatoxml = new Contato();
        string idFuncionario { get; set; }

        public FrmCadContatosFuncion(string id)
        {
            try
            {
                InitializeComponent();
                contatoxml.CarregarFunc();
                idFuncionario = id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnAdicionarNovoContato_Click(object sender, EventArgs e)
        {
            try
            {
                if (CLRegras.ValidarCampos.ValidarEmail(txtEmail.Text).Equals(true)) //Verifica se o email é valido
                {
                    SalvarNoXML();
                    LimparCampos();
                }
                else MessageBox.Show(CLRegras.Constantes.emailInvalido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (CLRegras.ValidarCampos.ValidarEmail(txtEmail.Text).Equals(true)) //Verifica se o email é valido
                {
                    SalvarNoXML();
                    MessageBox.Show(CLRegras.Constantes.funcionario + ". " + CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else MessageBox.Show(CLRegras.Constantes.emailInvalido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);             
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
        /// Salva no xml
        /// </summary>
        private void SalvarNoXML()
        {
            try
            {
                string cep = txtCEP.Text;
                string endereco = txtEndereco.Text;
                string cidade = txtCidade.Text;
                string bairro = txtBairro.Text;
                int numero = int.Parse(txtNumero.Text);
                string uf = txtUF.Text;
                string telefone = txtTelefone.Text;
                string email = txtEmail.Text;
                int id = contatoxml.ContadorIDFunc();
                contatosNovo = new Contato(id,idFuncionario, cep, endereco, cidade, bairro, numero, uf, email, telefone);
                contatoxml.AdicionarFunc(contatosNovo);
                contatoxml.SalvarFunc();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Limpa os campos indicados
        /// </summary>
        private void LimparCampos()
        {
            try
            {
                txtCEP.Clear();
                txtEndereco.Clear();
                txtCidade.Clear();
                txtBairro.Clear();
                txtNumero.Clear();
                txtUF.Clear();
                txtTelefone.Clear();
                txtEmail.Clear();
                txtBairro.Enabled = true;
                txtCidade.Enabled = true;
                txtUF.Enabled = true;
                txtEndereco.Enabled = true;
                txtCEP.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

        /// <summary>
        /// qunando sai da txtbox CEP, procurar no webservice do correios de o cep existe, se existir preenche os campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            try
            {
                using (var consulta = new WSCorreios.AtendeClienteClient())
                {
                    var resultado = consulta.consultaCEP(txtCEP.Text);
                    txtBairro.Text = resultado.bairro;
                    txtCidade.Text = resultado.cidade;
                    txtUF.Text = resultado.uf;
                    txtEndereco.Text = resultado.end;
                    txtBairro.Enabled = false;
                    txtCidade.Enabled = false;
                    txtUF.Enabled = false;
                    txtEndereco.Enabled = false;
                    txtCEP.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
