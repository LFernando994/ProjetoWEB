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
    public class dbAreaDeAtuacaoController : Controller
    {
        private AreaDeAtuacaoRepository db = new AreaDeAtuacaoRepository();

        // GET: dbAreaDeAtuacao
        [Authorize(Roles = "View")]
        public ActionResult Index()
        {
            return View(db.ObterTodos());
        }

        // GET: dbAreaDeAtuacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaDeAtuacao areaDeAtuacao = db.ObterPorId(id);
            if (areaDeAtuacao == null)
            {
                return HttpNotFound();
            }
            return View(areaDeAtuacao);
        }

        // GET: dbAreaDeAtuacao/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbAreaDeAtuacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Create")]
        public ActionResult Create([Bind(Include = "id,nome")] AreaDeAtuacao areaDeAtuacao)
        {
            if (ModelState.IsValid)
            {
                db.Salvar(areaDeAtuacao);
                return RedirectToAction("Index");
            }

            return View(areaDeAtuacao);
        }

        // GET: dbAreaDeAtuacao/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaDeAtuacao areaDeAtuacao = db.ObterPorId(id);
            if (areaDeAtuacao == null)
            {
                return HttpNotFound();
            }
            return View(areaDeAtuacao);
        }

        // POST: dbAreaDeAtuacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit([Bind(Include = "id,nome")] AreaDeAtuacao areaDeAtuacao)
        {
            if (ModelState.IsValid)
            {
                db.Atualizar(areaDeAtuacao);
                return RedirectToAction("Index");
            }
            return View(areaDeAtuacao);
        }

        // GET: dbAreaDeAtuacao/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AreaDeAtuacao areaDeAtuacao = db.ObterPorId(id);
            if (areaDeAtuacao == null)
            {
                return HttpNotFound();
            }
            return View(areaDeAtuacao);
        }

        // POST: dbAreaDeAtuacao/Delete/5
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
