using CLRegras;
using InfraWeb.Repository;
using System.Net;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace ViewCliente.Controllers
{
    public class dbClienteController : Controller
    {
        ClienteRepository _clienteRpository = new ClienteRepository();
        public dbClienteController()
        {
            _clienteRpository = new ClienteRepository();
        }

        // GET: dbCliente

        [Authorize(Roles ="View")]
        public ActionResult Index(string Pesquisa)
        {
            if (Request.IsAjaxRequest())
                return PartialView("_IndexPartial", _clienteRpository.BuscarPorNome(Pesquisa));

            return View(_clienteRpository.ObterTodos());

        }


        // GET: dbCliente/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteRpository.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }


        // GET: dbCliente/Create
        [Authorize(Roles = "Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbCliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Create")]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRpository.Salvar(cliente);

            }

            return Json(new { Resultado = cliente.id }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Create")]
        public void CreateRegister(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRpository.Salvar(cliente);
            }
        }

        // GET: dbCliente/Edit/5
        [Authorize(Roles = "Edit")]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteRpository.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: dbCliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Edit")]
        public ActionResult Edit([Bind(Include = "id,dataDeExpiracao,nome,cpf,rg,dataDeNascimento,grupoSanguineo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRpository.Atualizar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: dbCliente/Delete/5
        [Authorize(Roles = "Delete")]
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = _clienteRpository.ObterPorId(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [Authorize(Roles = "Delete")]
        // POST: dbCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
    
            _clienteRpository.Remover(id);
            ContatoRepository db = new ContatoRepository();
            foreach (var item in db.GetContatosTodos(id))
            {
                db.Remover(item.id);
            }

            return RedirectToAction("Index");
        }
    }
}
