using CLRegras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewAdmin.Models;

namespace ViewAdmin.Controllers
{
    public class AreasController : Controller
    {
        MDAreas Model = new MDAreas();

        // GET: Areas
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {         
            Model.Carregar();           
            return View(Model.GetListarTodos());
        }

        // GET: Areas/Details/5
        public ActionResult Details(int id)
        {
            Model.Carregar();
            return View(Model.BuscarAreaPorId(id));
        }

        // GET: Areas/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Areas/Create
        [HttpPost]
        [Authorize(Roles = "Create")]
        public ActionResult Create(CLRegras.AreaDeAtuacao collection)
        {
            try
            {
                Model.Carregar();
                collection.id = Model.ContadorID();
                Model.Adicionar(collection);
                Model.Salvar();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Areas/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id)
        {
            Model.Carregar();
            return View(Model.BuscarAreaPorId(id));
        }

        // POST: Areas/Edit/5
        [HttpPost]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int id, CLRegras.AreaDeAtuacao collection)
        {
            try
            {
                Model.Carregar();
                AreaDeAtuacao areaEdit = Model.BuscarAreaPorId(id);
                areaEdit.nome = collection.nome;
                Model.Salvar();
                Model.Carregar();

                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Areas/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id)
        {
            Model.Carregar();
            return View(Model.BuscarAreaPorId(id));
        }

        // POST: Areas/Delete/5
        [HttpPost]
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int id, CLRegras.AreaDeAtuacao collection)
        {
            try
            {
                Model.Carregar();

                AreaDeAtuacao areaDelete = Model.BuscarAreaPorId(collection.id);
                Model.Remover(areaDelete);
                Model.Salvar();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
