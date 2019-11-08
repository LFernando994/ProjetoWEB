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
    public partial class FrmAreaDeAtuacao : Form
    {
        AreaDeAtuacao areaDeAtuacao = new AreaDeAtuacao();
        AreaDeAtuacao areaDeAtuacaoNova;

        public FrmAreaDeAtuacao()
        {
            try
            {
                InitializeComponent();
                areaDeAtuacao.Carregar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
        /// <summary>
        /// Preenche Grid todas as areas de atuação existentes 
        /// </summary>
        private void PreencherGrid()
        {
            try
            {
                dgvListar.Rows.Clear();
                foreach (var x in areaDeAtuacao.GetListarTodos())
                {
                    dgvListar.Rows.Add(x.id, x.nome);
                }
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
                int id = areaDeAtuacao.ContadorID();
                areaDeAtuacaoNova = new AreaDeAtuacao(id, nome);
                areaDeAtuacao.Adicionar(areaDeAtuacaoNova);
                areaDeAtuacao.Salvar();            
                MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Clear();
                PreencherGrid();
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvListar.CurrentRow.Cells[0].Value.ToString());
                var area = areaDeAtuacao.BuscarAreaPorId(id);
                areaDeAtuacao.Remover(area);
                areaDeAtuacao.Salvar();
                PreencherGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }      
        }

    }
}
