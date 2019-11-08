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
    public partial class FrmChamados : Form
    {
        Chamado chamadoxml = new Chamado();
        Funcionario consultarFuncionario = new Funcionario();
        Chamado chamadoNovo;
        Cliente solicitante;
        Funcionario funcionarioResponsavel;

        public FrmChamados()
        {
            try
            {
                InitializeComponent();
                PreencherComboBoxAreas();
                btnSolicitar.Enabled = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }    
        }

        public FrmChamados(Cliente clienteAtual)
        {
            try
            {
                InitializeComponent();
                PreencherComboBoxAreas();
                chamadoxml.Carregar();
                consultarFuncionario.Carregar();
                solicitante = clienteAtual;
            }
            catch (Exception ex)
            {
                throw ex; 
            }     
        }

        /// <summary>
        /// Preenche as combobox com as areas de atuação cadastrada
        /// </summary>
        private void PreencherComboBoxAreas()
        {
            try
            {
                AreaDeAtuacao consulta = new AreaDeAtuacao();
                consulta.Carregar();
                foreach (var item in consulta.GetListarTodos())
                {
                    cbAreadoChamado.Items.Add(item.nome);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Abertura do chamando para quem tem menos chamados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void brnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                string descricao = txtDescricao.Text;
                string area = cbAreadoChamado.Text;
                DateTime horaAtual = DateTime.Now;
                int id = chamadoxml.ContadorID();
                funcionarioResponsavel = consultarFuncionario.SolicitacaoDeChamado(area); // Procura quem tem o menor chamado por area indicada 
                chamadoNovo = new Chamado(id, descricao, horaAtual, solicitante, funcionarioResponsavel);

                chamadoxml.Adicionar(chamadoNovo);
                chamadoxml.Salvar();
                Funcionario funcionarioEdit = funcionarioResponsavel;
                funcionarioEdit.quantidadeChamados += 1;
                consultarFuncionario.Salvar();
                MessageBox.Show(CLRegras.Constantes.mensagemGnerica + " Funcionário responsavével pelo atendimento: " + funcionarioResponsavel.nome,
                                this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricao.Clear();
                cbAreadoChamado.Text = null;
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
