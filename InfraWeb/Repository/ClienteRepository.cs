using CLRegras;
using InfraWeb.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace InfraWeb.Repository
{
    public class ClienteRepository
    {
        private readonly ContextDB _context;

        public ClienteRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="cliente"></param>
        public void Salvar(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Cliente> ObterTodos()
        {
            return _context.Cliente.OrderBy(c => c.nome).ToList();
        }

        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="cliente"></param>
        public void Atualizar(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Exclui objeto 
        /// </summary>
        /// <param name="id"></param>
        public void Remover(string id)
        {
            var cliente = ObterPorId(id);
            _context.Cliente.Remove(cliente);
            _context.SaveChanges();
        }

        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cliente ObterPorId(string id)
        {
            return _context.Cliente.Find(id);
        }


        /// <summary>
        /// Busca pelo nome return a lista de contains
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public List<Cliente> BuscarPorNome(string nome)
        {
            return ObterTodos().Where(c => c.nome.Contains(nome)).TakeWhile(c => c.nome.Contains(nome)).ToList();                   
        }
  
    }
}
