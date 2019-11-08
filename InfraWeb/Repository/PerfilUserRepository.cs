using CLRegras;
using InfraWeb.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfraWeb.Repository
{
    public class PerfilUserRepository
    {
        private readonly ContextDB _context;

        public PerfilUserRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="user"></param>
        public void Salvar(PerfilUser user)
        {
            _context.Usuario.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<PerfilUser> ObterTodos()
        {
            return _context.Usuario.ToList();
        }

        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="user"></param>
        public void Atualizar(PerfilUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Exclui objeto 
        /// </summary>
        /// <param name="id"></param>
        public void Remover(int id)
        {
            var user = ObterPorId(id);
            _context.Usuario.Remove(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilUser ObterPorId(int? id)
        {
            return _context.Usuario.Find(id);
        }

        /// <summary>
        /// Procura na tabela o objeto por nome
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PerfilUser ObterPorNome(string nome)
        {
            return ObterTodos().Where(c => c.nome.Equals(nome)).FirstOrDefault();
        }
    }
}
