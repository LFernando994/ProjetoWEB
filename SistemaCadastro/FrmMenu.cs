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
    public partial class FrmMenu : Form
    {
        Cliente clienteLogado;
        Funcionario funcionarioLogado;
        UsuariosSistema secretariaLogado;

        /// <summary>
        /// Construtor para iniciar o menu de Administrador
        /// </summary>
        /// <param name="nome"></param>
        public FrmMenu(string nome)
        {
            try
            {
                InitializeComponent();
                statusNome.Text = "Usuário: " + nome + ", ativo";
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        /// <summary>
        /// Construtor para iniciar o menu de Secretaria
        /// </summary>
        public FrmMenu(UsuariosSistema secretariaAtual)
        {
            try
            {
                InitializeComponent();
                statusNome.Text = "Usuário Funcionário: " + secretariaAtual.nome + ", ativo";
                secretariaLogado = secretariaAtual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public FrmMenu(Cliente clienteAtual)  // Pega as informações da pessoa que entrou, para ver suas abertura de chamado com suas informações 
        {
            try
            {
                InitializeComponent();
                statusNome.Text = "Usuário Cliente: " + clienteAtual.nome + ", ativo";
                clienteLogado = clienteAtual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
         
        }

        public FrmMenu(Funcionario funcionarioAtual) // Pega as informações da pessoa que entrou, para ver suas solicitações de chamado
        {
            try
            {
                InitializeComponent();
                statusNome.Text = "Usuário Funcionário: " + funcionarioAtual.nome + ", ativo";
                funcionarioLogado = funcionarioAtual;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void listarTodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLista frm = new FrmLista(CLRegras.Constantes.cliente);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void buscarContatosRelacionadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmContatosRelacionados frm = new FrmContatosRelacionados(CLRegras.Constantes.cliente);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCadUsuarioSistema frm = new FrmCadUsuarioSistema();
                frm.ShowDialog();

            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCadClientes frm = new FrmCadClientes();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void funcionárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCadFuncionario frm = new FrmCadFuncionario();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        private void secretáriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            
        }

        private void áreaDeAtuaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAreaDeAtuacao frm = new FrmAreaDeAtuacao();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        private void abrirChamadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteLogado != null)
                {
                    FrmChamados frm = new FrmChamados(clienteLogado);
                    frm.ShowDialog();
                }
                else
                {
                    FrmChamados frm = new FrmChamados();
                    frm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
                
        }

        private void acompanhamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAcompanhamento frm = new FrmAcompanhamento();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void trocarDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLogin frm = new FrmLogin();
                this.Hide();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void chamadosAbertosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (funcionarioLogado != null)
                {
                    FrmChamadosAbertos frm = new FrmChamadosAbertos(funcionarioLogado);
                    frm.ShowDialog();
                }
                else
                {
                    FrmChamadosAbertos frm = new FrmChamadosAbertos();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        private void alterarSenhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (funcionarioLogado != null)
                {
                    FrmAlterarSenha frm = new FrmAlterarSenha(funcionarioLogado);
                    frm.ShowDialog();
                }
                else if (secretariaLogado != null)
                {
                    FrmAlterarSenha frm = new FrmAlterarSenha(secretariaLogado);
                    frm.ShowDialog();
                }
                else if (clienteLogado != null)
                {
                    FrmAlterarSenha frm = new FrmAlterarSenha(clienteLogado);
                    frm.ShowDialog();
                }
                else
                {
                    FrmAlterarSenha frm = new FrmAlterarSenha();
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
              
        }

        private void listarTodosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmLista frm = new FrmLista(CLRegras.Constantes.usuario);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void listarTodosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            FrmLista frm = new FrmLista(CLRegras.Constantes.funcionario);
            frm.ShowDialog();
        }

        private void contatosRelacionadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
            FrmContatosRelacionados frm = new FrmContatosRelacionados(CLRegras.Constantes.funcionario);
            frm.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCadUsuarioSistema frm = new FrmCadUsuarioSistema();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmControleUsuario frm = new FrmControleUsuario();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ajudaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmAjuda frm = new FrmAjuda();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void redefinicaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRedefinirSenha frm = new FrmRedefinirSenha();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPerisSistema frm = new FrmPerisSistema();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
