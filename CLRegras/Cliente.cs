using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using CLData;

namespace CLRegras
{
    public class Cliente: Pessoa
    {       
        public DateTime dataDeExpiracao { get; set; }
        DAOCliente<Cliente> daoCliente = new DAOCliente<Cliente>();

        public Cliente() : base()
        {
        }

        public Cliente(string id, string nome, string sexo, string cpf, int rg, DateTime dataDeNascimento, string grupoSanguineo, DateTime dataDeExpiracao) : base(id, nome, sexo, cpf, rg, dataDeNascimento, grupoSanguineo)
        {
         
            this.dataDeExpiracao = dataDeExpiracao;          
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetListarTodos()
        {
            return daoCliente.ListarTodos().ToList();       
        }
        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(Cliente cliente)
        {
            Carregar();
            daoCliente.Adicionar(cliente);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(Cliente cliente)
        {
            if(cliente != null)
            {
                daoCliente.Remover(cliente);
            }
            else
            {
                Carregar();
                daoCliente.Remover(cliente);
            }            
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoCliente.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoCliente.Salvar();
        }

        #region Pesquisa 
        /// <summary>
        /// Busca o cliente pelo cpf e retorna o mesmo
        /// </summary>
        /// <param name="clienteCPF"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorCPF(string clienteCPF)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(clienteCPF)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca cliente pelo cpf e retorna seu id
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public string BuscarIdPorCPF(string cpf)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault().id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca cliente pelo id e retorna o cliente complete
        /// </summary>
        /// <param name="buscaid"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorID(int buscaid)
        {
            try
            {
                return GetListarTodos().Where(c => c.id.Equals(buscaid)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Cliente BuscarClientePorUsuario(int usuario)
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

        #endregion

        #region Validações

        /// <summary>
        /// Método para criar um ID
        /// </summary>
        /// <returns></returns>
        public int ContadorID()
        {
            try
            {
                return Convert.ToInt32(GetListarTodos().Last().id) + 1;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        /// <summary>
        /// Verifica se a data de validade daquele login esta correta
        /// </summary>
        /// <param name="dataDeExpiracao"></param>
        /// <returns></returns>
        public bool ValidarExpiracao(DateTime dataDeExpiracao)
        {
            try
            {
                DateTime dataHoje = DateTime.Now.Date;
                if (dataDeExpiracao >= dataHoje)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
