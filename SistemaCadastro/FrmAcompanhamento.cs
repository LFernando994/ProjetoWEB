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
    public partial class FrmAcompanhamento : Form
    {
        Chamado consultaChamados = new Chamado();

        public FrmAcompanhamento()
        {
            try
            {
                InitializeComponent();
                consultaChamados.Carregar();
                PreencherGrid();
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
        /// Preenche grid com todos os chamados
        /// </summary>
        private void PreencherGrid()
        {
            try
            {
                foreach (var x in consultaChamados.GetListarTodos())
                {
                    dgvListar.Rows.Add(x.id, x.clienteSolicitante.nome, x.funcionarioResponsavel.nome, x.funcionarioResponsavel.areaDeAtuacao, x.dataDeSolicitacao);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }          
        }
    }
}
