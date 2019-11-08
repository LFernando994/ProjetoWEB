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
    public class Contato
    {       
        public int id { get; set; }
        public string idPessoa { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string uf { get; set; }
        DAOContatoCliente<Contato> daoContatoCliente = new DAOContatoCliente<Contato>();
        DAOContatoFuncionario<Contato> daoContatoFuncionario = new DAOContatoFuncionario<Contato>();

        public Contato()
        {
        }

        public Contato(int id, string idPessoa, string cep, string endereco, string cidade, string bairro, int numero, string uf, string email, string telefone)
        {
            this.id = id;
            this.idPessoa = idPessoa;
            this.cep = cep;
            this.endereco = endereco;
            this.cidade = cidade;
            this.bairro = bairro;
            this.numero = numero;
            this.uf = uf;
            this.email = email;
            this.telefone = telefone;
        }

        #region Cliente
        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Contato> GetListarTodos()
        {
            return daoContatoCliente.ListarTodos().ToList();                   
        }

        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(Contato contato)
        {
            Carregar();
            daoContatoCliente.Adicionar(contato);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(Contato contato)
        {
            
            if(contato != null)
            {
                daoContatoCliente.Remover(contato);
            }
            else
            {
                Carregar();
                daoContatoCliente.Remover(contato);
            }
          
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoContatoCliente.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoContatoCliente.Salvar();
        }

        /// <summary>
        /// Método para criar um ID
        /// </summary>
        /// <returns></returns>
        public int ContadorIDCliente()
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

        #region Buscas

        /// <summary>
        /// Método que busca contato pelo endereco
        /// </summary>
        /// <param name="buscaEndereco"></param>
        /// <returns></returns>
        public Contato Buscar(string buscaEndereco)
        {
            try
            {
                return GetListarTodos().Where(c => c.endereco.Equals(buscaEndereco)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lista todos os contatos relacionados ao cliente por meio do id (Excluir contatos)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contato> BuscarPorID(string idPessoa)
        {
            try
            {
                return GetListarTodos().Where(c => c.idPessoa.Equals(idPessoa)).TakeWhile(c => c.idPessoa.Equals(idPessoa)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca um unico contato por id do Contato
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contato BuscarContatoID(string id)
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

        /// <summary>
        /// Busca contato para editar as informações
        /// </summary>
        /// <param name="id"></param>
        /// <param name="endereco"></param>
        /// <returns></returns>
        public Contato BuscaContatoEditar(int id, string idPessoa)
        {
            try
            {
                return GetListarTodos().Where(c => c.idPessoa.Equals(idPessoa)).TakeWhile(c => c.id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca todos os emails de determinada pessoa
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<string> EmailsContato(string id)
        {
            try
            {
                Carregar();
                return GetListarTodos().Where(c => c.id.Equals(id)).TakeWhile(c => c.id.Equals(id)).Select(x => x.email).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

        #region Funcionario

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<Contato> GetListarTodosFunc()
        {
            return daoContatoFuncionario.ListarTodos().ToList();
        }

        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void AdicionarFunc(Contato contato)
        {
            CarregarFunc();
            daoContatoFuncionario.Adicionar(contato);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void RemoverFunc(Contato contato)
        {
            CarregarFunc();
            daoContatoFuncionario.Remover(contato);
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void CarregarFunc()
        {
            daoContatoFuncionario.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void SalvarFunc()
        {
            daoContatoFuncionario.Salvar();
        }

        /// <summary>
        /// Método para criar um ID
        /// </summary>
        /// <returns></returns>
        public int ContadorIDFunc()
        {
            try
            {
                return GetListarTodosFunc().Last().id + 1;
            }
            catch (InvalidOperationException)
            {
                return 0;
            }
        }

        #region Buscas

        /// <summary>
        /// Busca contato do funciorario pelo numero e endereço
        /// </summary>
        /// <param name="contatoEndereco"></param>
        /// <param name="numero"></param>
        /// <returns></returns>
        public Contato BuscarFuncionario(string contatoEndereco, int numero)
        {
            try
            {
                return GetListarTodosFunc().Where(c => c.endereco.Equals(contatoEndereco) && c.numero.Equals(numero)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca os contatos relacionados ao funcionario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contato> BuscarPorIDFuncionario(string id)
        {
            try
            {
                return GetListarTodosFunc().Where(c => c.id.Equals(id)).TakeWhile(c => c.id.Equals(id)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion

    }
}
