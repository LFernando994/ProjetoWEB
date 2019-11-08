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
    public partial class FrmContatosRelacionados : Form
    {
        Contato contatoClienteConsulta = new Contato();
        Cliente clientesConsulta = new Cliente();
        Contato contatoFuncionarioConsulta = new Contato();
        Funcionario funcionarioConsulta = new Funcionario();
        string perfil; //Define o perfil de Busca se é um cliente ou um funcionário

        public FrmContatosRelacionados(string perfil)
        {
            this.perfil = perfil;
            try
            {
                if(perfil.Equals(CLRegras.Constantes.cliente))
                {
                    InitializeComponent();
                    clientesConsulta.Carregar();
                    contatoClienteConsulta.Carregar();
                }
                else
                {
                    InitializeComponent();
                    contatoFuncionarioConsulta.CarregarFunc();
                    funcionarioConsulta.Carregar();
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvContatos.Rows.Clear();
                txtCPF.Clear();
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
                string cpf = txtCPF.Text;
                cpf = cpf.Replace(',', '.');
                if (perfil.Equals(CLRegras.Constantes.cliente))
                {
                    dgvContatos.Rows.Clear();
                    cpf = txtCPF.Text;
                    Cliente clienteBuscado = clientesConsulta.BuscarClientePorCPF(cpf);
                    if (clienteBuscado != null)
                    {
                        PreencerGridContatos(contatoFuncionarioConsulta.GetListarTodos(), clienteBuscado.id);
                        MessageBox.Show(CLRegras.Constantes.cliente + " " + clienteBuscado.nome + " " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(CLRegras.Constantes.cliente + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dgvContatos.Rows.Clear();
                    cpf = txtCPF.Text;
                    Funcionario funcionarioBuscado = funcionarioConsulta.BuscarFuncionarioPorCPF(cpf);
                    if (funcionarioBuscado != null)
                    {
                        PreencerGridContatos(contatoFuncionarioConsulta.GetListarTodos(), funcionarioBuscado.id);
                        MessageBox.Show(CLRegras.Constantes.funcionario+" "+ funcionarioBuscado.nome +" "+ CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(CLRegras.Constantes.funcionario + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }             
            }
            catch (Exception ex)
            {            
                throw ex;
            }
        }

        /// <summary>
        /// Preenche Grid de contatos
        /// </summary>
        /// <param name="contatos"></param>
        /// <param name="id"></param>
        private void PreencerGridContatos(List<Contato> contatos, string idPessoa)
        {
            try
            {
                foreach (Contato x in contatos.Where(x => x.idPessoa.Equals(idPessoa)))
                {
                    dgvContatos.Rows.Add(x.endereco, x.numero, x.bairro, x.cidade, x.uf, x.cep, x.email, x.telefone);
                }
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

        /// <summary>
        /// Edita as infirmação pegando a pessoa selecionada no Grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvContatos.CurrentRow != null)
            {
                try
                {
                    if(perfil.Equals(CLRegras.Constantes.cliente)) //Abrir forms edição para o cliente
                    {
                        string endereco = dgvContatos.CurrentRow.Cells[0].Value.ToString();
                        int numero = Convert.ToInt32(dgvContatos.CurrentRow.Cells[1].Value.ToString());
                        string bairro = dgvContatos.CurrentRow.Cells[2].Value.ToString();
                        string cidade = dgvContatos.CurrentRow.Cells[3].Value.ToString();
                        string uf = dgvContatos.CurrentRow.Cells[4].Value.ToString();
                        string cep = dgvContatos.CurrentRow.Cells[5].Value.ToString();
                        string email = dgvContatos.CurrentRow.Cells[6].Value.ToString();
                        string telefone = dgvContatos.CurrentRow.Cells[7].Value.ToString();
                        Contato contato = contatoClienteConsulta.Buscar(endereco);
                        int id = contato.id;
                        string idPessoa = contato.idPessoa;
                        FrmEditarContato frm = new FrmEditarContato(id, idPessoa, cep, endereco, bairro, numero, cidade, uf, email, telefone);
                        frm.ShowDialog();
                        this.Close();

                    }
                    else   //Abrir forms edição para o funcionário
                    {
                        string endereco = dgvContatos.CurrentRow.Cells[0].Value.ToString();
                        int numero = Convert.ToInt32(dgvContatos.CurrentRow.Cells[1].Value.ToString());
                        FrmEditarContato frm = new FrmEditarContato(endereco, numero);
                        frm.ShowDialog();
                        this.Close();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw ex;
                }             
            }
            else MessageBox.Show(CLRegras.Constantes.selecaoLinha, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
