using CLRegras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class UsuarioSistemaController : Controller
    {
        MDUsuarioSistema model = new MDUsuarioSistema();
        // GET: UsuarioSistema
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {
            model.Carregar();
            return View(model.GetListarTodos());
        }

        // GET: UsuarioSistema/Details/5
        public ActionResult Details(int id)
        {
            model.Carregar();           
            return View(model.BuscarPorID(id));
        }

        // GET: UsuarioSistema/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioSistema/Create
        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult Create(CLRegras.UsuariosSistema collection)
        {
            try
            {
                model.Carregar();
                collection.id = model.ContadorID();
                model.Adicionar(collection);
                model.Salvar();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioSistema/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id)
        {
            model.Carregar();
            return View(model.BuscarPorID(id));
        }

        // POST: UsuarioSistema/Edit/5
        [HttpPost]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id, CLRegras.UsuariosSistema collection)
        {
            try
            {
                model.Carregar();
                UsuariosSistema userEdit = model.BuscarPorID(id);
                userEdit.nome = collection.nome;
                userEdit.cpf = collection.cpf;
                userEdit.rg = collection.rg;
                model.Salvar();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioSistema/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id)
        {
            model.Carregar();
            return View(model.BuscarPorID(id));
        }

        // POST: UsuarioSistema/Delete/5
        [HttpPost]
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id, CLRegras.UsuariosSistema collection)
        {
            try
            {
                model.Carregar();
                //model.Remover(collection);           
                model.Remover(model.BuscarPorID(id));
                model.Salvar();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
