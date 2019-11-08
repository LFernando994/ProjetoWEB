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
    public partial class FrmLista : Form
    {
        Cliente clienteXML = new Cliente();
        UsuariosSistema secretariaXML = new UsuariosSistema();
        Contato contatoClieXML = new Contato();
        Funcionario funcionarioXML = new Funcionario();
        Contato contatoFuncXML = new Contato();
        string perfil;
        

        public FrmLista(string perfil)
        {
            try
            {
                if (perfil.Equals(CLRegras.Constantes.cliente))     //Listar todos os clientes e buscar
                {
                    this.perfil = perfil;
                    contatoClieXML.Carregar();
                    clienteXML.Carregar();
                    InitializeComponent();
                    dgvListar.Columns["FormacaoColu"].Visible = false;
                    dgvListar.Columns["grauDeEscolColu"].Visible = false;
                    dgvListar.Columns["areaDeAtuacaoColu"].Visible = false;
                    dgvListar.Columns["qntChamadosColu"].Visible = false;
                    PreencherGridListarCliente(clienteXML.GetListarTodos());
                }
                else if (perfil.Equals(CLRegras.Constantes.usuario)) //Listar todos as secretárias e buscar
                {
                    this.perfil = perfil;
                    InitializeComponent();
                    secretariaXML.Carregar();
                    gbPerfil.Text = "Secretário(a)";
                    this.Text = "Lista de Secretário(a)";
                    dgvListar.Columns["DataExpir"].Visible = false;
                    dgvListar.Columns["FormacaoColu"].Visible = false;
                    dgvListar.Columns["grauDeEscolColu"].Visible = false;
                    dgvListar.Columns["areaDeAtuacaoColu"].Visible = false;
                    dgvListar.Columns["qntChamadosColu"].Visible = false;
                    PreencherGridListarSecretaria(secretariaXML.GetListarTodos());
                }
                else                                                     //Listar todos os funcionarios e buscar
                {
                    this.perfil = perfil;
                    InitializeComponent();
                    gbPerfil.Text = CLRegras.Constantes.funcionario+"s" ;
                    this.Text = "Lista de " + CLRegras.Constantes.funcionario + "s";
                    dgvListar.Columns["DataExpir"].Visible = false;
                    contatoFuncXML.Carregar();
                    funcionarioXML.Carregar();
                    PreencherGridListarFuncionario(funcionarioXML.GetListarTodos());

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

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListar.CurrentRow != null)
                {
                    if (perfil.Equals(CLRegras.Constantes.cliente))  //Perfil Cliente
                    {
                        string clienteNome = dgvListar.CurrentRow.Cells[1].Value.ToString();
                        string clienteCPF = dgvListar.CurrentRow.Cells[2].Value.ToString();
                        Cliente clienteRemover = clienteXML.BuscarClientePorCPF(clienteCPF);
                        clienteXML.Remover(clienteRemover);

                        foreach (Contato x in contatoClieXML.BuscarPorID(clienteRemover.id)) // Remove os contatos do Cliente removido
                        {
                            contatoClieXML.Remover(x);
                        }

                        MessageBox.Show(clienteNome + CLRegras.Constantes.removido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvListar.Rows.Clear();
                        PreencherGridListarCliente(clienteXML.GetListarTodos());
                    }
                    else if (perfil.Equals(CLRegras.Constantes.usuario)) //Perfil Secretária
                    {
                        string secretariaCPF = dgvListar.CurrentRow.Cells[2].Value.ToString();
                        UsuariosSistema secretariaRemover = secretariaXML.BuscarSecretariaPorCPF(secretariaCPF);
                        secretariaXML.Remover(secretariaRemover);
                        MessageBox.Show(secretariaRemover.nome + CLRegras.Constantes.removido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvListar.Rows.Clear();
                        PreencherGridListarSecretaria(secretariaXML.GetListarTodos());
                    }
                    else //Perfil Funcionário
                    {
                        string funcionarioCPF = dgvListar.CurrentRow.Cells[2].Value.ToString();
                        Funcionario funcionarioRemover = funcionarioXML.BuscarFuncionarioPorCPF(funcionarioCPF);
                        funcionarioXML.Remover(funcionarioRemover);
                        foreach (Contato x in contatoFuncXML.BuscarPorIDFuncionario(funcionarioRemover.id))
                        {
                            contatoFuncXML.RemoverFunc(x);
                        }
                        MessageBox.Show(CLRegras.Constantes.funcionario + CLRegras.Constantes.removido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvListar.Rows.Clear();
                        PreencherGridListarFuncionario(funcionarioXML.GetListarTodos());
                    }

                }
                else MessageBox.Show(CLRegras.Constantes.selecaoLinha, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                if (perfil.Equals(CLRegras.Constantes.cliente)) //Perfil Cliente
                {
                    int id = Convert.ToInt32(dgvListar.CurrentRow.Cells[0].Value.ToString());
                    string clienteNome = dgvListar.CurrentRow.Cells[1].Value.ToString();
                    string clienteCPF = dgvListar.CurrentRow.Cells[2].Value.ToString();
                    int clienteRG = Convert.ToInt32(dgvListar.CurrentRow.Cells[3].Value.ToString());
                    DateTime clienteDatadeNasc = Convert.ToDateTime(dgvListar.CurrentRow.Cells[4].Value.ToString());
                    string clienteGrupoSangui = dgvListar.CurrentRow.Cells[5].Value.ToString();
                    char clienteSexo = Convert.ToChar(dgvListar.CurrentRow.Cells[6].Value.ToString());
                    DateTime clienteDataExpiracao = Convert.ToDateTime(dgvListar.CurrentRow.Cells[8].Value.ToString());
                    FrmEditarCliente frm = new FrmEditarCliente(id, clienteNome, clienteCPF, clienteRG, clienteDatadeNasc, clienteSexo, clienteGrupoSangui, clienteDataExpiracao);
                    frm.ShowDialog();
                }
                else if (perfil.Equals(CLRegras.Constantes.usuario)) //Perfil Secretária
                {
                    int id = Convert.ToInt32(dgvListar.CurrentRow.Cells[0].Value.ToString());
                    int secretariaRG = Convert.ToInt32(dgvListar.CurrentRow.Cells[3].Value.ToString());
                    FrmCadUsuarioSistema frm = new FrmCadUsuarioSistema(true, secretariaRG);
                    frm.ShowDialog();
                }
                else //Perfil Funcionário
                {
                    string funcionarioCPF = dgvListar.CurrentRow.Cells[2].Value.ToString();
                    FrmCadFuncionario frm = new FrmCadFuncionario(funcionarioCPF);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (perfil.Equals(CLRegras.Constantes.cliente)) //Perfil Cliente
                {
                    dgvListar.Rows.Clear();
                    PreencherGridListarCliente(clienteXML.GetListarTodos());
                }
                else if (perfil.Equals(CLRegras.Constantes.usuario)) //Perfil Secretária
                {
                    dgvListar.Rows.Clear();
                    PreencherGridListarSecretaria(secretariaXML.GetListarTodos());
                }
                else //Perfil Funcionário
                {
                    dgvListar.Rows.Clear();
                    PreencherGridListarFuncionario(funcionarioXML.GetListarTodos());

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
                string cpf = txtCPF.Text;
                cpf = cpf.Replace(',', '.');
                if (perfil.Equals(CLRegras.Constantes.cliente)) //Definição da ação de perfil 
                {
                    dgvListar.Rows.Clear();
                    cpf = txtCPF.Text;
                    Cliente x = clienteXML.BuscarClientePorCPF(cpf); // x = Cliente Buscado
                    if (x != null)
                    {
                        dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.dataDeNascimento, x.grupoSanguineo, x.sexo, x.rg, x.dataDeExpiracao);
                        MessageBox.Show("Usuário valido até " + x.dataDeExpiracao, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(CLRegras.Constantes.cliente + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (perfil.Equals(CLRegras.Constantes.usuario)) //Definição da ação de perfil 
                {
                    dgvListar.Rows.Clear();
                    cpf = txtCPF.Text;
                    UsuariosSistema x = secretariaXML.BuscarSecretariaPorCPF(cpf); // x = Secretária Buscado
                    if (x != null)
                    {
                        dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.rg);                        
                    }
                     else MessageBox.Show(CLRegras.Constantes.usuario + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    dgvListar.Rows.Clear();
                    cpf = txtCPF.Text;
                    Funcionario x = funcionarioXML.BuscarFuncionarioPorCPF(cpf);
                    if (x != null)
                    {
                        dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.dataDeNascimento, x.grupoSanguineo, x.sexo, x.rg, "", x.formacao, x.grauDeEscolaridade, x.areaDeAtuacao, x.quantidadeChamados);
                    }
                    else MessageBox.Show(CLRegras.Constantes.funcionario + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(CLRegras.Constantes.cliente + "não " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }
        }

        /// <summary>
        /// Preenche Grid de Secretária
        /// </summary>
        /// <param name="secretaria"></param>
        private void PreencherGridListarSecretaria(List<UsuariosSistema> usuarios)
        {
            try
            {
                secretariaXML.Carregar();
                foreach (UsuariosSistema x in usuarios)
                {
                    dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.rg);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Preenche Grid de Cliente
        /// </summary>
        /// <param name="clientes"></param>
        private void PreencherGridListarCliente(List<Cliente> clientes)
        {
            try
            {
                clienteXML.Carregar();

                foreach (Cliente x in clientes)
                {
                    dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.dataDeNascimento, x.grupoSanguineo, x.sexo, x.rg, x.dataDeExpiracao);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Preenche Grid de Funcionário
        /// </summary>
        /// <param name="funcionarios"></param>
        private void PreencherGridListarFuncionario(List<Funcionario> funcionarios)
        {
            try
            {
                funcionarioXML.Carregar();
                foreach (Funcionario x in funcionarios)
                {
                    dgvListar.Rows.Add(x.id, x.nome, x.cpf, x.rg, x.dataDeNascimento, x.grupoSanguineo, x.sexo, x.rg, "", x.formacao, x.grauDeEscolaridade, x.areaDeAtuacao, x.quantidadeChamados);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
