using CLData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRegras
{
    public class UsuariosSistema: Usuarios    // Usuário Sistema cadastra as pessoas no sistema como : Funcionários, Clientes e Áreas de Atuação 
    {
        DAOUsuariosSistema<UsuariosSistema> daoUsuarioSistema = new DAOUsuariosSistema<UsuariosSistema>();
        public UsuariosSistema() : base()
        {
        }

        public UsuariosSistema(int id, string nome, string cpf, int rg) : base(id, nome, cpf, rg)
        {
          
        }

        /// <summary>
        /// Lista todos os acesso de cliente do xml
        /// </summary>
        /// <returns></returns>
        public List<UsuariosSistema> GetListarTodos()
        {
            return daoUsuarioSistema.ListarTodos().ToList();        
        }

        /// <summary>
        /// Insere um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Adicionar(UsuariosSistema usuarios)
        {
            Carregar();
            daoUsuarioSistema.Adicionar(usuarios);
        }

        /// <summary>
        /// Remove um item ao xml acessado a DAO
        /// </summary>
        /// <param name="item"></param>
        public void Remover(UsuariosSistema usuario)
        {
            Carregar();
            daoUsuarioSistema.Remover(usuario);
        }

        /// <summary>
        /// Carrega os itens acessando a DAO
        /// </summary>
        public void Carregar()
        {
            daoUsuarioSistema.Carregar();
        }

        /// <summary>
        /// Salva os item acessando xml
        /// </summary>
        public void Salvar()
        {
            daoUsuarioSistema.Salvar();
        }

        #region Validações

        /// <summary>
        /// Método para criar um ID
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
        /// Busca Secretaria pelo usuario (usuario == rg)
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public UsuariosSistema BuscarPorUsuarioSistema(int usuario)
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
        /// Busca Secretaria pelo CPF
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public UsuariosSistema BuscarSecretariaPorCPF(string cpf)
        {
            try
            {
                return GetListarTodos().Where(c => c.cpf.Equals(cpf)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Busca Secretaria pelo id (usuario == rg)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuariosSistema BuscarPorID(int id)
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
