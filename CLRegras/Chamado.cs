using CLData;
using CLRegras;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CLRegras
{
    public class Chamado
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime dataDeSolicitacao { get; set; }

        public string idCliente { get; set; } //BD
        public string idFuncionario { get; set; } //BD
        public string Imagem { get; set; } //Inserir imagem no projeto web

        public Cliente clienteSolicitante = new Cliente();    //XML 
        public Funcionario funcionarioResponsavel = new Funcionario(); //XML
        DAOChamados<Chamado> daoChamados = new DAOChamados<Chamado>();

        public Chamado()
        {
        }

        public Chamado(int id, string descricao, DateTime dataDeSolicitacao, Cliente clienteSolicitante, Funcionario funcionarioResponsavel)
        {
            this.id = id;
            this.descricao = descricao;
            this.dataDeSolicitacao = dataDeSolicitacao;
            this.clienteSolicitante = clienteSolicitante;
            this.funcionarioResponsavel = funcionarioResponsavel;
        }
        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Chamado> GetListarTodos()
        {
            return daoChamados.ListarTodos().ToList();                
        }

        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(Chamado chamado)
        {
            Carregar();
            daoChamados.Adicionar(chamado);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(Chamado chamado)
        {
            Carregar();
            daoChamados.Remover(chamado);
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoChamados.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoChamados.Salvar();
        }

        #region Validações

        /// <summary>
        /// Cria id
        /// </summary>
        /// <returns></returns>
        public int ContadorID()
        {
            try
            {
                return GetListarTodos().Last().id + 1;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }
        #endregion

        #region Buscas

        /// <summary>
        /// Busca chamado pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Chamado BuscarChamadoPorId(int id)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}

