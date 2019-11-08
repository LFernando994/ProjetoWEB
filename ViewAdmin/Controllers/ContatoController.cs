using CLRegras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class ContatoController : Controller
    {
        Models.MDContato model = new Models.MDContato();
        // GET: Contato
        [Authorize(Roles = "View")]
        public ActionResult Index(string id)
        {
            model.Carregar();
            return View(model.BuscarPorID(id));
        }

        // GET: Contato/Details/5
        public ActionResult Details(string id)
        {
            model.Carregar();
            return View(model.BuscarContatoID(id));
        }

        // GET: Contato/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contato/Create
        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult Create(string id,CLRegras.Contato collection)
        {
            try
            {
                model.Carregar();
                collection.idPessoa = id;
                collection.id = model.ContadorIDCliente();
                model.Adicionar(collection);
                model.Salvar();
                // TODO: Add insert logic here

                return RedirectToAction("Index","Cliente").Mensagem("Cliente adicionado com sucesso","Informação");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(string id)
        {
            model.Carregar();                       
            return View(model.BuscarContatoID(id));
        }

        // POST: Contato/Edit/5
        [HttpPost]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id, CLRegras.Contato collection)
        {
            try
            {
                model.Carregar();
                CLRegras.Contato contatoEdit = model.BuscaContatoEditar(id, collection.idPessoa);
                contatoEdit.cep = collection.cep;
                contatoEdit.endereco = collection.endereco;
                contatoEdit.cidade = collection.cidade;
                contatoEdit.bairro = collection.bairro;
                contatoEdit.numero = collection.numero;
                contatoEdit.uf = collection.uf;
                contatoEdit.email = collection.email;
                contatoEdit.telefone = collection.telefone;
                model.Salvar();
                
                // TODO: Add update logic here

                return RedirectToAction("Index", new { id = model.id});
            }
            catch
            {
                return View();
            }
        }

        // GET: Contato/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(string id)
        {
            model.Carregar();
            return View(model.BuscarContatoID(id));
        }

        // POST: Contato/Delete/5
        [HttpPost]
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id, CLRegras.Contato collection)
        {
            try
            {
                model.Carregar();
                model.Remover(model.BuscaContatoEditar(id, collection.idPessoa));
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult APICorreios(int id, CLRegras.Contato collection)
        {
            try
            {
                BuscaCEP(collection.cep);

                return RedirectToAction("Create", new { id = id});
            }
            catch
            {
                return View();
            }
        }

        public ActionResult BuscaCEP(string cep)
        {
           
            using (var consulta = new WSCorreios.AtendeClienteClient())
            {
                var resultado = consulta.consultaCEP(cep);
                ViewData["Bairro"] = resultado.bairro;
                ViewData["Cidade"] = resultado.cidade;
                ViewData["Uf"] = resultado.uf;
                ViewData["Endereco"] = resultado.end;
                return View("Register", "Account");
            }
        }
    }
}
