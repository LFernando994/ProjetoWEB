using CLData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CLRegras
{
    public class AreaDeAtuacao
    {
        public int id { get; set; }
        public string nome { get; set; }
        DAOAreaDeAtuacao<AreaDeAtuacao> daoAreaDeAtuacao = new DAOAreaDeAtuacao<AreaDeAtuacao>();

        public AreaDeAtuacao()
        {
            
        }
        public AreaDeAtuacao(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<AreaDeAtuacao> GetListarTodos()
        {
            return daoAreaDeAtuacao.ListarTodos().ToList();         
        }

        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(AreaDeAtuacao area)
        {
            Carregar();
            daoAreaDeAtuacao.Adicionar(area);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(AreaDeAtuacao area)
        {
            Carregar();
            daoAreaDeAtuacao.Remover(area);
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoAreaDeAtuacao.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoAreaDeAtuacao.Salvar();
        }
        #region Validações

        /// <summary>
        /// Cria um id 
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
        /// Busca a area de atuação por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AreaDeAtuacao BuscarAreaPorId(int id)
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
