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
    public class ChamadoRepository
    {
        private readonly ContextDB _context;

        public ChamadoRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="chamado"></param>
        public void Salvar(Chamado chamado)
        {
            _context.Chamado.Add(chamado);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Chamado> ObterTodos()
        {
            return _context.Chamado.ToList();
        }


        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="chamado"></param>
        public void Atualizar(Chamado chamado)
        {
            _context.Entry(chamado).State = EntityState.Modified;
            _context.SaveChanges();
        }


        /// <summary>
        /// Exclui objeto e retirar um chamado de um cliente
        /// </summary>
        /// <param name="id"></param>
        public void Remover(int id)
        {
            var chamado = ObterPorId(id);
            FuncionarioRepository funcresponsavel = new FuncionarioRepository();
            var func = funcresponsavel.ObterPorId(chamado.idFuncionario); //Pega o funcionario responsavel pelo chamado
            func.quantidadeChamados -= 1; //Tira um na quantidade de chamado
            funcresponsavel.Atualizar(func); //Atualiza no banco
            _context.Chamado.Remove(chamado);
            _context.SaveChanges();
        }


        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Chamado ObterPorId(int? id)
        {
            return _context.Chamado.Find(id);
        }


        /// <summary>
        /// Obtem os Chamados expecifico de um funcionario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Chamado> ObterChamadosExpecificos(string id)
        {
            return ObterTodos().Where(c => c.idFuncionario.Equals(id)).ToList();
        }
    }
}
