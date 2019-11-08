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
    public class AreaDeAtuacaoRepository
    {
        private readonly ContextDB _context;

        public AreaDeAtuacaoRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="Area"></param>
        public void Salvar(AreaDeAtuacao Area)
        {
            _context.Areas.Add(Area);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<AreaDeAtuacao> ObterTodos()
        {
            return _context.Areas.ToList();
        }


        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="Area"></param>
        public void Atualizar(AreaDeAtuacao Area)
        {
            _context.Entry(Area).State = EntityState.Modified;
            _context.SaveChanges();
        }


        /// <summary>
        /// Exclui objeto 
        /// </summary>
        /// <param name="id"></param>
        public void Remover(int id)
        {
            var Area = ObterPorId(id);
            _context.Areas.Remove(Area);
            _context.SaveChanges();
        }

        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AreaDeAtuacao ObterPorId(int? id)
        {
            return _context.Areas.Find(id);
        }


    }
}
