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
    public partial class FrmChamadosAbertos : Form
    {
        Funcionario funcionario;
        Chamado consultaChamados = new Chamado();

        public FrmChamadosAbertos()
        {
            try
            {
                InitializeComponent();
                consultaChamados.Carregar();
                PreencherGridListaTodos();
                btnFinalizarChamado.Enabled = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public FrmChamadosAbertos(Funcionario funcionarioAtual)
        {
            try
            {
                InitializeComponent();
                consultaChamados.Carregar();
                funcionario = funcionarioAtual;
                PreencherGrid(funcionario.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Preencher Grid do funcionario responsavel pelo chamado
        /// </summary>
        /// <param name="id"></param>
        public void PreencherGrid(string id)
        {
            try
            {
                dgvChamados.Rows.Clear();
                foreach (var x in consultaChamados.GetListarTodos().Where(c => c.funcionarioResponsavel.id.Equals(id)).TakeWhile(c => c.funcionarioResponsavel.id.Equals(id)))
                {
                    dgvChamados.Rows.Add(x.id, x.clienteSolicitante.nome, x.funcionarioResponsavel.areaDeAtuacao, x.dataDeSolicitacao);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// preenche grid de administrador listando todos os chamados aberto
        /// </summary>
        public void PreencherGridListaTodos()
        {
            try
            {
                dgvChamados.Rows.Clear();
                foreach (var x in consultaChamados.GetListarTodos())
                {
                    dgvChamados.Rows.Add(x.id, x.clienteSolicitante.nome, x.funcionarioResponsavel.areaDeAtuacao, x.dataDeSolicitacao);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnFinalizarChamado_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionarioConsulta = new Funcionario();
                funcionarioConsulta.Carregar();
                int id = Convert.ToInt32(dgvChamados.CurrentRow.Cells[0].Value.ToString());
                var chamado = consultaChamados.BuscarChamadoPorId(id);
                var funcionarioEdit = funcionarioConsulta.BuscarFuncionarioPorCPF(chamado.funcionarioResponsavel.cpf);
                consultaChamados.Remover(chamado);
                consultaChamados.Salvar();
                MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                funcionarioEdit.quantidadeChamados -= 1;
                funcionarioConsulta.Salvar();

                PreencherGrid(funcionario.id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvChamados_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Descricao();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void dgvChamados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Descricao();
            }
            catch (Exception ex)
            {

                throw ex;
            }       
        }

        /// <summary>
        /// Método para mostrar a descrição de um chmado em uma text box
        /// </summary>
        private void Descricao()
        {
            try
            {
                txtDescricao.Clear();
                int id = Convert.ToInt32(dgvChamados.CurrentRow.Cells[0].Value.ToString());
                var chamado = consultaChamados.BuscarChamadoPorId(id);
                txtDescricao.Text = chamado.descricao;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
