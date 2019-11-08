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
    public class ContatoRepository
    {
        private readonly ContextDB _context;

        public ContatoRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="contato"></param>
        public void Salvar(Contato contato)
        {
            _context.Contatodb.Add(contato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Contato> ObterTodos()
        {
            return _context.Contatodb.ToList();
        }

        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="contato"></param>
        public void Atualizar(Contato contato)
        {
            _context.Entry(contato).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Exclui objeto 
        /// </summary>
        /// <param name="id"></param>
        public void Remover(int id)
        {
            var contato = ObterPorId(id);
            _context.Contatodb.Remove(contato);
            _context.SaveChanges();
        }

        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contato ObterPorId(int? id)
        {
            return _context.Contatodb.Find(id);
        }

        /// <summary>
        /// Obtem todos os contatos relacionados a pessoa no banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Contato> GetContatosTodos(string id)
        {
            return _context.Contatodb.Where(c => c.idPessoa.Equals(id)).ToList();                  
        }

    }
}

