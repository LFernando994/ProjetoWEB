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
using SistemaCadastro;


namespace SistemaCadastro
{
    public partial class FrmCadClientes : Form
    {
        Cliente clienteNovo;
        AcessosUsuario usuarioNovo;
        Cliente clienteBuscado;
        Contato contatoConsulta = new Contato();
        Cliente clientesxml = new Cliente();
        AcessosUsuario acesso = new AcessosUsuario();
        string id;

        public FrmCadClientes()
        {
            try
            {
                InitializeComponent();
                txtUsuario.Enabled = false;
                clientesxml.Carregar();
                contatoConsulta.Carregar();
                acesso.Carregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
        
        /// <summary>
        /// Se o grid estiver preenchido pega o id da pessoa, se não Cria uma lista de clientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnContato_Click(object sender, EventArgs e)
        {
            try
            {
                if (clientesxml.BuscarClientePorCPF(txtCPF.Text.ToString()) != null)
                {
                    id = clientesxml.BuscarIdPorCPF(txtCPF.Text.ToString());
                    EditarCliente();
                    FrmCadContatosCliente frmContatos = new FrmCadContatosCliente(id);
                    frmContatos.ShowDialog();
                    AtualizarDgv();
                }
                else
                {
                    string cpf = txtCPF.Text;
                    cpf = cpf.Replace(',', '.');
                    if (CLRegras.ValidarCampos.ValidarCpf(cpf).Equals(true))
                    {
                        id = Convert.ToString( clientesxml.ContadorID());
                        string nome = txtNome.Text;
                        string sexo = cBxSexo.Text;
                        int rg = int.Parse(txtRg.Text);
                        DateTime dataDeNascimento = Convert.ToDateTime(txtDataNasc.Text);
                        string grupoSanguineo = cBxGrupoSanguineo.Text;
                        cpf = txtCPF.Text;
                        string usuario = txtUsuario.Text;
                        DateTime dataDeExpiracao = Convert.ToDateTime(dtpDataDeExpiração.Text.ToString());
                        int idUsuario = acesso.ContadorID();
                        clienteNovo = new Cliente(id, nome, sexo, cpf, rg, dataDeNascimento, grupoSanguineo, dataDeExpiracao);
                        usuarioNovo = new AcessosUsuario(idUsuario, nome, usuario, "null", CLRegras.Constantes.cliente);
                        acesso.Adicionar(usuarioNovo);
                        clientesxml.Adicionar(clienteNovo);
                        clientesxml.Salvar();
                        acesso.Salvar();
                        FrmCadContatosCliente frmContatos = new FrmCadContatosCliente(id);
                        frmContatos.ShowDialog();
                        AtualizarDgv();
                    }
                    else MessageBox.Show(CLRegras.Constantes.cpfInvalido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                                     
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// fecha a tela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// Limpa o data Grid e os campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparCampos();
            }
            catch (Exception ex) 
            {
                throw ex;
            }       
        }

        /// <summary>
        /// Limpa os campos da tela de cadastro.
        /// </summary>
        private void LimparCampos()
        {
            try
            {
                cBxSexo.SelectedItem = null;
                cBxGrupoSanguineo.SelectedItem = null;
                txtNome.Clear();
                txtRg.Clear();
                txtDataNasc.Clear();
                txtCPF.Clear();
                dgvContatos.Rows.Clear();
                txtUsuario.Clear();
                txtCPF.Enabled = true;
                txtUsuario.Enabled = false; 
                dtpDataDeExpiração.Text = DateTime.Now.Date.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
   
        /// <summary>
        /// Preenhe o Grid com o id indicado.
        /// </summary>
        /// <param name="contatos"></param>
        /// <param name="id"></param>
        private void PreencerGridContatos(List<Contato> contatos, string id)
        {
            try
            {
                foreach (Contato x in contatos.Where(x => x.id.Equals(id)))
                {
                    dgvContatos.Rows.Add(x.endereco, x.numero, x.bairro, x.cidade, x.uf, x.cep, x.email, x.telefone);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Atualiza datagrid de contato, se tive alguma alteração nas textbox salva alterações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizarDgv();
                if (clienteBuscado != null)
                {
                    EditarCliente();
                }
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        /// <summary>
        /// Remove um contato selecionado no grid 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                string contatoEndereco = dgvContatos.CurrentRow.Cells[0].Value.ToString();
                contatoConsulta.Remover(contatoConsulta.Buscar(contatoEndereco));
                MessageBox.Show(CLRegras.Constantes.salvo, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvContatos.Rows.Clear();
                contatoConsulta.Carregar();
                foreach (Contato x in contatoConsulta.GetListarTodos().Where(x => x.id.Equals(id)))
                {
                    dgvContatos.Rows.Add(x.endereco, x.numero, x.bairro, x.cidade, x.uf, x.cep, x.email, x.telefone);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// quando deixa a textbox cpf, procura se tem algum cliente cadastrado no sistema, se tiver preenche campos, pega id e passa para o frm de contatos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCPF_Leave(object sender, EventArgs e)
        {
            clienteBuscado = clientesxml.BuscarClientePorCPF(txtCPF.Text.ToString());   
            if(clienteBuscado != null)
            {
                PreencerGridContatos(contatoConsulta.GetListarTodos(), clienteBuscado.id);
                txtNome.Text = clienteBuscado.nome;
                txtRg.Text = clienteBuscado.rg.ToString();
                txtDataNasc.Text = clienteBuscado.dataDeNascimento.ToString();               
                cBxGrupoSanguineo.Text = clienteBuscado.grupoSanguineo;
                cBxSexo.Text = clienteBuscado.sexo.ToString();
                txtCPF.Enabled = false;               
                txtUsuario.Enabled = false;
                MessageBox.Show(CLRegras.Constantes.cliente + " " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(CLRegras.Constantes.addContato + " " + CLRegras.Constantes.cliente, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Edita o cliente se for necessario
        /// </summary>
        public void EditarCliente()
        {
            try
            {
                string nome = txtNome.Text;
                int rg = Convert.ToInt32(txtRg.Text);
                DateTime dataDeNasc = Convert.ToDateTime(txtDataNasc.Text);
                string sexo = cBxSexo.Text;
                string grupoSanguineo = cBxGrupoSanguineo.Text;
                DateTime dataExpiracao = Convert.ToDateTime(dtpDataDeExpiração.Text.ToString());
                Cliente acessoEdit = clientesxml.BuscarClientePorCPF(txtCPF.Text);
                acessoEdit.dataDeExpiracao = dataExpiracao;
                clienteBuscado.nome = nome;
                clienteBuscado.rg = rg;
                clienteBuscado.dataDeNascimento = dataDeNasc;
                clienteBuscado.sexo = sexo;
                clienteBuscado.grupoSanguineo = grupoSanguineo;
                clientesxml.Salvar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                 
        }

        /// <summary>
        /// Método para atualização de Grid View
        /// </summary>
        private void AtualizarDgv()
        {
            try
            {
                dgvContatos.Rows.Clear();
                contatoConsulta.Carregar();
                string idatualizado = clientesxml.BuscarIdPorCPF(txtCPF.Text.ToString());
                PreencerGridContatos(contatoConsulta.GetListarTodos(), idatualizado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Por padrão o usuáro é igual ao rg. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRg_Leave(object sender, EventArgs e)
        {
            txtUsuario.Text = txtRg.Text;
        }

        /// <summary>
        /// Valida nome se não tiver vazio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text))
            {
                errorProvider1.SetError(txtNome, CLRegras.Constantes.digiteNome);
            }
            else
            {
                errorProvider1.SetError(txtCPF, null);
            }
        }
    }
}
