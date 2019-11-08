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
    public class FuncionarioRepository
    {
        private readonly ContextDB _context;

        public FuncionarioRepository()
        {
            _context = new ContextDB();
        }

        /// <summary>
        /// Salva o objeto no banco de dados
        /// </summary>
        /// <param name="funcionario"></param>
        public void Salvar(Funcionario funcionario)
        {
            _context.Funcionario.Add(funcionario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Obtem todos os dados cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Funcionario> ObterTodos()
        {
            return _context.Funcionario.OrderBy(c => c.nome).ToList();
        }

        /// <summary>
        /// Edita um objeto no banco de dados
        /// </summary>
        /// <param name="funcionario"></param>
        public void Atualizar(Funcionario funcionario)
        {
            _context.Entry(funcionario).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// Exclui objeto 
        /// </summary>
        /// <param name="id"></param>
        public void Remover(string id)
        {
            var funcionario = ObterPorId(id);
            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();
        }

        /// <summary>
        /// Procura na tabela o objeto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Funcionario ObterPorId(string id)
        {
            return _context.Funcionario.Find(id);
        }

        /// <summary>
        /// Procura a area desejada pela abertura do chamado, depois procura quem tem menor numero de chamados
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public string SolicitacaoDeChamado(string area)
        {
            List<Funcionario> funcionariosPorArea = new List<Funcionario>();
            

            try
            {
                foreach (var item in ObterTodos().Where(c => c.areaDeAtuacao.Equals(area)).TakeWhile(c => c.areaDeAtuacao.Equals(area))) //Filtra por area de atuação 
                {
                    funcionariosPorArea.Add(item);
                }
                int menorChamado = funcionariosPorArea.Min(c => c.quantidadeChamados); //Encontra o minimo de quantidade de chamado               
                return funcionariosPorArea.Where(c => c.quantidadeChamados.Equals(menorChamado)).FirstOrDefault().id; //Procura o funcionario na lista filtrada que tem o menor

            }
            catch (Exception )
            {
                throw;
            }
     
        }
    }
}
