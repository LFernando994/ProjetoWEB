using CLRegras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class ClienteController : Controller
    {
        MDClientes model = new MDClientes();
        // GET: Cliente
        [Authorize(Roles ="View")]
        public ActionResult Index()
        {          
            model.Carregar();
            return View(model.GetListarTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            model.Carregar();
            return View(model.BuscarClientePorID(id));
        }

        // GET: Cliente/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            DropDownList();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult Create(CLRegras.Cliente collection)
        {
            try
            {
                model.Carregar();
                collection.id = Convert.ToString(model.ContadorID());
                model.Adicionar(collection);
                model.Salvar();
                // TODO: Add insert logic here

                return RedirectToAction("Create","Contato", new {idPessoa = collection.id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id)
        {
            model.Carregar();
            return View(model.BuscarClientePorID(id));
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id, CLRegras.Cliente collection)
        {
            try
            {
                model.Carregar();
                Cliente clienteEdit = model.BuscarClientePorID(id);
                clienteEdit.nome = collection.nome;
                clienteEdit.rg = collection.rg;
                clienteEdit.sexo = collection.sexo;
                clienteEdit.dataDeNascimento = collection.dataDeNascimento;
                clienteEdit.dataDeExpiracao = collection.dataDeExpiracao;
                clienteEdit.cpf = collection.cpf;
                clienteEdit.grupoSanguineo = collection.grupoSanguineo;
                model.Salvar();
                model.Carregar();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {             
                return View();
            }
        }

        // GET: Cliente/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id)
        {
            model.Carregar();
            Cliente clienteAtual = model.BuscarClientePorID(id);            
            return View(clienteAtual);
            
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id, Cliente collection)
        {
            try
            {
                model.Carregar();
                
                Cliente item = model.BuscarClientePorID(id);
                model.Remover(item);
                model.Salvar();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Preenche as DropLista na View, mandando para ViewBag
        /// </summary>
        public void DropDownList()
        {
            List<string> sexo = new List<string>();          
            List<string> grupoSanguineio = new List<string>();

            sexo.Add("M");
            sexo.Add("F");

            grupoSanguineio.Add("A+");
            grupoSanguineio.Add("A-");
            grupoSanguineio.Add("B+");
            grupoSanguineio.Add("B-");
            grupoSanguineio.Add("AB+");
            grupoSanguineio.Add("AB-");
            grupoSanguineio.Add("O+");
            grupoSanguineio.Add("O-");

            ViewBag.grupoSanguineio = new SelectList(grupoSanguineio);
            ViewBag.Sexo = new SelectList(sexo);
        }
    }
}
