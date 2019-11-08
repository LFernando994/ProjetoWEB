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
    public partial class FrmCadFuncionario : Form
    {
        Funcionario funcionarioNovo;
        AcessosUsuario usuarioNovo;
        Funcionario funcionarioBuscado;
        Contato contatoConsulta = new Contato();
        Funcionario funcionariosxml = new Funcionario();
        AcessosUsuario acesso = new AcessosUsuario();
        string id;
        bool edicao; //Variavel que determina se é edição ou cadastro

        public FrmCadFuncionario() //Construtor para fazer cadastro de funcionario
        {
            try
            {
                InitializeComponent();
                txtUsuario.Enabled = false;
                PreencherComboBoxAreas();
                funcionariosxml.Carregar();
                contatoConsulta.CarregarFunc();
                acesso.Carregar();
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
        public FrmCadFuncionario(string cpf) //Construtor para fazer edição de um funcionario
        {
            InitializeComponent();
            PreencherComboBoxAreas();
            RegrasParaEdicao(cpf);            
            funcionariosxml.Carregar();
            contatoConsulta.CarregarFunc();
        }

        private void btnAdicionarContato_Click(object sender, EventArgs e)  //botão que o texto vira "Editar Funcionario" para editar
        {
            try
            {
                if(edicao.Equals(false)) //Cadastro
                {
                    string cpf = txtCPF.Text;
                    cpf = cpf.Replace(',', '.');
                    if (funcionariosxml.BuscarFuncionarioPorCPF(cpf) != null) // Quando encotra a pessoa pega o id dela para adicionar ao contato
                    {
                        funcionarioBuscado = funcionariosxml.BuscarFuncionarioPorCPF(cpf);
                        id = funcionarioBuscado.id;
                        EditarFuncionario();
                        FrmCadContatosFuncion frm = new FrmCadContatosFuncion(id);
                        frm.ShowDialog();
                        AtualizarDgv();
                    }
                    else //Novo funcionario
                    {                     
                        if (CLRegras.ValidarCampos.ValidarCpf(cpf).Equals(true))  //Verifica se o cpf é valido
                        {
                            id = funcionariosxml.ContadorID();
                            string nome = txtNome.Text;
                            string sexo = cBxSexo.Text;
                            int rg = int.Parse(txtRg.Text);
                            DateTime dataDeNascimento = Convert.ToDateTime(txtDataNasc.Text);
                            string grupoSanguineo = cBxGrupoSanguineo.Text;
                            cpf = txtCPF.Text;
                            string usuario = txtUsuario.Text;
                            string formacao = txtFormacao.Text;
                            string areadeAtuacao = cbAreaDeAtuacao.Text;
                            string grauDeEscolaridade = cbgrauDeEscolaridade.Text;
                            string senhatemp = cpf.Substring(0, 2);                            
                            senhatemp = CLRegras.Criptografia.CriarSenha(senhatemp);
                            int idUsuario = acesso.ContadorID();
                            funcionarioNovo = new Funcionario(id, nome, sexo, cpf, rg, dataDeNascimento, grupoSanguineo, formacao, grauDeEscolaridade, areadeAtuacao);
                            usuarioNovo = new AcessosUsuario(idUsuario, nome, usuario, senhatemp, CLRegras.Constantes.funcionario);
                            acesso.Adicionar(usuarioNovo);
                            funcionariosxml.Adicionar(funcionarioNovo);
                            funcionariosxml.Salvar();
                            acesso.Salvar();
                            FrmCadContatosFuncion frm = new FrmCadContatosFuncion(id);
                            frm.ShowDialog();
                            AtualizarDgv();
                        }
                        else MessageBox.Show(CLRegras.Constantes.cpfInvalido, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);                        
                    }            
                }
                else //Edição
                {
                    EditarFuncionario();
                    MessageBox.Show(CLRegras.Constantes.funcionario + " editado com sucesso!");
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// limpa os campos 
        /// </summary>
        private void LimparCampos()
        {
            try
            {
                cBxSexo.SelectedItem = null;
                cBxGrupoSanguineo.SelectedItem = null;
                cbgrauDeEscolaridade.SelectedItem = null;
                cbAreaDeAtuacao.SelectedItem = null;
                txtNome.Clear();
                txtRg.Clear();
                txtDataNasc.Clear();
                txtCPF.Clear();
                txtFormacao.Clear();
                dgvContatos.Rows.Clear();
                txtUsuario.Clear();
                txtCPF.Enabled = true;
                txtUsuario.Enabled = false;
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
                LimparCampos();
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
                string contatoEndereco = dgvContatos.CurrentRow.Cells[0].Value.ToString();
                int numero = Convert.ToInt32(dgvContatos.CurrentRow.Cells[1].Value.ToString());
                contatoConsulta.RemoverFunc(contatoConsulta.BuscarFuncionario(contatoEndereco, numero));
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
        /// Atualiza datagrid de contato, se tive alguma alteração nas textbox salva alterações
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                AtualizarDgv();
                if (funcionarioBuscado != null)
                {
                    EditarFuncionario();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }       
        }

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
        /// Metodo que lê todas as textbox
        /// </summary>
        public void EditarFuncionario()
        {
            try
            {
                string nome = txtNome.Text;
                int rg = Convert.ToInt32(txtRg.Text);
                DateTime dataDeNasc = Convert.ToDateTime(txtDataNasc.Text);
                string sexo = cBxSexo.Text;
                string grupoSanguineo = cBxGrupoSanguineo.Text;
                string formacao = txtFormacao.Text;
                string areadeAtuacao = cbAreaDeAtuacao.Text;
                string grauDeEscolaridade = cbgrauDeEscolaridade.Text;
                funcionarioBuscado.nome = nome;
                funcionarioBuscado.rg = rg;
                funcionarioBuscado.dataDeNascimento = dataDeNasc;
                funcionarioBuscado.sexo = sexo;
                funcionarioBuscado.grupoSanguineo = grupoSanguineo;
                funcionarioBuscado.formacao = formacao;
                funcionarioBuscado.areaDeAtuacao = areadeAtuacao;
                funcionarioBuscado.grauDeEscolaridade = grauDeEscolaridade;
                funcionariosxml.Salvar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// quando sair do cpf vai procurar se tem algum funcionario existente no sistema, se tiver prenche os campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCPF_Leave(object sender, EventArgs e)
        {
            funcionarioBuscado = funcionariosxml.BuscarFuncionarioPorCPF(txtCPF.Text.ToString());
            if (funcionarioBuscado != null)
            {
                PreencerGridContatos(contatoConsulta.GetListarTodos(), funcionarioBuscado.id);
                txtNome.Text = funcionarioBuscado.nome;
                txtRg.Text = funcionarioBuscado.rg.ToString();
                txtDataNasc.Text = funcionarioBuscado.dataDeNascimento.ToString();
                cBxGrupoSanguineo.Text = funcionarioBuscado.grupoSanguineo;
                cBxSexo.Text = funcionarioBuscado.sexo.ToString();
                txtCPF.Enabled = false;
                txtUsuario.Enabled = false;
                MessageBox.Show(CLRegras.Constantes.funcionario + " " + CLRegras.Constantes.encontrado, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(CLRegras.Constantes.addContato + " " + CLRegras.Constantes.funcionario, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtRg_Leave(object sender, EventArgs e)
        {
            txtUsuario.Text = txtRg.Text;
        }

        /// <summary>
        /// preenche as comb box com as areas cadastradas no sistema
        /// </summary>
        private void PreencherComboBoxAreas()
        {
            try
            {
                AreaDeAtuacao consulta = new AreaDeAtuacao();
                consulta.Carregar();
                foreach (var item in consulta.GetListarTodos())
                {
                    cbAreaDeAtuacao.Items.Add(item.nome);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

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

        /// <summary>
        ///Método com todas as regras e mudaças de tela para edição de um funcionario 
        /// </summary>
        /// <param name="cpf"></param>
        private void RegrasParaEdicao(string cpf) 
        {
            try
            {
                funcionariosxml.Carregar();
                contatoConsulta.Carregar();
                funcionarioBuscado = funcionariosxml.BuscarFuncionarioPorCPF(cpf);
                PreencerGridContatos(contatoConsulta.GetListarTodos(), funcionarioBuscado.id);
                txtNome.Text = funcionarioBuscado.nome;
                txtRg.Text = funcionarioBuscado.rg.ToString();
                txtDataNasc.Text = funcionarioBuscado.dataDeNascimento.ToString();
                cBxGrupoSanguineo.Text = funcionarioBuscado.grupoSanguineo;
                cBxSexo.Text = funcionarioBuscado.sexo.ToString();
                txtFormacao.Text = funcionarioBuscado.formacao.ToString();
                txtCPF.Text = funcionarioBuscado.cpf.ToString();
                txtUsuario.Text = funcionarioBuscado.rg.ToString();
                cbAreaDeAtuacao.Text = funcionarioBuscado.areaDeAtuacao;
                cbgrauDeEscolaridade.Text = funcionarioBuscado.grauDeEscolaridade.ToString();
                txtCPF.Enabled = false;
                txtRg.Enabled = false;
                txtUsuario.Enabled = false;
                edicao = true;
                btnRemover.Visible = false;
                btnLimpar.Visible = false;
                btnAtualizar.Visible = false;
                btnAdicionarContato.Text = "Editar " + CLRegras.Constantes.funcionario;
                this.Text = "Editar " + CLRegras.Constantes.funcionario;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }
        private void AtualizarDgv()
        {
            try
            {
                dgvContatos.Rows.Clear();
                contatoConsulta.Carregar();
                string idatualizado = funcionariosxml.BuscarIdPorCPF(txtCPF.Text.ToString());
                PreencerGridContatos(contatoConsulta.GetListarTodos(), idatualizado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
