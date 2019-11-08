using CLData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class Funcionario: Pessoa
    {        
        public string formacao { get; set; }
        public string grauDeEscolaridade { get; set; }
        public string areaDeAtuacao { get; set; }
        public int quantidadeChamados { get; set; }
        DAOFuncionario<Funcionario> daoFuncionario = new DAOFuncionario<Funcionario>();

        public Funcionario(string id, string nome, string sexo, string cpf, int rg, DateTime dataDeNascimento, string grupoSanguineo, string formacao, string grauDeEscolaridade, string areaDeAtuacao) : base(id, nome, sexo, cpf, rg, dataDeNascimento, grupoSanguineo)
        {
            this.formacao = formacao;
            this.grauDeEscolaridade = grauDeEscolaridade;
            this.areaDeAtuacao = areaDeAtuacao;
            this.quantidadeChamados = 0;
        }

        public Funcionario():base()
        {
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Funcionario> GetListarTodos()
        {
            return daoFuncionario.ListarTodos().ToList();         
        }
        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(Funcionario funcionario)
        {
            Carregar();
            daoFuncionario.Adicionar(funcionario);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(Funcionario funcionario)
        {
            if (funcionario != null)
            {
                daoFuncionario.Remover(funcionario);
            }
            else
            {
                Carregar();
                daoFuncionario.Remover(funcionario);
            }
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoFuncionario.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoFuncionario.Salvar();
        }

        #region Validações

        /// <summary>
        /// Método para criar ID
        /// </summary>
        /// <returns></returns>
        public string ContadorID()
        {
            try
            {
                return (GetListarTodos().Last().id + 1);
            }
            catch (InvalidOperationException)
            {
                return "0";
            }
        }
        #endregion

        #region Buscas

        /// <summary>
        /// Busca fucnionario pelo cpf inserido.
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public Funcionario BuscarFuncionarioPorCPF(string cpf)
        {
            return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault();
        }

        /// <summary>
        /// Busca id do funcionario pelo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public string BuscarIdPorCPF(string cpf)
        {
            return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault().id;
        }

        /// <summary>
        /// Buscar funcionário pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Funcionario BuscarFuncPorID(int id)
        {
            return GetListarTodos().Where(c => c.id.Equals(id)).FirstOrDefault();
        }

        /// <summary>
        /// Busca Funcionario pelo usuario (usuario == rg)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Funcionario BuscarFuncionarioPorUsuario(int usuario)
        {
            try
            {
                return GetListarTodos().Where(c => c.rg.Equals(usuario)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Procura a area desejada pela abertura do chamado, depois procura quem tem menor numero de chamados
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public Funcionario SolicitacaoDeChamado(string area)
        {
            Carregar();
            List<Funcionario> funcionariosPorArea = new List<Funcionario>();
            try
            {
                foreach (var item in GetListarTodos().Where(c => c.areaDeAtuacao.Equals(area)).TakeWhile(c => c.areaDeAtuacao.Equals(area))) //Filtra por area de atuação 
                {
                    funcionariosPorArea.Add(item);
                }
                int menorChamado = funcionariosPorArea.Min(c => c.quantidadeChamados); //Encontra o minimo de quantidade de chamado               
                return funcionariosPorArea.Where(c => c.quantidadeChamados.Equals(menorChamado)).FirstOrDefault(); //Procura o funcionario na lista filtrada que tem o menor

            }
            catch (Exception)
            {
                return funcionariosPorArea.First();
            }
        }
        #endregion

    }
}
