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

namespace ViewCliente.Controllers
{
    public class dbContatoController : Controller
    {
        public ContatoRepository _contatoRepository = new ContatoRepository();

        // GET: dbContato
        public ActionResult Index()
        {
            return View(_contatoRepository.ObterTodos());
        }

        // GET: dbContato
        public ActionResult IndexContatos(string id)
        {
            return View(_contatoRepository.GetContatosTodos(id));
        }

        // GET: dbContato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // GET: dbContato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dbContato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idPessoa,telefone,email,cep,endereco,cidade,bairro,numero,uf")] Contato contato)
        {
            //if (ModelState.IsValid)
            //{      
                string idPessoa = Request.Path.Substring(18);
                contato.idPessoa = idPessoa;
                _contatoRepository.Salvar(contato);
                return RedirectToAction("Index","dbCliente").Mensagem("Contato salvo com sucesso!");
            //}

            //return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void RegistrarBD(Contato contato)
        {
            if (ModelState.IsValid)
            {

                _contatoRepository.Salvar(contato);             
            }
        }

        // GET: dbContato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: dbContato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idPessoa,telefone,email,cep,endereco,cidade,bairro,numero,uf")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Salvar(contato);
                return RedirectToAction("Index");
            }
            return View(contato);
        }

        // GET: dbContato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = _contatoRepository.ObterPorId(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: dbContato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {          
            _contatoRepository.Remover(id);
            return RedirectToAction("Index");
        }

   

        public void BuscaCEP(string cep)
        {
           
            using (var consulta = new WSCorreios.AtendeClienteClient())
            {
                var resultado = consulta.consultaCEP(cep);
                ViewBag.Bairro = resultado.bairro;
                ViewBag.Cidade = resultado.cidade;
                ViewBag.Uf = resultado.uf;
                ViewBag.Endereco = resultado.end;

            }
        }

    }
}
