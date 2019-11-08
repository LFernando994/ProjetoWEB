using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CLRegras;
using InfraWeb.Context;
using InfraWeb.Repository;

namespace ViewAdmin.Controllers
{
    public class dbPerfilUserController : Controller
    {
        private PerfilUserRepository db = new PerfilUserRepository();

        // GET: PerfilUser
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {
            return View(db.ObterTodos());
        }

        // GET: PerfilUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUser perfilUser = db.ObterPorId(id);
            if (perfilUser == null)
            {
                return HttpNotFound();
            }
            return View(perfilUser);
        }

        // GET: PerfilUser/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Create")]
        public ActionResult Create([Bind(Include = "id,nome,view,edit,create,delete")] PerfilUser perfilUser)
        {
            if (ModelState.IsValid)
            {
                db.Salvar(perfilUser);
                return RedirectToAction("Index");
            }

            return View(perfilUser);
        }

        // GET: PerfilUser/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUser perfilUser = db.ObterPorId(id);
            if (perfilUser == null)
            {
                return HttpNotFound();
            }
            return View(perfilUser);
        }

        // POST: PerfilUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit([Bind(Include = "id,nome,view,edit,create,delete")] PerfilUser perfilUser)
        {
            if (ModelState.IsValid)
            {
                db.Atualizar(perfilUser);
                return RedirectToAction("Index");
            }
            return View(perfilUser);
        }

        // GET: PerfilUser/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PerfilUser perfilUser = db.ObterPorId(id); 
            if (perfilUser == null)
            {
                return HttpNotFound();
            }
            return View(perfilUser);
        }

        // POST: PerfilUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
